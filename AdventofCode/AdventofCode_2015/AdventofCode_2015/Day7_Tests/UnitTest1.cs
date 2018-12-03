using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day7_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private BitwiseAssembler _bitwiseAssembler;

        [TestInitialize]
        public void Setup()
        {
            _bitwiseAssembler = new BitwiseAssembler();
        }

        [TestMethod]
        public void Should_assign_signal_part1()
        {
            var instructions = new List<string>{ "123 -> x" };
            var wireDictionary = _bitwiseAssembler.ExecuteInstructions(instructions);
            Assert.IsTrue(wireDictionary.Count == 1);
            Assert.IsTrue(wireDictionary.ContainsKey("x"));
            Assert.AreEqual(123, wireDictionary["x"]);
        }

        [TestMethod]
        public void Should_execute_NOT_part1()
        {
            var instructions = new List<string> { "123 -> x", "NOT x -> h" };
            var wireDictionary = _bitwiseAssembler.ExecuteInstructions(instructions);
            Assert.IsTrue(wireDictionary.Count == 2);
            Assert.IsTrue(wireDictionary.ContainsKey("h"));
            Assert.AreEqual(65412, wireDictionary["h"]);
        }

        [TestMethod]
        public void Should_execute_OR_part1()
        {
            var instructions = new List<string>{"123 -> x", "456 -> y", "x OR y -> e"};
            var wireDictionary = _bitwiseAssembler.ExecuteInstructions(instructions);
            Assert.IsTrue(wireDictionary.ContainsKey("e"));
            Assert.AreEqual(507, wireDictionary["e"]);
        }

        [TestMethod]
        public void Should_execute_LShift_part1()
        {
            var instructions = new List<string> { "123 -> x", "x LSHIFT 2 -> f" };
            var wireDictionary = _bitwiseAssembler.ExecuteInstructions(instructions);
            Assert.AreEqual(492, wireDictionary["f"]);
        }

        [TestMethod]
        public void Should_execute_RShift_part1()
        {
            var instructions = new List<string> { "456 -> y","y RSHIFT 2 -> g" };
            var wireDictionary = _bitwiseAssembler.ExecuteInstructions(instructions);
            Assert.AreEqual(114, wireDictionary["g"]);
        }

        [TestMethod]
        public void Should_execute_AND_part1()
        {
            var instructions = new List<string>{ "123 -> x", "456 -> y", "x AND y -> d" };
            var wireDictionary = _bitwiseAssembler.ExecuteInstructions(instructions);
            Assert.IsTrue(wireDictionary.Count == 3);
            Assert.IsTrue(wireDictionary.ContainsKey("d"));
            Assert.AreEqual(72, wireDictionary["d"]);
        }


        [TestMethod]
        public void Answer_input_part1()
        {
            var instructions = File.ReadAllLines("../../../Day7_input.txt").ToList();
            var wireDictionary = _bitwiseAssembler.ExecuteInstructions(instructions);
            Assert.AreEqual(46065, wireDictionary["a"]);
        }

        [TestMethod]
        public void Answer_input_part2()
        {
            var instructions = File.ReadAllLines("../../../Day7_input.txt").ToList();
            var wireDictionary = _bitwiseAssembler.ExecuteInstructions(instructions);

            for (int i = 0; i < instructions.Count; i++)
            {
                if (instructions[i].EndsWith("-> b"))
                {
                    instructions[i] = $"{wireDictionary["a"]} -> b";
                }
            }
            wireDictionary = _bitwiseAssembler.ExecuteInstructions(instructions);
            Assert.AreEqual(14134, wireDictionary["a"]);
        }

    }

    public class BitwiseAssembler
    {
        private Dictionary<string,ushort> _wireDictionary;

        public Dictionary<string, ushort> ExecuteInstructions(List<string> instructions)
        {
            _wireDictionary = new Dictionary<string, ushort>();

            bool allDone = false;
            while (!allDone)
            {
                allDone = true;

                foreach (var instruction in instructions)
                {
                    var splitInstructions = instruction.Split(' ');
                    var toWire = splitInstructions[splitInstructions.Length - 1];
                    ushort wire1, wire2;
                    if (splitInstructions.Contains("NOT"))
                    {
                        if (GetValue(splitInstructions[1], out wire1))
                        {
                            _wireDictionary[toWire] = (ushort) (int) (~wire1);
                        }
                        else
                        {
                            allDone = false;
                        }
                    }

                    else if (splitInstructions.Contains("AND"))
                    {
                        if (GetValue(splitInstructions[0], out wire1) && GetValue(splitInstructions[2], out wire2))
                        {
                            _wireDictionary[toWire] = (ushort) (wire1 & wire2);
                        }
                        else
                        {
                            allDone = false;
                        }
                    }

                    else if (splitInstructions.Contains("OR"))
                    {

                        if (GetValue(splitInstructions[0], out wire1) && GetValue(splitInstructions[2], out wire2))
                        {
                            _wireDictionary[toWire] = (ushort) (wire1 | wire2);
                        }
                        else
                        {
                            allDone = false;
                        }
                    }

                    else if (splitInstructions.Contains("LSHIFT"))
                    {
                        if (GetValue(splitInstructions[0], out wire1))
                        {
                            _wireDictionary[toWire] = (ushort) (wire1 << ushort.Parse(splitInstructions[2]));
                        }
                        else
                        {
                            allDone = false;
                        }

                    }

                    else if (splitInstructions.Contains("RSHIFT"))
                    {
                        if (GetValue(splitInstructions[0], out wire1))
                        {
                            _wireDictionary[toWire] = (ushort) (wire1 >> ushort.Parse(splitInstructions[2]));
                        }
                        else
                        {
                            allDone = false;
                        }
                    }

                    else
                    {

                        if (GetValue(splitInstructions[0], out wire1))
                        {
                            _wireDictionary[toWire] = wire1;
                        }
                        else
                        {
                            allDone = false;
                        }
                    }


                }
            }

            return _wireDictionary;
        }

        private bool GetValue(string identifier, out ushort value)
        {
            value = 0;
            if (ushort.TryParse(identifier, out value))
            {
                return true;
            }
            else if (_wireDictionary.ContainsKey(identifier))
            {
                value = (ushort)_wireDictionary[identifier];
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
