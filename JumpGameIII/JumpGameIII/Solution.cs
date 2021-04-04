using System;
using System.Collections.Generic;
using System.Linq;

namespace JumpGameIII
{
    class Solution
    {

		//SOLUTION FOR LEETCODE QUESTION:
		//1306 - Given an array of non-negative integers arr, you are initially positioned at start index of the array.
		//       When you are at index i, you can jump to i + arr[i] or i - arr[i], check if you can reach to any index with value 0.
		//*****DIFFICULTY - MEDIUM*****

		//SOLVING USING RECURSION AND DYNAMIC PROGRAMMING. BFS IS OTHERWISE THE RECOMMENDED APPROACH

		//Using memoization (dynamic programming)
		Dictionary<int, bool> memo = new Dictionary<int, bool>();

		public bool CanReach(int[] arr, int start)
		{
			//If the node has already been visited 
			if (memo.ContainsKey(start))
				//Just return node
				return memo[start];

			bool result = false;
			//Add node and value to memo (cache). This is to avoid cycles
			memo.Add(start, result);

			//If the starting index value has value 0
			if (arr[start] == 0)
				
				result = true;

			else
			{
				//Starting at offset value
				int offset = arr[start];

				//If the start index add the offset value < length of array - CONSTRAINT - CANNOT JUMP OUTSIDE OF THE ARRAY AT ANY POINT
				if (start + offset < arr.Length)

					//Recursion - Renter function with new start value (i + arr[i]) (STEP SIZE 1 )
					result = CanReach(arr, start + offset);

				//If not false and i-arr[i] >= 0 
				if (!result && start - offset >= 0)
					//Recursion - Renter function with new start value (i - arr[i]) (STEP SIZE 2)
					result = CanReach(arr, start - offset);
			}

			//Start value is now the end value (target node)
			memo[start] = result;
			return result;
		}


		static void Main(string[] args)
        {
			var s = new Solution();
			var array = new int[] { 3, 0, 2, 1, 2 };
			var start = 2;

			var answer = s.CanReach(array, start);

			if (answer)
            {
				Console.WriteLine($"It is possible to reach any index with value 0 with array ({String.Join(",", array.Select(x => x.ToString()).ToArray())}) from starting position {start}");
			}
            else
            {
				Console.WriteLine($"There is no way to reach any index with value 0 with array ({String.Join(",", array.Select(x => x.ToString()).ToArray())}) from starting position {start}");
			}
        }
    }
}
