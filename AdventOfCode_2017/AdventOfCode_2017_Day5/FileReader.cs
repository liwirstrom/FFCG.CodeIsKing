using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2017_Day5
{
    public class FileReader
    {
        public List<int> ReadFile(string fileName)
        {
            List<int> instructions = new List<int>();
            foreach (var line in File.ReadLines(fileName))
            {
                instructions.Add(Int32.Parse(line));
            }

            return instructions;
        }
    }
}
