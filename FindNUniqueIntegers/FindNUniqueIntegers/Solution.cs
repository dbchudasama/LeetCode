using System;
using System.Collections.Generic;
using System.Linq;

namespace FindNUniqueIntegers
{
    class Solution
    {

        /// <summary>
        /// Method that finds N unique Integers that Sum up to 0 (in an array)
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Array of integers summing up to 0</returns>
        public int[] SumZero(int n)
        {
            if( n > 1000)
            {
                //As per constraint in question, 1 < n < 1000. Else return 0.
                return new int[0];
            }

            var sumArray = new int[n];

            //Using basic math. Lower bound is -ve value of n/2. This will satisy the condition of returning 0 if we only have a single element array
            //and want to return a symmetric array (-x, +x)
            for (int i = -n / 2, j = 0; i <= n / 2; i++, j++)
            {
                //If n is an even number
                if (n % 2 == 0 && i == 0)
                {
                    j--;
                    continue;
                }

                //The index element = the value of i
                sumArray[j] = i;
            }
            return sumArray;
        }



        static void Main(string[] args)
        {
            var s = new Solution();
            var n = 1;
            var a = s.SumZero(n);

            Console.WriteLine($"The unique integers that sum up to Zero for the array size {n} are {String.Join(",", a.Select(x => x.ToString()).ToArray())}");
        }
    }
}
