using Passphrases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            List<List<string>> passPhraseList = fileReader.ReadFile(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\Day4\inputfile");
            CheckPassphrase checkPassphrase = new CheckPassphrase();
            int validPassphrases = checkPassphrase.NoDuplicates(passPhraseList);
            Console.WriteLine(validPassphrases);
            Console.ReadKey();

            //List<string> passphrase = new List<string> { "abcde", "fghij" };
            //bool isDistinct = checkPassphrase.NotAnagram(passphrase);
        }
    }
}
