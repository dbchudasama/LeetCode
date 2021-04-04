using System;

namespace ValidateBST
{
    class Solution
    {

        //SOLUTION FOR LEETCODE QUESTION:
        //98 - VALIDATE BINARY TREE
        //*****DIFFICULTY - MEDIUM*****



        /// <summary>
        /// Method that returns if a Binary Search Tree is Valid or not
        /// </summary>
        /// <param name="root"></param>
        /// <returns>True or False</returns>
        public bool IsValidBST(TreeNode root)
        {
            return Validate(root, long.MinValue, long.MaxValue);
        }


        /// <summary>
        /// Method to Validate Binary Search Tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns>True or False</returns>
        public bool Validate(TreeNode root, long low, long high)
        {
            //If null then return true
            if (root == null)
            {
                return true;
            }

            // This cannot be true as for a BST all right hand nodes need to be higher than it and all nodes on the left hand side to be lower
            if (root.val <= low || root.val >= high)
            {
                return false;
            }

            //Recursion
            return Validate(root.left, low, root.val) && Validate(root.right, root.val, high);
        }


        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        static void Main(string[] args)
        {
            var s = new Solution();
            var t = new TreeNode();
            s.IsValidBST(t);

        }
    }
}
