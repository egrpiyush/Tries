using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigInt
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int quotient = 32 / 10;
                int remainder = 32 % 10;                

                var inputNumber1Arr = new int[] {  1, 6, 6 };
                var inputNumber2Arr = new int[] {  4, 6, 6 };
                var resAddition = DoBigIntAddition(inputNumber1Arr, inputNumber2Arr);
                Console.WriteLine(string.Join("", resAddition));
                Console.ReadLine();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static List<int> DoBigIntAddition(int[] inputNumber1Arr, int[] inputNumber2Arr)
        {
            var retVal = new List<int>();
            var lengthDiff = Math.Abs(inputNumber1Arr.Length - inputNumber2Arr.Length);
            var carryOver = 0;
            var firstArr = inputNumber1Arr.Length >= inputNumber2Arr.Length ? inputNumber1Arr : inputNumber2Arr;
            var secondArr = inputNumber1Arr.Length >= inputNumber2Arr.Length ? inputNumber2Arr : inputNumber1Arr;
            for (int i = firstArr.Length - 1; i >= 0; i--)
            {
                if (i - lengthDiff < 0)
                {
                    retVal.Add(firstArr[i] + carryOver);
                    break;
                }
                {
                    var sum = firstArr[i] + secondArr[i - lengthDiff] + carryOver;
                    if (sum >= 10)
                    {
                        carryOver = sum / 10;
                        retVal.Add(sum % 10);
                    }
                    else
                    {
                        retVal.Add(sum);
                        carryOver = 0;
                    }
                }
            }
            retVal.Reverse();
            return retVal;
        }

        //TODO:unfinished.
        private static List<int> DoBigIntMultiplication(int[] inputNumber1Arr, int[] inputNumber2Arr)
        {
            var retVal = new List<int>();
            var lengthDiff = Math.Abs(inputNumber1Arr.Length - inputNumber2Arr.Length);
            var carryOver = 0;
            var firstArr = inputNumber1Arr.Length >= inputNumber2Arr.Length ? inputNumber1Arr : inputNumber2Arr;
            var secondArr = inputNumber1Arr.Length >= inputNumber2Arr.Length ? inputNumber2Arr : inputNumber1Arr;
            for (int i = firstArr.Length - 1; i >= 0; i--)
            {
                if (i - lengthDiff < 0)
                {
                    retVal.Add(firstArr[i] + carryOver);
                    break;
                }
                {
                    var sum = (firstArr[i] * secondArr[i - lengthDiff]) + carryOver;
                    if (sum >= 10)
                    {
                        carryOver = sum / 10;
                        retVal.Add(sum % 10);
                    }
                    else
                    {
                        retVal.Add(sum);
                        carryOver = 0;
                    }
                }
            }
            retVal.Reverse();
            return retVal;
        }
    }
}
