using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidFlood
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //int[] rains = new int[] { 1, 2, 3, 4 };
                //int[] rains = new int[] { 1, 2, 0, 0, 2, 1 };//-1,-1,2,1,-1,-1]
                int[] rains = new int[] { 1, 2, 0, 2, 3, 0, 1 };//[-1,-1,2,-1,-1,1,-1]
                var result = AvoidFlood(rains);
                foreach (var item in result)
                {
                    Console.Write(string.Format("{0},", item));
                }
                Console.ReadLine();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //TODO: getting time limit. Find a better way.
        public static int[] AvoidFlood(int[] rains)
        {
            var retVal = new List<int>();
            if (rains.Length <= 0) return retVal.ToArray();
            var floodedStack = new List<int>();
            for (int i = 0; i < rains.Length; i++)
            {
                if (rains[i] == 0)
                    retVal.Add(floodedStack.Count == 0 ? 1 : GetPoppedItem(rains, floodedStack, i));
                else
                {
                    if (floodedStack.Any(p => p == rains[i]))
                    {
                        retVal.Clear(); return retVal.ToArray();
                    }
                    floodedStack.Add(rains[i]);
                    retVal.Add(-1);
                }
            }

            return retVal.ToArray();
        }

        private static int GetPoppedItem(int[] rains, List<int> floodedStack, int currentIndex)
        {
            for (int i = currentIndex + 1; i < rains.Length; i++)
            {
                for (int j = 0; j < floodedStack.Count; j++)
                {
                    if (rains[i] == floodedStack.ElementAt(j))
                    {
                        var poppedVal = floodedStack.ElementAt(j);
                        floodedStack.RemoveAt(j);
                        return poppedVal;
                    }
                }
            }

            //for (int i = 0; i < floodedStack.Count; i++)
            //{
            //    for (int j = currentIndex + 1; j < rains.Length; j++)
            //    {
            //        if (rains[j] == floodedStack.ElementAt(i))
            //        {
            //            floodedStack.RemoveAt(i);
            //            return floodedStack.ElementAt(i);
            //        }
            //    }
            //    //if (rains.Any(p => p == floodedStack.ElementAt(i)))
            //    //{
            //    //    floodedStack.RemoveAt(i);
            //    //    return floodedStack.ElementAt(i);
            //    //}
            //}
            //foreach (var item in floodedStack)
            //{
            //    if (rains.Any(p => p == item))
            //    {
            //        return item;
            //    }
            //}
            return 1;
        }
    }
}
