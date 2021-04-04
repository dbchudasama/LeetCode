using System;
using System.Linq;

namespace LargestK
{
    class Solution
    {

        //SOLUTION FOR LEETCODE QUESTION:
        //LARGEST K SUCH THAT K AND -K BOTH EXIST IN ARRAY


        /// <summary>
        /// Method to calculate Largest K in array such that both K and -K exist in array
        /// </summary>
        /// <param name="numberArray"></param>
        /// <returns>Largest K</returns>
        public int LargestK(int[] numberArray)
        {
            //Sort Array in reverse order so largest number is first
            Array.Sort(numberArray);

            //Counter
            int i = 0;
            int j = 1;

            //If the array is empty
            if (numberArray.Length == i)
            {
                //return 0
                return 0;
            }

            //While i < Length of array
            while(j != numberArray.Length)
            {
                //Comparing items from largest to smallest on absolute value - satisifying the condition -> return Largest K such that both K and -K exist in the array
                if (numberArray[numberArray.Length - j] == Math.Abs(numberArray[i]))
                {
                    //If there is a match then return value
                    return numberArray[numberArray.Length - j];
                }
                //Else keep iterating j
                j++;
            }
            //Otherwise just return 0
            return 0;
        }



        static void Main(string[] args)
        {
            var s = new Solution();
            var array = new int[] { };
            var number = s.LargestK(array);

            if(number != 0)
            {
                Console.WriteLine($"The Largest value K in the array ({String.Join(",", array.Select(x => x.ToString()).ToArray())}) for which both K and -K exist is {number}");
            }
            else
            {
                Console.WriteLine("Array does not match the conditions. Returned 0.");
            }
        }
    }
}
