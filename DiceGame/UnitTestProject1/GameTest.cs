using DiceGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void GameOverShouldBeFalse()
        {
            MockRandom random = new MockRandom(1, 6);
            Dice dice = new Dice(6,random);
            Game game = new Game(dice, 1);
            Boolean GameOver = game.GuessWasCorrect("higher");
            Assert.IsFalse(GameOver);
        }

        [TestMethod]
        public void GameOverShouldBeTrue()
        {
            MockRandom random = new MockRandom(1, 7);
            Dice dice = new Dice(3, random);
            Game game = new Game(dice, 6);
            Boolean GameOver = game.GuessWasCorrect("lower");
            Assert.IsTrue(GameOver);
        }
    }
}
