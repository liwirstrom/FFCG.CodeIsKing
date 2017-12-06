using System;
using System.Collections.Generic;
using System.IO;

namespace CheckSum
{
    public interface IReader
    {
        List<List<double>> ReadFile(string s);
    }

    public class FileReader : IReader
    {
        public List<List<double>> ReadFile(string file)
        {
            List<List<double>> input = new List<List<double>>();
            foreach (var line in File.ReadLines(file))
            {
                List<double> rowIntegers = new List<double>();
                string cleanedLine = line.Replace("\t", " ");
                while (cleanedLine.IndexOf("  ") > 0)
                {
                    cleanedLine = line.Replace("  ", " ");
                }
                string[] rowArray = cleanedLine.Split(null);

                foreach (var numberString in rowArray)
                {
                    double number = Convert.ToDouble(numberString);
                    rowIntegers.Add(number);
                }
                input.Add(rowIntegers);
            }
            return input;
        }
    }
}
