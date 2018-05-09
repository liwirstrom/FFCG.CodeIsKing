using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using FFCG.BowlingGame.Logic;

namespace FFCG.BowlingGame.Test
{
	[TestFixture]
	public class BowlingGameTester
	{
		private BowlingGameRound _bowlingGame;

		[SetUp]
		public void SetUp()
		{
			_bowlingGame = new BowlingGameRound();
		}

		[TestCase()]
		public void Gutter_Game_Should_Be_Zero_Points()
		{

			RollMany(20,0);
			Assert.AreEqual(0, _bowlingGame.CalculateTotalScore());
		}

		[TestCase()]
		public void All_Ones_Should_Equal_20()
		{
			RollMany(20, 1);
			Assert.AreEqual(20, _bowlingGame.CalculateTotalScore());
		}

		[TestCase()]
		public void Test_One_Spare()
		{
			_bowlingGame.Roll(5);
			_bowlingGame.Roll(5);
			_bowlingGame.Roll(3);
			RollMany(17, 0);
			Assert.AreEqual(16, _bowlingGame.CalculateTotalScore());
		}

		[TestCase()]
		public void Strike_In_Last_Frame_Should_Have_Three_Rolls()
		{
			RollMany(18,0);
			_bowlingGame.Roll(10);
			_bowlingGame.Roll(8);
			_bowlingGame.Roll(5);
			Assert.AreEqual(23, _bowlingGame.CalculateTotalScore());
		}

		[TestCase()]
		public void Spare_In_Last_Frame_Should_Have_Three_Rolls()
		{
			RollMany(18, 0);
			_bowlingGame.Roll(5);
			_bowlingGame.Roll(5);
			_bowlingGame.Roll(5);
			Assert.AreEqual(15, _bowlingGame.CalculateTotalScore());
		}

		[TestCase()]
		public void Last_Frame_Should_Not_Have_Three_Rolls()
		{
			RollMany(20, 0);
			_bowlingGame.Roll(10);
			Assert.AreEqual(0, _bowlingGame.CalculateTotalScore());
		}

		[TestCase()]
		public void Test_One_Strike()
		{
			_bowlingGame.Roll(10);
			_bowlingGame.Roll(3);
			_bowlingGame.Roll(4);
			RollMany(16,0);
			Assert.AreEqual(24, _bowlingGame.CalculateTotalScore());
		}

		[TestCase()]
		public void Test_Turkey()
		{
			RollMany(3,10);
			RollMany(14, 0);
			Assert.AreEqual(60, _bowlingGame.CalculateTotalScore());
		}


		[TestCase()]
		public void Test_Perfect_Game()
		{
			RollMany(12, 10);
			Assert.AreEqual(300, _bowlingGame.CalculateTotalScore());
		}

		private void RollMany(int throws, int pins)
		{
			for (int i = 0; i < throws; i++)
			{
				_bowlingGame.Roll(pins);
			}
		}
	}
}
