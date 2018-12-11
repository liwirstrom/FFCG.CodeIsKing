using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day7_Tests
{
	[TestClass]
	public class UnitTest1
	{
		private InstructionReader _instructionReader;

		[TestInitialize]
		public void Setup()
		{
			_instructionReader = new InstructionReader();
		}

		[TestMethod]
		public void Should_Find_Instructions()
		{
			var input = File.ReadAllLines("../../Unittest_input.txt");

			var rules = new List<(string, string)>();
			foreach (var instruction in input)
			{
				var elements = instruction.Split(' ');
				rules.Add((elements[1], elements[7]));
			}
	
			var steps = new List<string>();

			foreach (var rule in rules)
			{
				if (!steps.Contains(rule.Item1))
				{
					steps.Add(rule.Item1);
				}

				if (!steps.Contains(rule.Item2))
				{
					steps.Add(rule.Item2);
				}
			}

			Assert.AreEqual(6,steps.Count);
		}


		[TestMethod]
		public void Should_Sort_List()
		{
			var input = File.ReadAllLines("../../Unittest_input.txt");

			var rules = _instructionReader.GetRules(input);

			var steps = _instructionReader.FindSteps(rules);

			rules = rules.OrderByDescending(r => r.Key).
					ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
			steps.Sort();

			string order = _instructionReader.SortSteps(rules, steps);

			Assert.AreEqual("CABDFE", order);
		}

		[TestMethod]
		public void Answer_input_part1()
		{
			var input = File.ReadAllLines("../../Day7_input.txt");

			var rules = _instructionReader.GetRules(input);

			var steps = _instructionReader.FindSteps(rules);

			steps.Sort();

			string order = _instructionReader.SortSteps(rules, steps);

			Assert.AreEqual("CABDFE", order);
		}

	}

	public class InstructionReader
	{
		public string SortSteps(Dictionary<string, List<string>> rules, List<string> steps)
		{
			var allRulesImplemented = false;
			while (!allRulesImplemented)
			{
				allRulesImplemented = true;

				foreach (var rule in rules)
				{
					foreach (var step in rule.Value)
					{		
						var keyIndex = steps.FindIndex(s => s == rule.Key);
						var subList = steps.GetRange(0, keyIndex);
						if (subList.Contains(step))
						{
							var valueIndex = steps.FindIndex(s => s == step);
							steps[keyIndex] = step;
							steps[valueIndex] = rule.Key;

							allRulesImplemented = false;
						}
					}
				}
			}

			return steps.Aggregate((i, j) => i + j);
		}

		public List<string> FindSteps(Dictionary<string, List<string>> rules)
		{
			var steps = new List<string>();
			foreach (var rule in rules)
			{
				if (!steps.Contains(rule.Key))
				{
					steps.Add(rule.Key);
				}

				foreach (var v in rule.Value)
				{
					if (!steps.Contains(v))
					{
						steps.Add(v);
					}
				}

			}

			return steps;
		}

		public Dictionary<string, List<string>> GetRules(string[] input)
		{

			var rules = new Dictionary<string, List<string>>();
			foreach (var instruction in input)
			{
				var elements = instruction.Split(' ');
				if (!rules.ContainsKey(elements[1]))
				{
					rules[elements[1]] = new List<string>{elements[7]};
				}
				else
				{
					rules[elements[1]].Add(elements[7]);
				}
			}

			return rules;
		}
	}
}
