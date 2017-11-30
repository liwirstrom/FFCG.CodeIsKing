using System;

namespace DiceGame
{
    public class Game
    {
        private int LastThrow { get; set; }
        private int Points { get; set; }
        private Dice Dice;
        public Boolean GameOver { get; }


        public Game(Dice dice)
        {
            Dice = dice;
            Points = 0;

        }

        public Boolean GuessWasCorrect(string guess, int diceResult)
        {
            Boolean correctGuess = false;
            switch (guess)
            {
                case "higher":
                    correctGuess = diceResult > LastThrow ? correctGuess = true : correctGuess = false;
                    LastThrow = diceResult;
                    break;
                case "lower":
                    correctGuess = diceResult < LastThrow ? correctGuess = true : correctGuess = false;
                    LastThrow = diceResult;
                    break;
                default:
                    break;
            }
            if (correctGuess == true)
            {
                ++Points;
            }
            return correctGuess;
        }

        public void setLastValue(int startValue)
        {
            LastThrow = startValue;
        }

        public int getPoints()
        {
            return Points;
        }
    }
}
