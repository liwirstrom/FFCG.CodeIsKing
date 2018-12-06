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
}
