using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{

    public interface IFloorCalculator
    {
        int GetFloor(string instructions);
    }

    public enum Instruction
    {
        MoveUp,
        MoveDown
    }

    public class Day1_FloorCalculator : IFloorCalculator
    {
        public int GetFloor(string instructions)
        {
            var floor = 0;

            var instructionlist = instructions.ToCharArray();

            foreach (var i in instructionlist)
            {
                floor = CalculateFloor(floor, i);
            }

            return floor;
        }

        public int GetFirstBasementCharacter(string instructions)
        {
            var floor = 0;
            var index = 1;
            var instructionlist = instructions.ToCharArray();

            foreach (var i in instructionlist)
            {
                floor = CalculateFloor(floor, i);
                if (floor == -1)
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        private int CalculateFloor(int floor, char instruction)
        {
            if (instruction == '(')
            {
                floor += 1;
            }

            else if (instruction == ')')
            {
                floor -= 1;
            }

            return floor;
        }

    }
}
