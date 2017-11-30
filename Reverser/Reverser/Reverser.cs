using System;
using System.Text;
using System.Linq;

namespace FFCG.Reverser
{
    public class Reverser
    {
        private StringBuilder stringBuilder;

        public Reverser()
        {
            this.stringBuilder = new StringBuilder();
        }

        public string StringReverser(string stringToBeReversed)
        {

            string[] stringArray = stringToBeReversed.Split();

            foreach (var substring in stringArray)
            {
                char[] charArray = substring.ToCharArray();
                char[] tempCharArray = new char[charArray.Length];
                Array.Copy(charArray,tempCharArray,charArray.Length);

                foreach (var letter in charArray)
                {
                    if (Char.IsUpper(letter))
                    {
                        int uppercaseLetterIndex = Array.IndexOf(charArray, letter);
                        tempCharArray[uppercaseLetterIndex] = Char.ToLower(tempCharArray[uppercaseLetterIndex]);
                        int charIndexToUpper = charArray.Length - (uppercaseLetterIndex + 1);
                        tempCharArray[charIndexToUpper] = Char.ToUpper(charArray[charIndexToUpper]);
                    }
                }

                charArray = tempCharArray;

                Array.Reverse(charArray);
                string reversedSubstring = new string(charArray);   
                
                stringBuilder.Append(reversedSubstring);

                if (Array.IndexOf(stringArray, substring) != ((stringArray.Length) - 1)) {
                    stringBuilder.Append(" ");
                }
            }

            return stringBuilder.ToString();        
        }

    }
}
