using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckSum
{
    public class Calculator
    {
        public int FindHighestDifferencde(List<List<int>> rowsList)
        {
            int checkSum = 0;
            foreach (var list in rowsList)
            {

                int highestValue = list.OrderByDescending(x => x).FirstOrDefault();
                int lowestValue = list.OrderBy(x => x).FirstOrDefault();
                checkSum += highestValue - lowestValue;
            }

            return checkSum;
        }

        public double FindWholeDivision(List<List<double>> rowsList)
        {
            double checkSum = 0;
            int counter = 0;
            foreach (var list in rowsList)
            {
                foreach (var number in list)
                {
                    for (int i = 0; i < list.Count(); i++)
                    {
                        if (i != counter)
                        {
                            if ((number / list[i]) % 1 == 0)
                            {
                                checkSum += number / list[i];
                            }
                        }
                    }
                counter++;
                }
                counter = 0;
            }
            return checkSum;
        }
    }
}
