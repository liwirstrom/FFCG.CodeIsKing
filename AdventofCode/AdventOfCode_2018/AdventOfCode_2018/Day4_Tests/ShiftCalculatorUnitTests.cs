using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day4_Tests
{

	[TestClass]
    public class ShiftCalculatorUnitTests
	{
		private GuardShift _guardShift;

		[TestInitialize]
	    public void Setup()
	    {
		    _guardShift = new GuardShift();

		}


		[TestMethod]
        public void Should_Be_Guard_10_And_Minute_24()
		{
			var input = File.ReadAllLines("../../Unittest_input.txt").ToList();
			var guards = _guardShift.OrganizeObservations(input);

			var guard = (id: 0, minute: 0);
			var sleepiestGuard = guards.Values.OrderByDescending(g => g.MaxMinutesAsleep).First();
			guard.minute = sleepiestGuard.SleepMinutes.OrderByDescending(m => m.Value).First().Key;
			guard.id = guards.FirstOrDefault(x => x.Value == sleepiestGuard).Key;

			Assert.AreEqual(10, guard.id);
            Assert.AreEqual(24, guard.minute);
            Assert.AreEqual(240, guard.id * guard.minute);
		}


	    [TestMethod]
	    public void Answer_input_part1()
	    {
	        var input = File.ReadAllLines("../../Day4_input.txt").ToList();
		    var guards = _guardShift.OrganizeObservations(input);

		    var guard = (id: 0, minute: 0);
		    var sleepiestGuard = guards.Values.OrderByDescending(g => g.MaxMinutesAsleep).First();
		    guard.minute = sleepiestGuard.SleepMinutes.OrderByDescending(m => m.Value).First().Key;
		    guard.id = guards.FirstOrDefault(x => x.Value == sleepiestGuard).Key;

			Assert.AreEqual(11367, guard.id * guard.minute);
        }

		[TestMethod]
		public void Should_Be_Guard_99_And_Minute_45()
		{
			var input = File.ReadAllLines("../../Unittest_input.txt").ToList();
			var guards = _guardShift.OrganizeObservations(input);

			var sleepiestGuard = (id: 0, minute: 0);
			sleepiestGuard = _guardShift.GetHighestFrequency(guards);

			Assert.AreEqual(99, sleepiestGuard.id);
			Assert.AreEqual(45, sleepiestGuard.minute);
			Assert.AreEqual(4455, sleepiestGuard.id * sleepiestGuard.minute);
		}


		[TestMethod]
		public void Answer_input_part2()
		{
			var input = File.ReadAllLines("../../Day4_input.txt").ToList();
			var guards = _guardShift.OrganizeObservations(input);

			var sleepiestGuard = (id: 0, minute: 0);
			sleepiestGuard = _guardShift.GetHighestFrequency(guards);

			Assert.AreEqual(36896, sleepiestGuard.id * sleepiestGuard.minute);
		}
	}

    public class Guard
    {

        public int MaxMinutesAsleep { get; set; }
        public Dictionary<int, int> SleepMinutes { get; set; }
    }

	internal class GuardShift
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

		public (int,int) GetHighestFrequency(Dictionary<int, Guard> guards)
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
	}
}
