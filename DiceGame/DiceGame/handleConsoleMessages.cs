using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public class HandleConsoleMessages
    {
        public Boolean InputWasCorrect(string input)
        {
            Boolean result;
            int sides;
            if (int.TryParse(input, out sides))
            {
                result = sides >= 3 ? result = true : result = false;
                return result;
            }

            return false;
        }
    }
}
