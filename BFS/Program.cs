using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
/*
               *               1
               *             / | \
               *            2  5  9
               *           /  / \   \
               *          3  6   8   10
               *         /  / 
               *        4  7
               *
*/
    class Program
    {
        static void Main(string[] args)
        {
            #region Data
            IDictionary<int, List<int>> tree = new Dictionary<int, List<int>>();
            tree[0] = new List<int> { 1 };
            tree[1] = new List<int> { 2, 3, 4 };
            tree[2] = new List<int> { 5 };
            tree[3] = new List<int> { 6, 7 };
            tree[4] = new List<int> { 8 };
            tree[5] = new List<int> { 9 };
            tree[6] = new List<int> { 10 };
            #endregion
            HashSet<int> visited = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(1);
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (visited.Any(p => p == current))
                    continue;
                visited.Add(current);
                Console.WriteLine(current);
                List<int> children;
                tree.TryGetValue(Convert.ToInt32(current), out children);
                if (children == null) continue;

                foreach (var child in children)
                {
                    queue.Enqueue(child);
                }
            }
            Console.ReadLine();
        }
    }
}
