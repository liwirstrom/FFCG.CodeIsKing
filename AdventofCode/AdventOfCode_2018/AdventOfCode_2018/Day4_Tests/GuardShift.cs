using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4_Tests
{
    public class GuardShift
    {
        public Dictionary<int, Guard> OrganizeObservations(List<string> input)
        {

            List<(DateTime, string)> entries = GetEntries(input);

            var guards = new Dictionary<int, Guard>();

            var id = -1;
            var asleep = 0;

            for (int i = 0; i < entries.Count; i++)
            {
                var entry = entries[i];
                var observation = entry.Item2;

                if (observation.StartsWith("Guard"))
                {
                    if (id != -1)
                    {

                        var slept = guards[id].MaxMinutesAsleep;
                        guards[id].MaxMinutesAsleep = slept + asleep;
                    }

                    var stringList = observation.Split(' ');
                    id = Convert.ToInt32( stringList[1].Replace("#", ""));
                    asleep = 0;
                    if (!guards.ContainsKey(id))
                    {
                        guards[id] = new Guard { MaxMinutesAsleep = 0, SleepMinutes = new Dictionary<int, int>() };
                    }
					
                }

                if (entries[i].Item2.StartsWith("falls"))
                {		
                    var start = entries[i].Item1;
                    var end = entries[i + 1].Item1.AddMinutes(-1);
                    for (int j = start.Minute; j <= end.Minute; j++)
                    {
                        if (guards[id].SleepMinutes.ContainsKey(j))
                        {
                            guards[id].SleepMinutes[j] += 1;
                        }
                        else
                        {
                            guards[id].SleepMinutes[j] = 1;
                        }
                    }

                    asleep += ((end.Minute) - start.Minute)+1;
                    
                }
            }

            return guards;
        }
        public (int, int) GetHighestFrequency(Dictionary<int, Guard> guards)
        {

            var highestFrequency = 0;
            var sleepiestGuard = (id: 0, minute: 0);
            foreach (var guard in guards)
            {
                var guardFrequency = 0;
                if (guard.Value.SleepMinutes.Count != 0)
                {
                    guardFrequency = guard.Value.SleepMinutes.Values.Max();
                }

                if (guardFrequency > highestFrequency)
                {
                    highestFrequency = guardFrequency;
                    sleepiestGuard.minute = guard.Value.SleepMinutes.FirstOrDefault(x => x.Value == guardFrequency).Key;
                    sleepiestGuard.id = guard.Key;
                }
            }

            return sleepiestGuard;
        }

        private List<(DateTime, string)> GetEntries(List<string> input)
        {
            var entries = new List<(DateTime, string)>();

            foreach (var row in input)
            {
                var substring = row.Split(']');
                var date = Convert.ToDateTime(substring[0].Replace("[", ""));
                entries.Add((date, substring[1].Trim()));
            }

            entries = entries.OrderBy(e => e.Item1).ToList();

            return entries;
        }
    }
}