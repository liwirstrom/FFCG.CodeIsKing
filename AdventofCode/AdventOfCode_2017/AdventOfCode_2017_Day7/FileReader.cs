using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2017_Day7
{
    public class FileReader
    {
        public List<ProgramModel> ReadFile(string fileName)
        {
            List<ProgramModel> programList = new List<ProgramModel>();
            foreach (var line in File.ReadAllLines(fileName))
            {
                string[] programInfo = line
                                        .Replace("(", "")
                                        .Replace(")", "")
                                        .Replace(",", "")
                                        .Split(null);
                if (programInfo.Count() > 2 )
                {
                    ProgramModel program = new ProgramModel();
                    program.Name = programInfo[0];
                    program.Weight = int.Parse(programInfo[1]);
                    for (int i = 3; i < programInfo.Count(); i++)
                    {
                        program.ImmediatelyAbove.Add(programInfo[i]);
                    }

                    programList.Add(program);
                }
                else
                {
                    ProgramModel program = new ProgramModel();
                    program.Name = programInfo[0];
                    program.Weight = int.Parse(programInfo[1]);
                    programList.Add(program);
                }
            }

            foreach (var program in programList)
            {
                if (programList.Where(p => p.ImmediatelyAbove.Contains(program.Name)).FirstOrDefault() != null)
                {
                    program.ImmediatelyBelow = programList.Where(p => p.ImmediatelyAbove.Contains(program.Name)).FirstOrDefault().Name ;
                }
            }

            return programList;
        }
    }
}
