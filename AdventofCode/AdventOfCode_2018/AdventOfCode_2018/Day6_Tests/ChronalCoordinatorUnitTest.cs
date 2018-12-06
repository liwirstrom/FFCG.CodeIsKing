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
		public void Should_Be_Area_17()
		{
		    var input = File.ReadAllLines("../../Unittest_input.txt").ToList();
			var biggestArea = _coordinator.GetBiggestArea(input);

            Assert.AreEqual(17, biggestArea);

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
		            var area = CalculatePolygonArea(coordinates, coordinates[i]);
		            if (area > maxArea)
		            {
		                maxArea = area+1;
		            }
		        }
		    }

		    return maxArea;
		}

		private int CalculatePolygonArea(List<Coordinate> coordinates,Coordinate coordinate)
		{
            var distances = new List<(int, Coordinate)>();
		    var area = 0;

		    coordinates.Remove(coordinate);
		    foreach (var c in coordinates)
		    {
		        if (c != coordinate)
		        {
		            decimal distance = (Math.Abs(c.X - coordinate.X) + Math.Abs(c.Y - coordinate.Y))/2;

                    distances.Add((Convert.ToInt32(Math.Floor(distance)), c));
		        }
            }

		    distances = distances.OrderBy(d => d.Item1).ToList();
		    for (int i = 0; i < 4; i++)
		    {
		        if (i == 3)
		        {
		            area += distances[i].Item2.X * distances[0].Item2.Y - distances[i].Item2.Y * distances[0].Item2.X;
		        }
		        else
		        {
		            area += distances[i].Item2.X * distances[i+1].Item2.Y - distances[i].Item2.Y * distances[i + 1].Item2.X;
                }
		    }

		    return Convert.ToInt32(Math.Abs(area/2));
		}

	}

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
