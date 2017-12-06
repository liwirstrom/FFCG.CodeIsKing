using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Passphrases
{
    public class FileReader
    {
        public List<List<string>> ReadFile(string file)
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
                string[] rowArray = cleanedLine.Split(null);
                List<string> passphrase = rowArray.ToList<string>();
                input.Add(passphrase);

            }
            return input;
        }
    }
}
