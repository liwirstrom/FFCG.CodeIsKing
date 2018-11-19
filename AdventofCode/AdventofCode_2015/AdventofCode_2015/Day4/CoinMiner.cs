using System;
using System.Security.Cryptography;
using System.Text;

namespace Day4
{
    public class CoinMiner
    {
        public int Mine(string input, int nrOfZeroes)
        {
            var hash = "";
            var number = 1;
            var find = new String('0', nrOfZeroes);

            var stringBuilder = new StringBuilder();

            using (MD5 md5 = MD5.Create())
            {
                while (!hash.StartsWith(find))
                {
                    number++;
                    var concatString = $"{input}{number}";
                    var bytesArray = Encoding.ASCII.GetBytes(concatString);
                    var hashArray = md5.ComputeHash(bytesArray);
                    foreach (var b in hashArray)
                    {
                        stringBuilder.Append(b.ToString("X2"));
                    }

                    hash = stringBuilder.ToString();
                    stringBuilder.Clear();
                }
            }

            return number;
        }
    }
}