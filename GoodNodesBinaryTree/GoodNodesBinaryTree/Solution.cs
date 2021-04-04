using System;

namespace GoodNodesBinaryTree
{

    class Solution
    {


        //SOLUTION FOR LEETCODE QUESTION:
        //1448 - COUNT GOOD NODES IN BINARY TREE
        //*****DIFFICULTY - MEDIUM*****

        //Given a binary tree root, a node X in the tree is named good if in the path from root to X there
        //are no nodes with a value greater than X.

        /// <summary>
        /// Method that returns number of good nodes in a Binary Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns>Number of Good Nodes</returns>
        public int GoodNodes(TreeNode root)
        {
            if (root == null) 
            { 
                return 0; 
            }

            //Starting with 0 good nodes
            int goodNodeCount = 0;

            //Function call to Traverse Binary Tree
            Traverse(root, root.val, ref goodNodeCount);

            return goodNodeCount;
        }



        /// <summary>
        /// Method to Traverse Binary Tree using DEPTH FIRST SEARCH
        /// </summary>
        /// <param name="node"></param>
        /// <param name="maxPathValue"></param>
        /// <param name="goodNodeCount"></param>
        private void Traverse(TreeNode node, int maxPathValue, ref int goodNodeCount)
        {
            if (node == null)
            { 
                return; 
            }

            //Checking maximum path value and if greater than root node value make the root node value Max Value for path
            if (maxPathValue <= node.val) 
            { 
                maxPathValue = node.val;
                //Iterate Counter
                goodNodeCount++; 
            }

            //Recursion to check both sides of the tree
            Traverse(node.left, maxPathValue, ref goodNodeCount);
            Traverse(node.right, maxPathValue, ref goodNodeCount);
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
            var node = new TreeNode( );
            var treeNode = new TreeNode(3, node.left, node.right);
            s.GoodNodes(treeNode);

            //SOLUTION WORKS IN LEETCODE. TESTED!
        }
    }
}
