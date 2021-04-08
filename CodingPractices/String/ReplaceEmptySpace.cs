using System;
using System.Linq;

namespace CodingPractices.String
{
    public class ReplaceEmptySpace
    {
        public string Replace(string input)
        {
            int originalSize = input.Length;
            var emptySpaceChar = char.Parse(" ");
            int count = input.Count(character => character == emptySpaceChar);

            int newSize = originalSize + (count << 1);
            var newString = new char[newSize];
            
            int i = newSize - 1;
            int j = originalSize - 1;
            while (j < i)
            {
                if (input[j] == emptySpaceChar)
                {
                    newString[i] = '0';
                    newString[i - 1] = '2';
                    newString[i - 2] = '%';
                    i -= 2;
                }
                else
                {
                    newString[i] = input[j];
                }

                i--;
                j--;
            }

            for (int k = j; k >= 0; k--)
            {
                newString[k] = input[k];
            }

            return new string(newString);
        }

        // Slightly better
        public string Replace_arr(string input)
        {
            int originalSize = input.Length;
            var emptySpaceChar = char.Parse(" ");
            int count = input.Count(character => character == emptySpaceChar);

            int newSize = originalSize + (count << 1);
            var newString = input.ToCharArray();
            Array.Resize(ref newString, newSize);
            
            int i = newSize - 1;
            int j = originalSize - 1;
            while (j < i)
            {
                if (input[j] == emptySpaceChar)
                {
                    newString[i] = '0';
                    newString[i - 1] = '2';
                    newString[i - 2] = '%';
                    i -= 2;
                }
                else
                {
                    newString[i] = input[j];
                }

                i--;
                j--;
            }

            return new string(newString);
        }
    }
}
