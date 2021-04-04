using System;
using System.Collections;
using System.Collections.Generic;

namespace MaxLength
{
    class Solution
    {

        //SOLUTION FOR LEETCODE QUESTION:
        //MAXIMUM LENGTH OF A CONCATENATED STRING WITH UNIQUE CHARACTERS
        //*****DIFFICULTY - MEDIUM*****


        /// <summary>
        /// Method to calculate Maximum possible length of the string
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>MAximum length of string</returns>
        public int MaxLength(IList<string> arr)
        {
            return MaxUnique(arr, 0, "");
        }


        /// <summary>
        /// Method to calculate Maximum length of string with unique characters
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="current"></param>
        /// <returns>Length of Maximum string value</returns>
        private int MaxUnique(IList<string> array, int index, string current)
        {
            //If index value and array item count is the same
            //Base Case 1 in our Recursion Scenario
            if(index == array.Count)
            {
                //It is a unique substring
                return IsUnique(current);
            }

            //If there is already a match then return -1
            //Base Case 2 in our Recusrion Scenario
            if(IsUnique(current) == -1)
            {
                return -1;
            }

            //RECURSION - As we are unsure on the number of for loops, recursion is the best option here to compute all combinations
            //Comparing blank string to start with then concatenating with each substring
            //The first iteration will always yeild result = 0 as current string is blank. Once it enters the result2 call, it will start building the substring and comparing uniqueness
            int result = MaxUnique(array, index + 1, current);
            int result2 = MaxUnique(array, index + 1, current + array[index]);

            //Return the larger of the two numbers. When both max lengths match this is the Maximum possible length of the string.
            return Math.Max(result, result2);
        }



        /// <summary>
        /// Method that uses HashSet to compare substring and verify if they are unique
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Length of string</returns>
        private int IsUnique(string s)
        {
            //Creating new Hashset
            HashSet<char> hashSet = new HashSet<char>();

            //Looping over string
            foreach (var c in s)
            {
                //If the HashSet already contains the character
                if (hashSet.Contains(c))
                {
                    return -1;
                }
                //Else add character to Hashset
                hashSet.Add(c);
            }
            return s.Length;
        }



        static void Main(string[] args)
        {
            var s = new Solution();
            var l = s.MaxLength(new List<string>()
            { 
                "th",
                "e",
                "be",
                "st"
            });

            Console.WriteLine($"The maximum possible length of concatenation s which have unique characters is {l}");
        }
    }
}
