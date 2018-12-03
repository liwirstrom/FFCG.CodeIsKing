using System;
using System.Collections.Generic;

namespace AdventOfCode_2018_Day1_Test
{
    public class FrequencyCalculator
    {
        public int FindFrequency(int startFrequency, List<string> input)
        {
            var currentFrequency = startFrequency;
            foreach (var change in input)
            {
                currentFrequency = ChangeFrequency(currentFrequency, change);
            }

            return currentFrequency;
        }

        public int FindDuplicate(int currentFrequency, List<string> input)
        {
            var frequencies = new Dictionary<int,int>();
            frequencies[currentFrequency] = currentFrequency;
            var foundDuplicate = false;
            while (!foundDuplicate)
            {
                foreach (var change in input)
                {
                    currentFrequency = ChangeFrequency(currentFrequency, change);
                    if (frequencies.ContainsKey(currentFrequency))
                    {
                        foundDuplicate = true;
                        break;
                    }

                    frequencies[currentFrequency] = currentFrequency;
                }
            }

            return currentFrequency;

        }

        private int ChangeFrequency(int currentFrequency, string instruction)
        {
            var frequency = Convert.ToInt32(instruction.Substring(1, instruction.Length - 1));
            if (instruction[0] == '+')
            {
                currentFrequency += frequency;
            }
            else
            {
                currentFrequency -= frequency;
            }

            return currentFrequency;
        }
    }
}