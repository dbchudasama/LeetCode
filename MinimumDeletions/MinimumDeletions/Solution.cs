using System;

namespace MinimumDeletions
{
    public class Solution
    {

        //SOLUTION FOR LEETCODE QUESTION:
        //1647 - MINIMUM DELETIONS TO MAKE CHARACTER FREQUENCIES UNIQUE
        //*****DIFFICULTY - MEDIUM*****


        /// <summary>
        /// Method that calculates the minimum number of deletions from a string to make each character frequency unique
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Number of minimum deletions</returns>
        public int MinDeletions(string s)
        {
            // 26 letters in the alphabet (CONSTRAINT - s only contains lowercase English letters)
            var freq = new int[26];

            foreach(var c in s)
            {
                //97 is the numeric value of the character 'a', so we are subtracting 97 from each character in the string,
                //mapping each character to an index of the freq array between 0 and 25. Eg. a - 'a' = 97 - 97 = 0 => index value [0]
                // b - 'a' = 98 - 97 = 1 => index value [1] etc...
                //Incrementing to keep a counter of how many times each character appears in the string
                freq[c - 'a']++;
            }

            //Sorting characters by their frequencies
            Array.Sort(freq);

            int minDeletes = 0;

            // Max Remaining is the value of the last element (as this will be the highest frequency)
            int max_remaining = freq[freq.Length - 1];

            //Starting for loop at penutlimate element (as this is second largest frequency) and iterating backwards
            for(int i = freq.Length - 2; i >= 0; i--)
            {
                //If the maximimum frequency count is 0
                if (max_remaining == 0)
                {
                    //minDeletes = minDeletes + frequency[i] => This becomes the minimum number of deletes
                    minDeletes += freq[i];
                }
                else
                {
                    if (freq[i] < max_remaining)
                    {
                        //This then becomes the highest freqeuncy
                        max_remaining = freq[i];
                    }
                    else
                    {
                        //minDeletes = minDeletes + freq[i] - max_remaining + 1 => E.g. 0 + 3 - 3 + 1 = 1.
                        minDeletes += freq[i] - max_remaining + 1;
                        //As we can only delete characters, if we hve multiple characters having the same frequency, we must decrease all frequencies, excpet one
                        max_remaining--;
                    }
                }
            }
            //Return minimum number of deletes
            return minDeletes;
        }



        static void Main(string[] args)
        {
            var s = new Solution();
            var w = "aabccccddeeee";
            var numberofDeletions = s.MinDeletions(w);

            Console.WriteLine($"The minimum number of deletes to make character frequencies unique for the string {w} is {numberofDeletions}");
        }
    }
}
