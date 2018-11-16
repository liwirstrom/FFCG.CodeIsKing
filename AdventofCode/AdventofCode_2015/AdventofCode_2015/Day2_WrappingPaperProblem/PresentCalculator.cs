using System.Collections.Generic;
using System.Linq;

namespace Day2_WrappingPaperProblem
{
    public class PresentCalculator
    {
        public int CalculateSquareBoxAmount(List<string> inputsize)
        {
            var amount = 0;
            var dimensions = inputsize.Select(int.Parse).ToList();

            var sideAreas = new List<int>();
            sideAreas.Add(dimensions[0] * dimensions[1]);
            sideAreas.Add(dimensions[0] * dimensions[2]);
            sideAreas.Add(dimensions[1] * dimensions[2]);

            sideAreas.Sort();

            foreach (var sideArea in sideAreas)
            {
                amount += sideArea * 2;
            }

            sideAreas.Sort();

            amount += sideAreas[0];

            return amount;
        }

        public int CalculateRibbonAmount(List<string> inputsize)
        {
            var length = 0;
            var dimensions = inputsize.Select(int.Parse).ToList();
            dimensions.Sort();

            length = dimensions.Aggregate(1, (a,b) => a*b);

            length += 2 * dimensions[0] + 2 * dimensions[1];

            return length;
        }
    }
}