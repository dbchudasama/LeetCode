using System;
using System.Collections.Generic;
using System.Linq;

namespace PartitionToKEqualSubsets
{
    class Solution
    {
        int valueToMake { get; set; }


        /// <summary>
        /// Function to calculate of a given array can be equally split into k subsets of the same sum
        /// </summary>
        /// <param name="nums">Array</param>
        /// <param name="k">Number of subsets to be made</param>
        /// <returns>True or False</returns>
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            //Using Linq to sort array in Descending order
            nums = nums.OrderByDescending(x => x).ToArray();

            //Computes the sum of the sequence of array values
            var sum = nums.Sum();

            //If the sum can not be equally divided by the number of subsets required return false
            if (sum % k != 0) return false;

            //This is the value that each subset needs to sum to
            valueToMake = sum / k;

            //This should also be the Maximum value in the array so if it is less than the max array value return false
            if (valueToMake < nums.Max()) return false;

            //Calling Recursive function
            return Helper(nums, 0, 0, valueToMake, k, new HashSet<int>());
        }



        /// <summary>
        /// Helper function to calculate of a given array can be equally split into k subsets of the same sum
        /// </summary>
        /// <param name="nums">The integer array</param>
        /// <param name="startIdx">The starting index</param>
        /// <param name="sum">The sum of array values - Start of with 0 as first case scenario</param>
        /// <param name="target">Value that needs to be made by each subset after adding</param>
        /// <param name="k">The number of total subsets that need to be made</param>
        /// <param name="visitedIdx">Hash reference/comparison value</param>
        /// <returns>True of False</returns>
        private bool Helper(int[] nums, int startIdx, int sum, int target, int k, HashSet<int> visitedIdx)
        {
            //If the total number of subsets to me made is just 1 then return true
            if (k == 1) return true;

            //If the sum exceeds the required target then return false
            if (sum > target) return false;

            //If the sum Equals the target to make
            if (sum == target)
            {
                //Recursively call the function, but this time decreasing the subset by 1 as we already have a single item subset [target]
                return Helper(nums, 0, 0, target, k - 1, visitedIdx);
            }

            //Iterating from 0 to length of array
            for (var i = startIdx; i < nums.Length; i++)
            {
                //If the reference index is already in the HashSet carry on looping
                if (visitedIdx.Contains(i)) continue;

                //Else add the index to the HashSet as unique
                visitedIdx.Add(i);

                //Using given example (Helper({5, 4, 3, 3, 2, 2, 1}, 1, 5, 5, 4, 0) - if the 3rd and 4th variables are the same
                //(largest element value and target value are both the same) return true
                if (Helper(nums, i + 1, sum + nums[i], target, k, visitedIdx))
                {
                    return true;
                }
                //Otherwise remove the reference from the Hash Set
                visitedIdx.Remove(i);

                //for i = 0 -> (1 < 7 && 5 == 4)
                while (i + 1 < nums.Length && nums[i] == nums[i + 1])
                    //iterate i
                    i++;
            }

            return false;
        }


        static void Main(string[] args)
        {
            var s = new Solution();
            var array = new int[] { 4, 3, 2, 3, 5, 2, 1 };
            var k = 4;
            var answer = s.CanPartitionKSubsets(array, k);

            if(answer == true)
            {
                Console.WriteLine($"The array ({String.Join(",", array.Select(x => x.ToString()).ToArray())}) can be split into {k} equal subsets, with each subset summing {s.valueToMake}");
            }
            else
            {
                Console.WriteLine($"The array {String.Join(",", array.Select(x => x.ToString()).ToArray())}, cannot be partitioned into any subsets");
            }
            
        }
    }
}
