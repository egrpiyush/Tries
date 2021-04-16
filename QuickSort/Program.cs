using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 7, 4, 34, -4, 0, -10, 99 };
            var sorted = QuickSort(arr, 0, arr.Length);
            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        private static int[] QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(arr, start, end);
                QuickSort(arr, start, pivot);
                QuickSort(arr, pivot + 1, end);
            }
            return arr;
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[start];
            int pivotIndex = start;
            for (int i = start + 1; i < end; i++)
            {
                if (arr[i] < pivot)
                {
                    pivotIndex++;
                    Swap(arr, i, pivotIndex);
                }
            }
            Swap(arr, start, pivotIndex);//Rest pivot position.
            return pivotIndex;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
