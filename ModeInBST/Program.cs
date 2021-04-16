using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeInBST
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
        public int[] FindMode(TreeNode root)
        {
            var result = InOrderTraversal(root);
            var grouped = result.GroupBy(p => p);
            var customList = grouped.Select(p => new { Element = p.Key, Count = p.Count() });
            var maxCount = customList.Max(p => p.Count);
            var t = grouped.Where(p => p.Count() == maxCount);
            return grouped.Where(p => p.Count() == maxCount).SelectMany(p => p).Distinct().ToArray();
        }

        List<int> retVal = new List<int>();
        private List<int> InOrderTraversal(TreeNode root)
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
            //var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(2, null, null), null));//[2]
            //var tree = new TreeNode(1, null, new TreeNode(2));//[2, 1]
            var tree = new TreeNode();
            Helper helper = new Helper();
            var ans = helper.FindMode(tree);
            Console.ReadLine();
        }
    }
}
