using System;

namespace DiceGame
{
    public class Game
    {
        public int LastThrow { get; private set; }
        public int Points { get; private set; }
        private Dice _dice;
        public Boolean GameOver { get; private set; }


        public Game(Dice dice, int startvalue)
        {
            _dice = dice;
            Points = 0;
            LastThrow = startvalue;
            GameOver = false;
        }

        public bool GuessWasCorrect(string guess)
        {
            int diceResult = _dice.throwDice();
            if (diceResult == LastThrow)
            {
                return false;
            }
            switch (guess)
            {
                case "higher":
                    GameOver = diceResult > LastThrow ?  false : true;
                    LastThrow = diceResult;
                    break;
                case "lower":
                    GameOver = diceResult < LastThrow ? false : true;
                    LastThrow = diceResult;
                    break;
                default:
                    break;
            }
            if (GameOver == false)
            {
                addPoints();
            }
            return GameOver;
        }

        private void addPoints()
        {
            ++Points;
        }

        public int getLastThrow()
        {
            return LastThrow;
        }

        public int getPoints()
        {
            return Points;
        }

        public Boolean getGameOver()
        {
            return GameOver;
        }
    }
}
