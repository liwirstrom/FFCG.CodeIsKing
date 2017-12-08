using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2017_Day8
{
    public class RegisterHandler
    {
        public List<Register> PerformRegisterInstructions(string fileName)
        {
            List<Register> registry = new List<Register>();
            Register highestValue = new Register("HighestHeldValue");
            foreach (var line in File.ReadAllLines(fileName))
            {
                string[] registerInstruction = line.Split(null);
                registry = registerExists(registerInstruction[0], registry);
                registry = registerExists(registerInstruction[4], registry);

                if (
                    Compare(registerInstruction[5],
                    registry.First(r => r.Name == registerInstruction[4]).Value,
                    int.Parse(registerInstruction[6])))
                {
                    if (registerInstruction[1] == "inc")
                    {
                        registry.First(r => r.Name == registerInstruction[0]).Value += int.Parse(registerInstruction[2]);
                    }
                    else
                    {
                        registry.First(r => r.Name == registerInstruction[0]).Value -= int.Parse(registerInstruction[2]);
                    }
                }

                if (registry.OrderByDescending(r => r.Value).First().Value > highestValue.Value)
                {

                    highestValue.Value = registry.OrderByDescending(r => r.Value).First().Value;
                }
            }

            registry.Add(highestValue);
            return registry;
        }

        private List<Register> registerExists(string registerName, List<Register> registry)
        {
            if (registry.Where(r => r.Name == registerName).ToList().Count() == 0)
            {
                registry.Add(new Register(registerName));
            }

            return registry;
        }

        public static bool Compare(string condition, int x, int y)
        {
            switch (condition)
            {
                case "==": return x.CompareTo(y) == 0;
                case "!=": return x.CompareTo(y) != 0;
                case ">": return x.CompareTo(y) > 0;
                case ">=": return x.CompareTo(y) >= 0;
                case "<": return x.CompareTo(y) < 0;
                case "<=": return x.CompareTo(y) <= 0;
            }
            return false;
        }

            public int GetHighestRegisterValue(List<Register> registry)
        {
            Register highestValueRegister = registry.OrderByDescending(r => r.Value).ElementAt(1);
            return highestValueRegister.Value;
        }

    }
}
