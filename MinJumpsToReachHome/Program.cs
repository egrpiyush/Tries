using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinJumpsToReachHome
{
    class Program
    {
        static void Main(string[] args)
        {
            var forbidden = new int[] { 8, 3, 16, 6, 12, 20 };
            var a = 15;
            var b = 13;
            var x = 7;
            var jumps = MinimumJumps(forbidden, a, b, x);
            Console.WriteLine(jumps);
            Console.ReadLine();
        }

        public static int MinimumJumps(int[] forbidden, int a, int b, int x)
        {
            var invalid = new HashSet<int>(forbidden);
            var visited = new HashSet<(int, bool)>();
            var que = new Queue<(int Pos, bool IsBackward)>();
            que.Enqueue((0, false));
            int steps = 0;
            while (que.Count > 0)
            {
                int count = que.Count;
                while (count-- > 0)
                {
                    var cur = que.Dequeue();
                    if (cur.Pos == x) return steps;
                    if (invalid.Contains(cur.Pos) || visited.Contains(cur)) continue;
                    visited.Add(cur);
                    if (cur.Pos + a <= 4000)
                        que.Enqueue((cur.Pos + a, false));
                    if (cur.Pos - b >= 0 && !cur.IsBackward)
                        que.Enqueue((cur.Pos - b, true));
                }
                steps++;
            }

            return -1;
        }
    }
}
