using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day4_Tests
{

	[TestClass]
    public class UnitTest1
	{
		private GuardShift _guardShift;

		[TestInitialize]
	    public void Setup()
	    {
		    _guardShift = new GuardShift();

		}


		[TestMethod]
        public void TestMethod1()
		{
			var input = File.ReadAllLines("../../Unittest_input.txt").ToList();
			var guard = _guardShift.FindBestShift(input);
            Assert.AreEqual(10, guard.Item1);
            Assert.AreEqual(24, guard.Item2);
            Assert.AreEqual(240, guard.Item1 * guard.Item2);
		}


	    [TestMethod]
	    public void Answer_input_part1()
	    {
	        var input = File.ReadAllLines("../../Day4_input.txt").ToList();
	        var guard = _guardShift.FindBestShift(input);
	        //Assert.AreEqual(10, guard.Item1);
	        //Assert.AreEqual(24, guard.Item2);
	        Assert.AreEqual(11367, guard.Item1 * guard.Item2);
        }
    }

    public class Guard
    {

        public int MaxMinutesAsleep { get; set; }
        public Dictionary<int, int> SleepMinutes { get; set; }
    }

 //   public class Shift
	//{
	//	public int MaxAsleep { get; set; }
	//	public List<SleepCycle> SleepCycles { get; set; }
	//}

	//public class SleepCycle
	//{
	//	public DateTime start { get; set; }
	//	public DateTime end { get; set; }
	//}

	internal class GuardShift
	{
		public (int,int) FindBestShift(List<string> input)
		{

			List<(DateTime, string)> entries = GetEntries(input);

			var guards = new Dictionary<int, Guard>();

			var id = -1;
			var asleep = 0;

			for (int i = 0; i < entries.Count; i++)
			{
				//var awake = new SleepCycle();
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
					//awake.start = entries[i].Item1;
					//awake.end = entries[i + 1].Item1.AddMinutes(-1);
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
                    
					//shift.SleepCycles.Add(awake);
					//guards[id].Add(shift);
				}
			}

            var guard = (id:0, minute:0);
		    var sleepiestGuard = guards.Values.OrderByDescending(g => g.MaxMinutesAsleep).First();
		    guard.minute = sleepiestGuard.SleepMinutes.OrderByDescending(m => m.Value).First().Key;
            guard.id = guards.FirstOrDefault(x => x.Value == sleepiestGuard).Key;

		    return guard;
		}

		//private int FindSleepiestGuardId(Dictionary<int, List<Shift>> guards)
		//{
		//	int maxMinutesAsleep = 0 ;
		//	int id;
		//	foreach (var guard in guards)
		//	{
		//		foreach (var shift in guard.Value)
		//		{
		//			var minutes = 0;
		//			foreach (var shiftSleepCycle in shift.SleepCycles)
		//			{
		//				minutes += (shiftSleepCycle.end - shiftSleepCycle.start).Minutes;
		//			}

		//			if (minutes > maxMinutesAsleep)
		//			{
		//				maxMinutesAsleep = minutes;
		//				id = guard.Key;
		//			}
		//		}
		//	}

		//    return maxMinutesAsleep;
		//}

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
