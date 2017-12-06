using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2017_Day5
{
    public class EscapeMaze
    {
        public int Jump(List<int> instructions)
        {
            int position = 0;
            int steps = 0;

            while (true)
            {
                if (position > instructions.Count()-1)
                {
                    return steps;
                }
                else
                {
                    var stepsToTake = instructions[position];
                    instructions[position]++;
                    position += stepsToTake;
                    steps++;
                }
            }
        }

        public int JumpAndDecreaseAbove2(List<int> instructions)
        {
            int position = 0;
            int steps = 0;

            while (true)
            {
                if (position > instructions.Count() - 1)
                {
                    return steps;
                }
                else
                {
                    var stepsToTake = instructions[position];
                    instructions[position]+= instructions[position] >= 3 ? -1: 1;
                    position += stepsToTake;
                    steps++;
                }
            }

        }
    }
}
