using System.Collections.Generic;
using System.Linq;

namespace AdventofCode_2018_Day2_Tests
{
    public partial class InventoryManagerUnitTests
    {
        public class InventoryManager
        {

            public int GetCheckSum(List<string> input)
            {
                var duplicates = 0;
                var triplets = 0;
                foreach (var id in input)
                {
                    var duplicate = HasDuplicate(id);
                    var triplet = HasTriplet(id);
                    if (duplicate)
                    {
                        duplicates++;
                    }

                    if (triplet)
                    {
                        triplets++;
                    }
                }

                return duplicates * triplets;
            }

            public string GetMostSimilar(List<string> input)
            {
                var commonChars = "";
                var foundMostSimilar = false;
                while (!foundMostSimilar)
                {
                    for (int i = 0; i <= input.Count - 2; i++)
                    {
                        var comparative1 = input[i];

                        for (int j = 0; j <= input.Count - 1; j++)
                        {
                            var comparative2 = input[j];
                            if (HasOneUncommon(comparative1, comparative2))
                            {
                                commonChars = RemoveUniqueChar(comparative1, comparative2);
                                foundMostSimilar = true;
                                break;
                            }
                        }
                    }
                }        
                return commonChars;
            }

            private bool HasOneUncommon(string comparative1, string comparative2)
            {
                var uncommon = 0;
                for (int j = 0; j < comparative1.Length; j++)
                {
                    var letter = comparative1[j];
                    if (comparative1[j] != comparative2[j])
                    {
                        uncommon++;
                        if (uncommon > 1)
                        {
                            return false;
                        }
                    }
                }
                return uncommon == 1;
            }

            private string RemoveUniqueChar(string comparative1, string comparative2 )
            {
                for (int j = 0; j < comparative1.Length; j++)
                {
                    if (comparative1[j] != comparative2[j])
                    {
                        comparative1 = comparative1.Remove(j, 1);
                        break;
                    }
                }

                return comparative1;
            }

            private bool HasDuplicate(string input)
            {
                bool hasDuplicate = input.GroupBy(c => c).Any(c => c.Count<char>() == 2);
                return hasDuplicate;
            }

            private bool HasTriplet(string input)
            {
                var hasTriplet = input.GroupBy(c => c).Any(c => c.Count<char>() == 3);

                return hasTriplet;
            }

        }
    }
}
