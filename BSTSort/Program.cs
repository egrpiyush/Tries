using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTSort
{
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
    public class Helper
    {
        public TreeNode Insert(TreeNode node, int value)
        {
            if (node == null) return new TreeNode(value);

            if (value <= node.val)
                node.left = Insert(node.left, value);
            else if (value >= node.val)
                node.right = Insert(node.right, value);
            return node;
        }

        List<int> retVal = new List<int>();
        public List<int> InOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InOrderTraversal(root.left);
                retVal.Add(root.val);
                InOrderTraversal(root.right);
            }
            return retVal;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode node = null;
            int[] input = new int[] { 5, 4, 7, 2, 11 };
            var helper = new Helper();
            for (int i = 0; i < input.Length; i++)
            {
                node = helper.Insert(node, input[i]);
            }
            var sortedTree = helper.InOrderTraversal(node);

            Console.ReadLine();
        }
    }
}
