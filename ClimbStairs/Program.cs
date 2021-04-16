using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ClimbStairs(5));
            Console.ReadLine();
        }
        public static int ClimbStairs(int n)
        {
            int x = 1, y = 1;
            for (int i = 2; i <= n; i++)
            {
                int sum = x + y;
                x = y;
                y = sum;
            }

            return y;
        }
    }
}
