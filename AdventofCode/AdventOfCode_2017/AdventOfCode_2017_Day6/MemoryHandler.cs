using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2017_Day6_
{
    public class MemoryHandler
    {
        private List<string> _states;

        public MemoryHandler()
        {
            _states = new List<string>();
        }
        public int ReallocateMemory(List<int> memoryBank)
        {
            int distributions = 0;
            while (true)
            {
                List<string> states = new List<string>();

                int blocksToReallocate = memoryBank.OrderByDescending(temperatureObject => temperatureObject).FirstOrDefault();
                int addBlockToIndex = memoryBank.IndexOf(blocksToReallocate) +1;
                memoryBank[memoryBank.IndexOf(blocksToReallocate)] = 0;

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

                distributions++;

                if (!checkNewState(memoryBank))
                {
                    return distributions;
                }
            }

        }

        private bool checkNewState(List<int> memoryBank)
        {
            string state = "";
            foreach (var number in memoryBank)
            {
                state += number.ToString()+",";
            }

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
    }
}
