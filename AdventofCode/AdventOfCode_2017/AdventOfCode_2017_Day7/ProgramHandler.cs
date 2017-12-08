using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2017_Day7
{
    public class ProgramHandler
    {
        public List<ProgramModel> _programList { get; set; }

        public ProgramHandler(List<ProgramModel> programList)
        {
            _programList = programList;
        }
        public string GetBottom(List<ProgramModel> programList)
        {
            return programList.Where(p => p.ImmediatelyBelow == "").FirstOrDefault().Name;
        }

        public int GetHoldingWeight(string root)
        {
            ProgramModel rootProgram = _programList.Where(p => p.Name == root).FirstOrDefault();
            rootProgram.HoldingWeight = CalculateHoldingWeight(rootProgram);
            return rootProgram.HoldingWeight;
        }

        private int CalculateHoldingWeight(ProgramModel rootProgram)
        {
            if (rootProgram.ImmediatelyAbove.Count() > 0)
            {
                foreach (var program in rootProgram.ImmediatelyAbove)
                {
                    rootProgram.HoldingWeight += CalculateHoldingWeight(_programList.FirstOrDefault(p => p.Name == program));
                }
            }

            return rootProgram.Weight + rootProgram.HoldingWeight;
        }
    }
}
