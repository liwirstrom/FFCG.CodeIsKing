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

		}
    }

	//public class Guard
	//{

	//	public int Id { get; set; }
	//	public List<(DateTime, DateTime)> List { get; set; }
	//}

	public class Shift
	{
		public int MaxAsleep { get; set; }
		public List<SleepCycle> SleepCycles { get; set; }
	}

	public class SleepCycle
	{
		public DateTime start { get; set; }
		public DateTime end { get; set; }
	}

	internal class GuardShift
	{
		public (int,int) FindBestShift(List<string> input)
		{

			List<(DateTime, string)> entries = GetEntries(input);

			var guards = new Dictionary<int, List<Shift>>();
			var id = 0;
			var shift = new Shift();
			var asleep = 0;
			for (int i = 0; i < entries.Count; i++)
			{
				var awake = new SleepCycle();

				if (entries[i].Item2.StartsWith("Guard"))
				{
					id = Convert.ToInt32(entries[i].Item2.Split(' ')[1].Replace("#", ""));
					asleep = 0;
					guards[id].Add(shift);
				}

				if (entries[i].Item2.StartsWith("falls"))
				{		
					awake.start = entries[i].Item1;
					awake.end = entries[i + 1].Item1.AddMinutes(-1);
					asleep += (entries[i + 1].Item1.AddMinutes(-1) - entries[i].Item1).Minutes;
					shift.SleepCycles.Add(awake);
					guards[id].Add(shift);
				}
			}

			int guardId = FindSleepiestGuardId(guards);
		}

		private int FindSleepiestGuardId(Dictionary<int, List<Shift>> guards)
		{
			int maxMinutesAsleep = 0 ;
			int id;
			foreach (var guard in guards)
			{
				foreach (var shift in guard.Value)
				{
					var minutes = 0;
					foreach (var shiftSleepCycle in shift.SleepCycles)
					{
						minutes += (shiftSleepCycle.end - shiftSleepCycle.start).Minutes;
					}

					if (minutes > maxMinutesAsleep)
					{
						maxMinutesAsleep = minutes;
						id = guard.Key;
					}
				}
			}
		}

		private List<(DateTime, string)> GetEntries(List<string> input)
		{
			var entries = new List<(DateTime, string)>();

			foreach (var row in input)
			{
				var substring = row.Split(']');
				var date = Convert.ToDateTime(substring[0].Replace("[", ""));
				entries.Add((date, substring[1]));
			}

			entries.OrderByDescending(e => e.Item1);

			return entries;
		}
	}
}
