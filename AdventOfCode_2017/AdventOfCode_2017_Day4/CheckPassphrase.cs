using System;
using System.Collections.Generic;
using System.Linq;

namespace Passphrases
{
    public class CheckPassphrase
    {
        public int NoDuplicates(List<List<string>> passphraseList)
        {
            int nrAcceptedPassphrases = 0;
            foreach (var row in passphraseList)
            {
                //nrAcceptedPassphrases += IsDistinct(row) ? 1 : 0;
                nrAcceptedPassphrases += NotAnagram(row) ? 1 : 0;
            }
            return nrAcceptedPassphrases;
        }

        public bool IsDistinct(List<string> row)
        {
            return row.Count() == row.Distinct().Count();
        }

        public bool NotAnagram(List<string> row)
        {
            int counter = 0;
            foreach (var item in row)
            {
                for (int i = 0; i < row.Count(); i++)
                {
                    if (i != counter)
                    {
                        if (String.Concat(item.OrderBy(c => c)) == String.Concat(row[i].OrderBy(c => c)))
                        {
                            return false;
                        }
                    }
                }
                counter++;

            }

            return true;
        }
    }
}
