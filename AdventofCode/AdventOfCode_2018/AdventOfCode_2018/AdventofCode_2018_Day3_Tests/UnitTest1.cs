using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventofCode_2018_Day3_Tests
{
    [TestClass]
    public class UnitTest1
    {
	    private ClaimCalculator _claimCalculator;

	    [TestInitialize]
	    public void Setup()
	    {
			_claimCalculator = new ClaimCalculator();
	    }

	    [TestMethod]
	    public void Should_Draw()
	    {
		    var input = new List<string> { "#1 @ 1,3: 4x4" };

		    var elfClaim = new ElfClaim(input[0]);

			Assert.AreEqual(elfClaim.Id, 1);
		    Assert.AreEqual(elfClaim.Coordinate.X, 1);
		    Assert.AreEqual(elfClaim.Coordinate.Y, 3);
			Assert.AreEqual(elfClaim.Height, 4);
			Assert.AreEqual(elfClaim.Width, 4);
		}

		[TestMethod]
	    public void Should_Calculate_Area()
	    {
		    var input = new List<string> { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };

		    var elfClaims = new List<ElfClaim>();

		    foreach (var claim in input)
		    {
				elfClaims.Add(new ElfClaim(claim));   
		    }

		    var overlap = _claimCalculator.GetOverlap(elfClaims).Count(c => c.Value > 1);

			Assert.AreEqual(4, overlap);
	    }

	    [TestMethod]
	    public void Answer_Input_part1()
	    {
		    var input = File.ReadAllLines("../../Day3_input.txt");

		    var elfClaims = new List<ElfClaim>();

		    var expected = new int[,] { { 1, 3 }, { 2, 3 }, { 1, 4 }, { 2, 4 } };
		    foreach (var claim in input)
		    {
			    elfClaims.Add(new ElfClaim(claim));
		    }

		    var overlap = _claimCalculator.GetOverlap(elfClaims).Count(c => c.Value > 1);

		    Assert.AreEqual(111266, overlap);
	    }

		[TestMethod]
	    public void Should_Be_Intact ()
	    {
		    var input = new List<string> { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };

		    var elfClaims = new List<ElfClaim>();

		    foreach (var claim in input)
		    {
			    elfClaims.Add(new ElfClaim(claim));
		    }

		    var overlapDictionary = _claimCalculator.GetOverlap(elfClaims);

		    int intact = _claimCalculator.FindIntact(elfClaims, overlapDictionary);

		    Assert.AreEqual(3, intact );
	    }

	    [TestMethod]
	    public void Answer_Input_part2()
	    {
			//var input = new List<string> { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };
		    var input = File.ReadAllLines("../../Day3_input.txt");

			var elfClaims = new List<ElfClaim>();

		    foreach (var claim in input)
		    {
			    elfClaims.Add(new ElfClaim(claim));
		    }

		    var overlapDictionary = _claimCalculator.GetOverlap(elfClaims);

		    int intact = _claimCalculator.FindIntact(elfClaims, overlapDictionary);

		    Assert.AreEqual(266, intact);
	    }

	}

	public class ClaimCalculator
	{
		public Dictionary<string, int> GetOverlap(List<ElfClaim> elfClaims)
		{
			var claimedFabric = new Dictionary<string, int>();
			foreach (var elfClaim in elfClaims)
			{
				var startX = elfClaim.Coordinate.X;
				for (int i = 0; i < elfClaim.Height; i++)
				{
					var startY = elfClaim.Coordinate.Y;
					for (int j = 0; j < elfClaim.Width; j++)
					{
						var key = $"{startX+i},{startY+j}";
						if (claimedFabric.ContainsKey(key))
						{
							claimedFabric[key] += 1;
						}
						else
						{
							claimedFabric[key] = 1;
						}
					}	
				}
			}

			return claimedFabric;
			
		}

		public int FindIntact(List<ElfClaim> elfClaims, Dictionary<string, int> claimedFabric)
		{
			var claimId = 0;

			foreach (var elfClaim in elfClaims)
			{
				var intact = true;

				var startX = elfClaim.Coordinate.X;
				for (int i = 0; i < elfClaim.Height; i++)
				{
					var startY = elfClaim.Coordinate.Y;
					for (int j = 0; j < elfClaim.Width; j++)
					{
						var key = $"{startX + i},{startY + j}";
						if (claimedFabric[key] > 1)
						{
							intact = false;
						}
					}
				}

				if (intact)
				{
					claimId = elfClaim.Id;
				}
			}

			return claimId;
		}
	}


	public class ElfClaim
	{
		public ElfClaim(string claim)
		{
			var splittedClaim = claim.Split(' ');
			Id = int.Parse(splittedClaim[0].Replace("#", ""));
			Coordinate.X = int.Parse(splittedClaim[2].Split(',')[0]);
			Coordinate.Y = int.Parse(splittedClaim[2].Split(',')[1].Replace(":", ""));
			Height = int.Parse(splittedClaim[3].Split('x')[0]);
			Width = int.Parse(splittedClaim[3].Split('x')[1]);

		}

		public int Id { get; private set; }
		public int Height { get; private set; }
		public int Width { get; private set; }
		public Coordinate Coordinate { get; private set; } = new Coordinate();
	}

	public class Coordinate
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
