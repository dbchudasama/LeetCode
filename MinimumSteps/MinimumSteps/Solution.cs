using System;
using System.Linq;

namespace MinimumSteps
{
    class Solution
    {

        //SOLUTION FOR LEETCODE QUESTION:
        //MINIMUM STEPS TO MAKE PILES EQUAL HEIGHTS


        /// <summary>
        /// Method to calculate minimum number of steps to make pile heights equal
        /// </summary>
        /// <param name="pilesHeight"></param>
        /// <returns>Number of Steps</returns>
        public int minStepsToMakePilesHeightEqual(int[] pilesHeight)
        {

            //Reverse Array -> Largest to smallest
            Array.Reverse(pilesHeight); 

            //Counters
            int steps = 0;
            int i = 1;


            //While i is less than the length of the pile
            while(i < pilesHeight.Length)
            {
                //If the i'th item is not equal to it's preceding item
                if (pilesHeight[i] != pilesHeight[i - 1])
                {
                    //steps = steps + i - Recursively keep adding to the number of steps until height list is exhausted. 
                    steps += i;
                }
                //Increment i
                i++;
            }

            return steps;
            //O(NlognN)
        }


        static void Main(string[] args)
        {
            var s = new Solution();
            var piles = new int[] { 1, 3, 8 };
            var steps = s.minStepsToMakePilesHeightEqual(piles);

            Console.WriteLine($"The Minimum number of steps needed to equal pile heights ({String.Join(",", piles.Select(x => x.ToString()).ToArray())}) is {steps}");
        }
    }
}
