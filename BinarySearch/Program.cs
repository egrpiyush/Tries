using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchFor = 8;
            var searchForIndex = 0;
            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var midIndex = (input.Length) / 2;
            var midNumber = input[midIndex];

            var lowerBound = 0; var uppberBound = 0;
            if (searchFor <= midNumber)
            { lowerBound = 0; uppberBound = midIndex; }
            if (searchFor > midNumber)
            { lowerBound = midIndex; uppberBound = input.Length - 1; }
            for (int i = lowerBound; i <= uppberBound; i++)
            {
                if (input[i] == searchFor)
                {
                    searchForIndex = i;
                    break;
                }
            }
            Console.WriteLine("Found at:" + searchForIndex);
            Console.ReadLine();
        }
    }
}
