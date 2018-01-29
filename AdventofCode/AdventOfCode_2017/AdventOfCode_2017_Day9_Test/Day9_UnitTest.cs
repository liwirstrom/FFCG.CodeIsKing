using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode_2017_Day9_Test
{
    [TestClass]
    public class Day9_UnitTest
    {

        [TestMethod]
        public void Day9_find_all_groups_part1()
        {
            string group3 = "{{},{}},";


        }

        [TestMethod]
        public void Day9_find_all_groups_2_part1()
        {
            string group6 = "{{{},{},{{}}}},";
        }

        [TestMethod]
        public void Day9_find_all_groups_3_part1()
        {
            string group2 = "{{<!>},{<!>},{<!>},{<a>}}";
        }




        [TestMethod]
        public void Day9_should_calculate_correct_points_part1()
        {
            string group6 = "{{{},{},{{}}}},";
            List<CharGroup> groupList = _charHandler.GetGroups(group6);
            _charHandler.CalculateScore(groupList);
        }
    }
}
