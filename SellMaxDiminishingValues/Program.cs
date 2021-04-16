using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellMaxDiminishingValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var inventory = new int[] { 1000000000 };
            var orders = 1000000000;
            Console.WriteLine(MaxProfitNew(inventory, orders));
            Console.ReadLine();
        }

        public static int MaxProfitNew(int[] inventory, int orders)
        {            
            var orderedHashedInventory = new HashSet<int>(inventory.OrderByDescending(p => p));
            var listProcessed = new List<int>();

            var maximum = orderedHashedInventory.Max();
            var currentMax = maximum;
            var prevMultiple = 1;
            var multipleCnt = 0;
            while (multipleCnt < orders)
            {
                var matches = orderedHashedInventory.Where(p => p != maximum && p == currentMax).Count();
                var multiple =  matches == 0 ? prevMultiple * 1 : matches + prevMultiple;
                listProcessed.Add(currentMax * multiple);
                currentMax = --currentMax;
                prevMultiple = multiple;
                multipleCnt += multiple;                
            }

            return listProcessed.Sum();
        }

        public static int MaxProfit(int[] inventory, int orders)
        {
            long low = 0;
            long high = inventory.Max();
            while (low < high)
            {
                long mid = low + (high - low) / 2;
                long sum = inventory.Sum(x => Math.Max(0, x - mid));
                if (sum <= orders)
                    high = mid;
                else
                    low = mid + 1;
            }

            long mod = (long)Math.Pow(10, 9) + 7;
            long res = 0;
            foreach (int n in inventory)
            {
                if (n > low)
                {
                    res = (res + (low + 1 + n) * (n - low) / 2) % mod;
                    orders -= (int)(n - low);
                }
            }

            res = (res + orders * low) % mod;

            return (int)res;
        }
    }
}
