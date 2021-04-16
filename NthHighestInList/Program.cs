using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthHighestInList
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void thirdLargest(int[] arr, int arr_size)
        {
            /* There should be atleast three elements */
            if (arr_size < 3)
            {
                Console.Write(" Invalid Input ");
                return;

            }

            // Initialize first, second and third Largest element 
            int first = arr[0], second = int.MinValue,
                                    third = int.MinValue;

            // Traverse array elements to find the third Largest 
            for (int i = 1; i < arr_size; i++)
            {
                /* If current element is greater than first, 
                then update first, second and third */
                if (arr[i] > first)
                {
                    third = second;
                    second = first;
                    first = arr[i];
                }

                /* If arr[i] is in between first and second */
                else if (arr[i] > second)
                {
                    third = second;
                    second = arr[i];
                }
                /* If arr[i] is in between second and third */
                else if (arr[i] > third)
                {
                    third = arr[i];
                }
            }

            Console.Write("The third Largest element is " + third);
        }
    }
}
