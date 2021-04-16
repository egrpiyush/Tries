using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBST
{

    // Definition for a binary tree node.
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
    class Program
    {
        private List<int> values;
        private long last;
        private bool ans;
        private bool IsValidBST(TreeNode root)
        {
            this.last = long.MinValue;
            this.ans = true;
            backtrack(root);
            return ans;
        }

        void backtrack(TreeNode node)
        {
            if (node == null)
                return;
            backtrack(node.left);
            if (node.val <= last)
            {
                ans = false;
                return;
            }
            last = node.val;
            backtrack(node.right);
        }

        static void Main(string[] args)
        {
            var treeNode = new TreeNode(5, new TreeNode(1), new TreeNode(4));
            var result = new BSTValidatorNew().IsValid(treeNode);
            Console.ReadLine();
        }
    }

    public class BSTValidatorNew
    {
        public  bool IsValid(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return IsValid(root.left, long.MinValue, root.val)
                && IsValid(root.right, root.val, long.MaxValue);
        }

        private bool IsValid(TreeNode node, long minVal, long maxVal)
        {
            if (node == null)
            {
                return true;
            }

            if (node.val <= minVal || maxVal <= node.val)
            {
                return false;
            }

            return IsValid(node.left, minVal, node.val)
                && IsValid(node.right, node.val, maxVal);
        }
    }

    public class BSTValidator
    {
        private List<int> values;
        private long last;
        private bool ans;
        public bool IsValidBST(TreeNode root)
        {
            this.last = long.MinValue;
            this.ans = true;
            backtrack(root);
            return ans;
        }

        void backtrack(TreeNode node)
        {
            if (node == null)
                return;
            backtrack(node.left);
            if (node.val <= last)
            {
                ans = false;
                return;
            }
            last = node.val;
            backtrack(node.right);
        }

    }
}
