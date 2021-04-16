using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AToI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Input:");
                var inputStr = Console.ReadLine();
                Console.WriteLine(string.Format("Input= {0}, Output = {1}", inputStr, AToI(inputStr)));
                Console.ReadLine();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         * string = "123", output = 123
         * string = "+123", output = 123
         */
        private static int AToI(string inputStr)
        {
            int retVal = 0;
            if (string.IsNullOrWhiteSpace(inputStr)) return retVal;

            var startIndex = (inputStr[0] == '+' || inputStr[0] == '-') ? 1 : 0;
            var isNegative = (inputStr[0] == '-') ? true : false;
            var temp = new StringBuilder();
            if (isNegative) temp.Append("-");
            for (int i = startIndex; i < inputStr.TrimStart().Length; i++)
            {
                if (Char.IsDigit(inputStr[i]))
                    temp.Append(inputStr[i]);
            }
            retVal = Convert.ToInt32(temp.ToString());
            return retVal;
        }
    }
}
