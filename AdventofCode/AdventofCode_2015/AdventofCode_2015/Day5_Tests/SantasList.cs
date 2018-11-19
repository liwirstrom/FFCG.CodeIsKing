using System.Collections.Generic;
using System.Linq;

namespace Day5_Tests
{
    public class SantasList
    {
        public bool IsNice(string name)
        {
            var twoInaRow = DuplicateLetters(name,1);
            var containsVowels = CountVowels(name);

            var letterCombinations = new List<string>{"ab","cd","pq", "xy"};
            var containsCombinations = DoesContain(letterCombinations, name, 1);

            return twoInaRow && containsVowels && !containsCombinations;
        }


        public bool IsNicer(string name)
        {
            var hasPairs = ContainsTwoUniquePairs(name);
            var containsDuplicate = DuplicateLetters(name, 2);

            return hasPairs && containsDuplicate;
        }

        private bool DuplicateLetters(string input, int jump)
        {
            var inputList = input.ToList();
            for (var i = 0; i < inputList.Count-jump; i++)
            {
                if (inputList[i] == inputList[i + jump])
                {
                    return true;
                }
            }

            return false;
        }

        private bool DoesContain(List<string> letterCombinations, string input, int limit)
        {
            var count = 0;

            foreach (var s in letterCombinations)
            {
                if (input.Contains(s))
                {
                    count++;
                }
            }

            return count >= limit;
        }

        private bool CountVowels(string input)
        {
            var niceVowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

            int vowelCount = input.Count(c => niceVowels.Contains(c));

            return vowelCount > 2;

        }

        private bool ContainsTwoUniquePairs(string input)
        {
            if (input.Length < 4)
            {
                return false;
            }
            for (int i = 0; i < input.Length-1; i++)
            {
                var pair = input.Substring(i, 2);

                if ( input.IndexOf(pair, i+2) != -1)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
