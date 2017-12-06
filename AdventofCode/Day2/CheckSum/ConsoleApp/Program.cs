using CheckSum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            List<List<double>> inputList = fileReader.ReadFile(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\Day2\inputData.txt");
            Calculator calculator = new CheckSum.Calculator();
            double answer = calculator.FindWholeDivision(inputList);
            Console.WriteLine(answer);
        }
    }
}
