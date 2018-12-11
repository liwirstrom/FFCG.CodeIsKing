using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day6_Tests
{
	[TestClass]
	public class ChronalCoordinatorUnitTest
	{
		private Coordinator _coordinator;
		[TestInitialize]
		public void Setup()
		{
			_coordinator = new Coordinator();
		}


	    [TestMethod]
	    public void Should_Be_Area_17()
	    {
	        var input = File.ReadAllLines("../../Unittest_input.txt").ToList();
	        var coordinates = new List<Coordinate>();
	        var maxArea = 0;
	        foreach (var i in input)
	        {
	            var coordinate = new Coordinate();
	            coordinate.X = Convert.ToInt32(i.Split(',')[0]);
	            coordinate.Y = Convert.ToInt32(i.Split(',')[1]);
	            coordinates.Add(coordinate);
	        }

	        var area = _coordinator.GetArea(coordinates);

	        Assert.AreEqual(17, area);

	    }


        [TestMethod]
	    public void Should_Calculate_Manhattan_Distance()
	    {
	        var point1 = new Coordinate {X = 1, Y = 6};
	        var point2 = new Coordinate {X = 3, Y = 4};

	        var distance = _coordinator.CalculateManhattanDistance(point1, point2);
	        var distanceSamePoint = _coordinator.CalculateManhattanDistance(point1, point1);

	        Assert.AreEqual(4, distance);
	        Assert.AreEqual(0, distanceSamePoint);

	    }

	    [TestMethod]
	    public void Should_Find_Biggest_Area()
	    {
	        var input = File.ReadAllLines("../../Unittest_input.txt").ToList();

	        var coordinates = _coordinator.GetCoordinates(input);

	        var area = _coordinator.GetArea(coordinates);

	        Assert.AreEqual(17, area);
	    }

	    [TestMethod]
	    public void Answer_input_part1()
	    {
	        var input = File.ReadAllLines("../../Day6_input.txt").ToList();

	        var coordinates = _coordinator.GetCoordinates(input);

            var area = _coordinator.GetArea(coordinates);

	        Assert.AreEqual(3260, area);
	    }

	    [TestMethod]
	    public void Should_Find_Region()
	    {
	        var input = File.ReadAllLines("../../Unittest_input.txt").ToList();

	        var coordinates = _coordinator.GetCoordinates(input);

	        var area = _coordinator.GetRegion(coordinates, 32);

	        Assert.AreEqual(16, area);
	    }


	    [TestMethod]
	    public void Answer_input_part2()
	    {
	        var input = File.ReadAllLines("../../Day6_input.txt").ToList();

	        var coordinates = _coordinator.GetCoordinates(input);

	        var area = _coordinator.GetRegion(coordinates, 10000);

	        Assert.AreEqual(42535, area);
	    }
    }

    public class Coordinator
	{
		public List<Coordinate> GetCoordinates(List<string> input)
		{
            var coordinates = new List<Coordinate>();
		    foreach (var i in input)
		    {
                var coordinate = new Coordinate();
		        coordinate.X = Convert.ToInt32( i.Split(',')[0]);
		        coordinate.Y = Convert.ToInt32( i.Split(',')[1]);
                coordinates.Add(coordinate);
		    }

		    return coordinates;
		}

	    public int GetArea(List<Coordinate> allCoordinates)
	    {
	        var minX = allCoordinates.Min(coord => coord.X) -1;
	        var maxX = allCoordinates.Max(coord => coord.X) +1;
	        var minY = allCoordinates.Min(coord => coord.Y) -1;
	        var maxY = allCoordinates.Max(coord => coord.Y) +1;

	        var area = new int[allCoordinates.Count];

	        foreach (var x in Enumerable.Range(minX, maxX - minX + 1))
	        {
	            foreach (var y in Enumerable.Range(minY, maxY - minX + 1))
	            {
                    var middlePoint = new Coordinate{X = x, Y = y};
	                var d = allCoordinates.Select(coord => CalculateManhattanDistance(middlePoint, coord)).Min();
	                var closest = Enumerable.Range(0, allCoordinates.Count).Where(i => CalculateManhattanDistance(middlePoint, allCoordinates[i]) == d).ToArray();

	                if (closest.Length != 1)
	                {
	                    continue;
	                }

	                if (x == minX || x == maxX || y == minY || y == maxY)
	                {
	                    foreach (var icoord in closest)
	                    {
	                        if (area[icoord] != -1)
	                        {
	                            area[icoord] = -1;
	                        }
	                    }
	                }
	                else
	                {
	                    foreach (var icoord in closest)
	                    {
	                        if (area[icoord] != -1)
	                        {
	                            area[icoord]++;
	                        }
	                    }
	                }
	            }
	        }
	        return area.Max();
	    }


	    public int GetRegion(List<Coordinate> allCoordinates, int limit)
	    {
            //var region = 0;

            //var minX = allCoordinates.Min(coord => coord.X);
            //var maxX = allCoordinates.Max(coord => coord.X);
            //var minY = allCoordinates.Min(coord => coord.Y);
            //var maxY = allCoordinates.Max(coord => coord.Y);

            //for (int x = minX; x <= (maxX - minX) +1 ; x++)
            //{
            //    for (int y = minY; y <= (maxY - minY) + 1; y++)
            //    {
            //        var middlePoint = new Coordinate {X = x, Y = y};
            //        var sumDistance = 0;
            //        foreach (var coordinate in allCoordinates)
            //        {
            //            sumDistance += CalculateManhattanDistance(middlePoint, coordinate);
            //        }

            //        if (sumDistance < limit) { 
            //            region++;
            //        }
	        //    }
	        //}

	        //   return region;
	        var minX = allCoordinates.Min(coord => coord.X) - 1;
	        var maxX = allCoordinates.Max(coord => coord.X) + 1;
	        var minY = allCoordinates.Min(coord => coord.Y) - 1;
	        var maxY = allCoordinates.Max(coord => coord.Y) + 1;

	        var area = 0;

	        foreach (var x in Enumerable.Range(minX, maxX - minX + 1))
	        {
	            foreach (var y in Enumerable.Range(minY, maxY - minX + 1))
	            {
	                var middlePoint = new Coordinate { X = x, Y = y };
                    var d = allCoordinates.Select(coord => CalculateManhattanDistance(middlePoint, coord)).Sum();
	                if (d < 10000)
	                    area++;
	            }
	        }
	        return area;
        }

	    public int CalculateManhattanDistance(Coordinate coordinate1, Coordinate coordinate2)
	    {
	        return Math.Abs(coordinate1.X - coordinate2.X) + Math.Abs(coordinate1.Y - coordinate2.Y);
	    }

	}

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
