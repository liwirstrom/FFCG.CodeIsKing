using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day5_Tests
{
	[TestClass]
	public class UnitTest1
	{
		private PolymerCalculator _polymerCalculator;
		[TestInitialize]
		public void Setup()
		{ 
			_polymerCalculator = new PolymerCalculator();
		}
	

		[TestMethod]
		public void Should_Remove_All()
		{
			var input = "abBA";
			var reactedPolymer = _polymerCalculator.React(input);
			Assert.AreEqual(0, reactedPolymer.Count);

			input = "abBA";
			reactedPolymer = _polymerCalculator.React(input);
			Assert.AreEqual(0, reactedPolymer.Count);
		}

		[TestMethod]
		public void Should_Remove_None()
		{
			var input = "abAB";
			var reactedPolymer = _polymerCalculator.React(input);
			Assert.AreEqual(4, reactedPolymer.Count);

			input = "aabAAB";
			reactedPolymer = _polymerCalculator.React(input);
			Assert.AreEqual(6, reactedPolymer.Count);
		}

		[TestMethod]
		public void Should_Be_10_Units_Left()
		{
			var input = "dabAcCaCBAcCcaDA";
			var reactedPolymer = _polymerCalculator.React(input);
			Assert.AreEqual(10, reactedPolymer.Count);
		}

		[TestMethod]
		public void Answer_input_part1()
		{
			var input = File.ReadAllText("../../Day5_input.txt");
			var reactedPolymer = _polymerCalculator.React(input);
			Assert.AreEqual(9686, reactedPolymer.Count);
		}


		[TestMethod]
		public void Should_Find_Smallest_Polymer_()
		{
			var input = "dabAcCaCBAcCcaDA";
			var polymerLength = _polymerCalculator.ForceReact(input);
			Assert.AreEqual(4, polymerLength);
		}


		[TestMethod]
		public void Answer_Input_part2()
		{
			var input = File.ReadAllText("../../Day5_input.txt");
			var polymerLength = _polymerCalculator.ForceReact(input);
			Assert.AreEqual(5524, polymerLength);
		}
	}

	public class PolymerCalculator
	{
		public List<char> React(string input)
		{
			var reactionDone = false;
			var units = input.ToList();
			var tempChar = units;
			while (!reactionDone && units.Count != 0 )
			{
				reactionDone = true;
				units = tempChar;
				var list_size = units.Count;
				var i = 0;
				while (true)
				{
					if ((Char.IsUpper(units[i]) && Char.ToLower(units[i]) == units[i + 1]) ||
					    (Char.IsLower(units[i]) && Char.ToUpper(units[i]) == units[i + 1]))
					{
						reactionDone = false;
						units.RemoveAt(i);
						units.RemoveAt(i);
						list_size -= 2;
						i -= 1;
					}
					else
					{
						tempChar[i] = units[i];
					}
					i++;
					if (i >= list_size-1) break;
				}
			}

			return units;

		}

		public int ForceReact(string input)
		{
			var smallestPolymer = Int32.MaxValue;
			var unitTypes = input.ToLower().GroupBy(x => x).ToList();
			foreach (var unitType in unitTypes)
			{

				var modifiedPolymer = RemoveUnwantedChar(input, unitType.Key);
				var newPolymer = React(modifiedPolymer);
				if (newPolymer.Count < smallestPolymer)
				{
					smallestPolymer = newPolymer.Count;
				}
				
			}

			return smallestPolymer;
		}

		private string RemoveUnwantedChar(string input, char unwantedChar)
		{

			StringBuilder builder = new StringBuilder(input.Length);

			for (int i = 0; i < input.Length; i++)
			{
				if (char.ToLower(input[i]) != unwantedChar)
				{
					builder.Append(input[i]);
				}
			}
			return builder.ToString();
		}
	}
}
