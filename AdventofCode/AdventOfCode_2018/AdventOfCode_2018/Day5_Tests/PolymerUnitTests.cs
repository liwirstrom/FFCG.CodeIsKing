using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day5_Tests
{
	[TestClass]
	public class PolymerUnitTests
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
}
