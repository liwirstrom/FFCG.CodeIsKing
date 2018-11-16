using System.Collections.Generic;
using System.Linq;

namespace AdventofCode_2015_Day3
{
    public class DeliveryCalculator
    {
        private int _xCoord;
        private int _yCoord;

        public int GetNumberOfHouses(List<string> instructions, int nrOfSantas)
        {
            var houseList = new List<string>();
            houseList.Add("0,0");

            var instructionsList = instructions[0].ToCharArray();

            for (int i = 0; i < nrOfSantas; i++)
            {
                _xCoord = 0;
                _yCoord = 0;
                var santaInstructions = instructionsList.Where((instruction, index) => index % nrOfSantas == i);

                foreach (var instruction in santaInstructions)
                {
                    MoveSanta(instruction);
                    houseList.Add($"{_xCoord},{_yCoord}");
                }
            }

            houseList = houseList.Distinct().ToList();

            return houseList.Count;
        }
        
        private void MoveSanta(char s)
        {
            if (s == '>')
            {
                _xCoord += 1;
            }

            else if (s == '<')
            {
                _xCoord -= 1;
            }

            else if (s == '^')
            {
                _yCoord += 1;
            }

            else if (s == 'v')
            {
                _yCoord -= 1;
            }
        }
    }
}