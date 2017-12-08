using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2017_Day6_
{
    public class MemoryHandler
    {
        private List<string> _states { get; set; }
        private int _cyclesBetweenSameState { get; set; }

        public MemoryHandler()
        {
            _states = new List<string>();
            _cyclesBetweenSameState = 0;
        }
        public int ReallocateMemory(List<int> memoryBank)
        {
            int distributions = 0;
            while (true)
            {
                int blocksToReallocate = memoryBank.OrderByDescending(temperatureObject => temperatureObject).FirstOrDefault();
                int addBlockToIndex = memoryBank.IndexOf(blocksToReallocate) +1;
                memoryBank[memoryBank.IndexOf(blocksToReallocate)] = 0;
                memoryBank = ReallocateBlocksInMemory(blocksToReallocate, addBlockToIndex, memoryBank);
                distributions++;
                string state = CreateStateString(memoryBank);

                if (!checkNewState(state))
                {
                    return distributions;
                }
            }
        }

        public int GetCycleToReallocateMemory(List<int> memoryBank)
        {
            while (true)
            {
                int blocksToReallocate = memoryBank.OrderByDescending(temperatureObject => temperatureObject).FirstOrDefault();
                int addBlockToIndex = memoryBank.IndexOf(blocksToReallocate) + 1;
                memoryBank[memoryBank.IndexOf(blocksToReallocate)] = 0;
                memoryBank = ReallocateBlocksInMemory(blocksToReallocate, addBlockToIndex, memoryBank);
                string state = CreateStateString(memoryBank);
                if (!checkNewState(state))
                {
                    int cycle = _states.Count() - _states.IndexOf(state);
                    return cycle;                
                }
            }
        }

        private List<int> ReallocateBlocksInMemory(int blocksToReallocate, int addBlockToIndex, List<int> memoryBank)
        {
            while (blocksToReallocate > 0)
            {
                if (addBlockToIndex >= memoryBank.Count())
                {
                    addBlockToIndex = 0;
                }
                else
                {
                    memoryBank[addBlockToIndex] = memoryBank[addBlockToIndex] + 1;
                    addBlockToIndex++;
                    blocksToReallocate--;
                }
            }
            return memoryBank;
        }

        private bool checkNewState(String state)
        {
            if (_states.Contains(state))
            {
                return false;
            }
            else
            {
                _states.Add(state);
                return true;
            }
        }

        private string CreateStateString(List<int> memoryBank)
        {
            string state = "";
            foreach (var number in memoryBank)
            {
                state += number.ToString() + ",";
            }

            return state;
        }
    }
}
