using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Inorder_Traversal
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
        List<int> retVal = new List<int>();
        /*
         * traverse left tree
         * traverse root
         * traverse right tree
         */
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
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3, null, null), null));//[1,3,2]
            //var tree = new TreeNode();//[]
            //var tree = new TreeNode(1);//[1]
            //var tree = new TreeNode(1, null, new TreeNode(2));//[1,2]
            Helper helper = new Helper();
            var result = helper.InOrderTraversal(tree);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            };
            Console.ReadLine();
        }
    }
}
