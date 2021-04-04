using System;
using System.Linq;

namespace MeetingRoomsII
{
    class Solution
    {

        //SOLUTION FOR LEETCODE QUESTION:
        //253 - MEETING ROOMS II - Given an array of meeting time intervals intervals where intervals[i] = [starti, endi],
        //return the minimum number of conference rooms required.
        //*****DIFFICULTY - MEDIUM*****


        /// <summary>
        /// Method the returns minimum number of meeting rooms needed given an array of meeting intervals
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns>Number of meeting rooms</returns>
        public int MinMeetingRooms(int[][] intervals)
        {
            //Sort intervals by starting time
            Array.Sort(intervals, (item1, item2) => { return item1[0].CompareTo(item2[0]); });

            //Invoking MiniHeap class
            var minHeap = new MinHeap(intervals.Length);
            //Add the end time of the first interval to the MinHeap
            minHeap.Add(intervals[0][1]);

            //For each other interval, check if the start time is less than the current min on heap
            for (int i = 1; i < intervals.Length; i++)
            {
                //If true add the end of current interval to MinHeap
                if (intervals[i][0] >= minHeap.Peek())
                    minHeap.Pop();

                //If false, pop the min and add the current end time to heap
                minHeap.Add(intervals[i][1]);
            }

            //The number of elements left in the MinHeap will tell us the number of rooms needed
            return minHeap.Count();
        }



        /// <summary>
        /// As C# does not contain a Heap Class, creating one
        /// </summary>
        public class MinHeap
        {
            private readonly int[] _elements;
            private int _size;

            public MinHeap(int size)
            {
                _elements = new int[size];
            }

            private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
            private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
            private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

            private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
            private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
            private bool IsRoot(int elementIndex) => elementIndex == 0;

            private int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
            private int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
            private int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];


            /// <summary>
            /// Method to swap node values around
            /// </summary>
            /// <param name="firstIndex"></param>
            /// <param name="secondIndex"></param>
            private void Swap(int firstIndex, int secondIndex)
            {
                var temp = _elements[firstIndex];
                _elements[firstIndex] = _elements[secondIndex];
                _elements[secondIndex] = temp;
            }

            public bool IsEmpty()
            {
                return _size == 0;
            }

            public bool IsFull()
            {
                return _size == _elements.Length;
            }

            public int Count()
            {
                return _size;
            }


            /// <summary>
            /// Method that just returns the first value from the heap
            /// </summary>
            /// <returns>First Value from heap</returns>
            public int Peek()
            {
                if (_size == 0)
                    throw new IndexOutOfRangeException();

                return _elements[0];
            }


            /// <summary>
            /// Method that returns the top most value of the heap
            /// </summary>
            /// <returns>Top value of the Heap</returns>
            public int Pop()
            {
                if (_size == 0)
                    throw new IndexOutOfRangeException();

                var result = _elements[0];
                //The last element becomes the first element in the array
                _elements[0] = _elements[_size - 1];
                _size--;

                //Here we will swap indexes if conditions are met
                ReCalculateDown();

                return result;
            }


            /// <summary>
            /// Method to add new node to heap
            /// </summary>
            /// <param name="element"></param>
            public void Add(int element)
            {
                if (_size == _elements.Length)
                    throw new IndexOutOfRangeException();

                _elements[_size] = element;
                _size++;

                ReCalculateUp();
            }


            /// <summary>
            /// Method that recalculates the MinHeap after a node deletion
            /// </summary>
            private void ReCalculateDown()
            {
                int index = 0;
                while (HasLeftChild(index))
                {
                    var smallerIndex = GetLeftChildIndex(index);
                    if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                    {
                        //If the right hand child node is less than the left hand index, it replaces the smallerIndex Value
                        smallerIndex = GetRightChildIndex(index);
                    }

                    if (_elements[smallerIndex] >= _elements[index])
                    {
                        break;
                    }

                    //Swapping indexes
                    Swap(smallerIndex, index);
                    index = smallerIndex;
                }
            }


            /// <summary>
            /// Method that recalculates the MinHeap after a node addition
            /// </summary>
            private void ReCalculateUp()
            {
                //Last node
                var index = _size - 1; 

                //As long as the current node is not the root node and the last node is less than the parent node in value
                while (!IsRoot(index) && _elements[index] < GetParent(index))
                {
                    //Swap parent node and last node around
                    var parentIndex = GetParentIndex(index);
                    Swap(parentIndex, index);
                    index = parentIndex;
                }
            }
        }


        static void Main(string[] args)
        {
            var s = new Solution();
            var array = new int[][] { new int [] { 0, 30 } , new int [] { 5, 10 } , new int [] { 15, 20 } };
            var rooms = s.MinMeetingRooms(array);

            Console.WriteLine($"The number of minimum meeting rooms required for the meetings ({String.Join(",", array.SelectMany(x => x.Select(y => y.ToString())).ToArray())}) are {rooms}");
        }
    }
}
