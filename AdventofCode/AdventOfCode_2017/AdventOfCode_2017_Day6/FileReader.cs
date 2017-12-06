using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode_2017_Day6_
{
    public class FileReader
    {
        public List<int> ReadFile(string fileName)
        {
            List<int> memoryBank = new List<int>();
            foreach (var line in File.ReadLines(fileName))
            {
                //List<string> rowIntegers = new List<string>();
                //string cleanedLine = line.Replace("\t", " ");
                //while (cleanedLine.IndexOf("  ") > 0)
                //{
                //    cleanedLine = line.Replace("  ", " ");
                //}
                memoryBank = line.Split(null).Select(Int32.Parse).ToList();
            }

            return memoryBank;
        }
    }
}
