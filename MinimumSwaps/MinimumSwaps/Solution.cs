using System;

namespace MinimumSwaps
{
    class Solution
    {

        //SOLUTION FOR LEETCODE QUESTION:
        //MINIMUM ADJACENT SWAPS TO MAKE PALINDROME (A WORD THAT IS SPELT THE SAME BACKWARDS I.E. MADAM)

        public string Palindrome { get;  set; }

        /// <summary>
        /// Method to calculate number of adjacent swaps to make a word into a Palindrome
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Number of adjacente swaps</returns>
        public int minAdjSwapsToPalindrome(string s)
        {

            //Converting string into character array
            char[] charArray = s.ToCharArray();
            //Checking to see if string is empty or if the word is a Palindrome
            if (string.IsNullOrEmpty(s) || isPalindrome(charArray)) return 0;

            int minSwapCount = 0;

            //Length - 1 due to array index count starting at 0
            int low = 0, high = s.Length - 1;

            // While true
            while (low < high)
            {
                //If the first letter and last letter are the same
                if (charArray[low] == charArray[high])
                {
                    //Increment and Decrement from each end of string by 1
                    ++low;
                    --high;
                }

                //Setting match index 
                int matchIndex = high;

                //While loop doing char comparison using matchindex as a pivot to compare with other charactes in the string until it reaches the same character
                //Takes care of the left side of the word
                while (low < matchIndex && charArray[low] != charArray[matchIndex])
                    //Decrement match index
                    --matchIndex;

                //When the match index matches low counter
                if (low == matchIndex)
                {
                    //Swap the two characters that are side by side
                    swap(charArray, low, low + 1);
                    //Increment the swap count 
                    ++minSwapCount;
                }
                else
                {
                    //Looping from the match index pivot to the remainder of values. Right hand side of the string. 
                    for (int i = matchIndex; i < high; i++)
                    {
                        //Swapping characters
                        swap(charArray, i, i + 1);
                        //Incrementing the swap count
                        ++minSwapCount;
                    }
                }

                //Keeping incrementing and decremeting otherwise
                ++low;
                --high;
            }

            Palindrome = new string(charArray);
            //If not a Palindrome then return -1
            return (isPalindrome(charArray)) ? minSwapCount : -1;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="indexA"></param>
        /// <param name="indexB"></param>
        private void swap(char[] s, int indexA, int indexB)
        {
            //Temp index
            char temp = s[indexA];
            //Setting indexA to indexB
            s[indexA] = s[indexB];
            //Setting IndexB to Index A
            s[indexB] = temp;
        }


        /// <summary>
        /// Function to return if the word is a palindrome
        /// </summary>
        /// <param name="s"></param>
        /// <returns>True or False</returns>
        private bool isPalindrome(char[] s)
        {
            // Maximum is length of string - 1 due to index count starting at 0
            int low = 0, high = s.Length - 1;

            // While true
            while (low < high)
            {
                //First letter is not equal to the last letter return false
                if (s[low] != s[high]) return false;
                //Decrement down from end to start
                --high;
                //Increment up from start to end
                ++low;
            }

            return true;

        }


        static void Main(string[] args)
        {
            var n = new Solution();
            var s = "awdje";
            var swaps = n.minAdjSwapsToPalindrome(s);
            if (swaps < 0)
            {
                Console.Write($"The word {s} is not a Palindrome");
            }
            else
            {
                Console.Write($"The minimum number of adjacent swaps needed to make {s} into the Palindrome {n.Palindrome} is: {swaps}");
            }
        }
    }
}
