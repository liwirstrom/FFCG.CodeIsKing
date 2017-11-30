using System;

namespace DiceGame
{
    public class Dice
    {
        private int _sidesOfDice { get; set; }
        private IRandom _random;

        public Dice(int diceSize, IRandom random)
        {
            _sidesOfDice = diceSize;
            _random = random;
        }

        public int throwDice()
        {
            
            return _random.GetRandom();
        }
    }
}
