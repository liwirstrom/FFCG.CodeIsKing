using System.Collections.Generic;
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
            var instructions = new List<string>();
            var wireDictionary = _bitwiseAssembler.ExecuteInstructions(instructions);
        }

        [TestMethod]
        public void Should_execute_Shift_part1()
        {
            var instructions = new List<string>();
            var wireDictionary = _bitwiseAssembler.ExecuteInstructions(instructions);
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
    }

    public class BitwiseAssembler
    {
        private Dictionary<string,int> _wireDictionary;

        public BitwiseAssembler()
        {
            _wireDictionary = new Dictionary<string, int>();
        }

        public Dictionary<string, int> ExecuteInstructions(List<string> instructions)
        {


            foreach (var instruction in instructions)
            {
                var splitInstructions = instruction.Split(' ');

                if (splitInstructions.Contains("NOT"))
                {
                    var fromwire = splitInstructions[1];
                    var toWire = splitInstructions[3];
                    int signal;
                    if (_wireDictionary.ContainsKey(fromwire))
                    {
                       signal = ~_wireDictionary[fromwire];
                    }
                    else
                    {
                        signal = ~0;
                    }

                    SetValue(toWire, signal);
                     
                }

                else if (splitInstructions.Contains("AND"))
                {


                    if (int.TryParse(splitInstructions[0], out var firstValue))
                    {
                        if (int.TryParse(splitInstructions[0], out var lastValue))
                        {
                            
                        }
                    }

                    else
                    {
                        firstValue = GetValue(splitInstructions[0]);

                    }
                }

                else if (splitInstructions.Contains("OR"))
                {

                }

                else
                {
                    if (int.TryParse(splitInstructions[0], out var signal))
                    {
                        SetValue(splitInstructions[2], signal);
                    }
                    else
                    {
                        signal = GetValue(splitInstructions[0]);
                        SetValue(splitInstructions[2], signal);
                    }
                }


            }

            return _wireDictionary;
        }

        private void SetValue(string toWire, int signal)
        {
            if (_wireDictionary.ContainsKey(toWire))
            {
                _wireDictionary[toWire] = signal;
            }
            else
            {
                _wireDictionary.Add(toWire, signal);
            }
        }

        private int GetValue(string fromWire)
        {
            if (_wireDictionary.ContainsKey(fromWire))
            {
                return _wireDictionary[fromWire];
            }

            return 0;
        }
    }
}
