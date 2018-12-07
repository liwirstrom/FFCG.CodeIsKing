using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuple = System.Tuple;

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
		public void Should_Find_Area()
		{
		    var point1 = new Coordinate { X = 1, Y = 6 };
		    var point2 = new Coordinate { X = 3, Y = 4 };

            var closestCoordinates = new List<(int, Coordinate)>{(2,point1)};

		    var area = _coordinator.GetArea(closestCoordinates, point2);

            Assert.AreEqual(3, area);

		}


	    [TestMethod]
	    public void Should_Find_Closest_Coordinates()
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

	        var closestCoordinates = _coordinator.GetClosestCoordinates(coordinates, new Coordinate { X = 3, Y = 4 });
            Assert.IsTrue(closestCoordinates.Any(c => c.Item2.X == 1 && c.Item2.X == 1));
            //Assert.IsTrue(closestCoordinates.Any(c => c.Item2.X == 1 && c.Item2.X == 6));
            //Assert.IsTrue(closestCoordinates.Any(c => c.Item2.X == 8 && c.Item2.X == 3));
            //Assert.IsTrue(closestCoordinates.Any(c => c.Item2.X == 5 && c.Item2.X == 5));

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

	        var point = new Coordinate {X = 3, Y = 4};


            var closestCoordinates = _coordinator.GetClosestCoordinates(coordinates, point);

	        var area = _coordinator.GetArea(closestCoordinates, point);

            Assert.AreEqual(17,area);

	    }

	    [TestMethod]
	    public void Should_Calculate_Manhattan_Distance()
	    {
	        var point1 = new Coordinate {X = 1, Y = 6};
	        var point2 = new Coordinate {X = 3, Y = 4};

	        var distance = _coordinator.CalculateManhattanDistance(point1, point2);
	        var distanceSamePoint = _coordinator.CalculateManhattanDistance(point1, point1);

	        Assert.AreEqual(2, distance);
	        Assert.AreEqual(0, distanceSamePoint);

	    }

	    [TestMethod]
	    public void Should_Find_Biggest_Area()
	    {
	        var input = File.ReadAllLines("../../Unittest_input.txt").ToList();

	        var area = _coordinator.GetBiggestArea(input);

	        Assert.AreEqual(17, area);

	    }

    }

	public class Coordinator
	{
		public int GetBiggestArea(List<string> input)
		{
            var coordinates = new List<Coordinate>();
		    var maxArea = 0;
		    foreach (var i in input)
		    {
                var coordinate = new Coordinate();
		        coordinate.X = Convert.ToInt32( i.Split(',')[0]);
		        coordinate.Y = Convert.ToInt32( i.Split(',')[1]);
                coordinates.Add(coordinate);
		    }

		    for (int i = 0; i < coordinates.Count; i++)
		    {
		        if (coordinates.Any(c => c.X > coordinates[i].X) 
		            && coordinates.Any(c => c.X < coordinates[i].X)
		            && coordinates.Any(c => c.Y > coordinates[i].Y)
                    && coordinates.Any(c => c.X > coordinates[i].X)
                    )
		        {
		            var closestCoordinates = GetClosestCoordinates(coordinates, coordinates[i]);
		            var area = GetArea(closestCoordinates, coordinates[i]);
		            if (area > maxArea)
		            {
		                maxArea = area+1;
		            }
		        }
		    }

		    return maxArea;
		}

	    public int GetArea(List<(int, Coordinate)> closestCoordinates, Coordinate coordinate)
	    {
	        var area = 0;

	        foreach (var point in closestCoordinates)
	        {
	            var startX = coordinate.X < point.Item2.X ? coordinate.X : point.Item2.X;
	            for (int i = 0; i <= Math.Abs(point.Item2.X - coordinate.X); i++)
	            {
	                var startY = coordinate.Y <= point.Item2.Y ? coordinate.Y : point.Item2.Y;
	                for (int j = 0; j < Math.Abs(point.Item2.Y - coordinate.Y); j++)
	                {
	                    var middlePoint = new Coordinate { X = startX + i, Y = startY + j };
	                    if (CalculateManhattanDistance(middlePoint, coordinate) < CalculateManhattanDistance(middlePoint, point.Item2))
	                    {
	                        area += 1;
	                    }
                    }
                }
            }

	        return area;
	    }

	    //public int GetArea(List<(int, Coordinate)> closestCoordinates, Coordinate coordinate)
	    //{
	    //    var area = 0;

	    //    foreach (var point in closestCoordinates)
	    //    {
	    //        var startX = coordinate.X;
	    //        for (int i = 0; i < ; i++)
	    //        {
	    //            var startY = coordinate.Y;
	    //            for (int j = 0; j < Math.Abs(point.Item2.Y - startY); j++)
	    //            {
	    //                var middlePoint = new Coordinate {X = point.Item2.X + i, Y = point.Item2.Y + j};

	    //                if (GetManhattanDistance(middlePoint, coordinate)) < GetManhattanDistance(middlePoint, point.Item2))
	    //                {

	    //                }
	    //            }
	    //        }
	    //    }
	    //    return area;
	    //}



	    public List<(int,Coordinate)> GetClosestCoordinates(List<Coordinate> coordinates,Coordinate coordinate)
		{
            var distances = new List<(int, Coordinate)>();
		    var area = 0;

		    //coordinates.Remove(coordinate);
		    foreach (var c in coordinates)
		    {
		        if (c != coordinate)
		        {
		            int distance = CalculateManhattanDistance(c, coordinate);
		            if (distance != 0)
		            {
		                distances.Add((distance, c));
                    }
                    
		        }
            }

		    distances = distances.OrderBy(d => d.Item1).ToList();

		    return distances.Take(4).ToList();
		}

	    public int CalculateManhattanDistance(Coordinate coordinate1, Coordinate coordinate2)
	    {
	        decimal distance = (Math.Abs(coordinate1.X - coordinate2.X) + Math.Abs(coordinate1.Y - coordinate2.Y)) / 2;
            return Convert.ToInt32(Math.Floor(distance));

        }

	}

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
