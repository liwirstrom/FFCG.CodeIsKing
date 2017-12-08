using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2017_Day7
{
    public class ProgramModel
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<string> ImmediatelyAbove { get; set; }
        public string ImmediatelyBelow { get; set; }

        public int HoldingWeight { get; set; }

        public ProgramModel()
        {
            Name = "";
            Weight = 0;
            ImmediatelyAbove = new List<string>();
            ImmediatelyBelow = "";
            HoldingWeight = 0;
        }
    }
}
