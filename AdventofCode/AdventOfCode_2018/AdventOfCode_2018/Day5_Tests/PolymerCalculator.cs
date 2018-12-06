using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day5_Tests
{
    public class PolymerCalculator
    {
        public List<char> React(string input)
        {
            var reactionDone = false;
            var units = input.ToList();
            var tempChar = units;
            while (!reactionDone && units.Count != 0 )
            {
                reactionDone = true;
                units = tempChar;
                var list_size = units.Count;
                var i = 0;
                while (true)
                {
                    if ((Char.IsUpper(units[i]) && Char.ToLower(units[i]) == units[i + 1]) ||
                        (Char.IsLower(units[i]) && Char.ToUpper(units[i]) == units[i + 1]))
                    {
                        reactionDone = false;
                        units.RemoveAt(i);
                        units.RemoveAt(i);
                        list_size -= 2;
                        i -= 1;
                    }
                    else
                    {
                        tempChar[i] = units[i];
                    }
                    i++;
                    if (i >= list_size-1) break;
                }
            }

            return units;

        }

        public int ForceReact(string input)
        {
            var smallestPolymer = Int32.MaxValue;
            var unitTypes = input.ToLower().GroupBy(x => x).ToList();
            foreach (var unitType in unitTypes)
            {

                var modifiedPolymer = RemoveUnwantedChar(input, unitType.Key);
                var newPolymer = React(modifiedPolymer);
                if (newPolymer.Count < smallestPolymer)
                {
                    smallestPolymer = newPolymer.Count;
                }
				
            }

            return smallestPolymer;
        }

        private string RemoveUnwantedChar(string input, char unwantedChar)
        {

            StringBuilder builder = new StringBuilder(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (char.ToLower(input[i]) != unwantedChar)
                {
                    builder.Append(input[i]);
                }
            }
            return builder.ToString();
        }
    }
}