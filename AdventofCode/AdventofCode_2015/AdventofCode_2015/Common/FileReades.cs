using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    public class FileReader
    {
        public List<List<string>> ReadFile(string file)
        {
            List<List<string>> input = new List<List<string>>();
            foreach (var line in File.ReadLines(file))
            {
                string cleanedLine = line.Replace("\t", " ");
                while (cleanedLine.IndexOf("  ") > 0)
                {
                    cleanedLine = line.Replace("  ", " ");
                }

                string[] rowArray = cleanedLine.Split(null);
                List<string> row = rowArray.ToList<string>();
                input.Add(row);

            }

            return input;
        }

        public List<List<string>> ReadFileWithSeparator(string file, char separator)
        {
            List<List<string>> input = new List<List<string>>();
            foreach (var line in File.ReadLines(file))
            {
                List<string> rowIntegers = new List<string>();
                string cleanedLine = line.Replace("\t", " ");
                while (cleanedLine.IndexOf("  ") > 0)
                {
                    cleanedLine = line.Replace("  ", " ");
                }

                string[] rowArray = cleanedLine.Split(separator);
                List<string> row = rowArray.ToList<string>();
                input.Add(row);

            }

            return input;
        }
    }
}