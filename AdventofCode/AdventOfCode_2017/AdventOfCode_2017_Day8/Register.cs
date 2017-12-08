using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2017_Day8
{
    public class Register
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Register(string name)
        {
            Name = name;
            Value = 0;
        }
    }
}
