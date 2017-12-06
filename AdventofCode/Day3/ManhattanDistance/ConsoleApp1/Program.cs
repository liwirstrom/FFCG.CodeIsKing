using SpiralGridModell;
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
            SpiralGridModel gridModel = new SpiralGridModel();
            Console.WriteLine("created gridmodel");
            NumberModel number = gridModel.FindPosition(289326);
            Console.WriteLine("Done findPosition");
            int steps = gridModel.GetDistance(number);
            Console.WriteLine(steps);
            Console.ReadKey();
        }
    }
}
