using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day6_Tests
{
	[TestClass]
	public class UnitTest1
	{
		private Coordinator _coordinator;
		[TestInitialize]
		public void Setup()
		{
			_coordinator = new Coordinator();
		}

		[TestMethod]
		public void TestMethod1()
		{
			List<string> input = new List<string>();
			int biggestArea = _coordinator.GetBiggestArea(input);

		}
	}

	internal class Coordinator
	{
		public int GetBiggestArea(List<string> input)
		{
			throw new NotImplementedException();
			var coordinate = (X: 0, Y: 0);

		}

		private List<int> CalculateManhattanDistance()
		{
			throw new NotImplementedException();
		}

		private int FindBiggestArea()
		{
			throw new NotImplementedException();
		}
	}
}
