using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division
{
    class Result
    {
        public int Quotient { get; set; }
        public int Remainder { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int dividend = -2147483648;
                int divisor = -1;

                var result = Divide(dividend, divisor);
                Console.WriteLine(result.Quotient + "  " + result.Remainder);
                Console.ReadLine();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         * Approach : Keep subtracting the dividend from divisor until dividend becomes less than divisor. 
         * The dividend becomes the remainder, and the number of times subtraction is done becomes the quotient
         */
        private static Result Divide(int dividend, int divisor)
        {            
            var result = new Result();
            if (dividend == 0 || divisor == 0) return result;
            var count = 0;
            var sign = (dividend < 0) || (divisor < 0) ? -1 : 1;
            sign = (dividend < 0) && (divisor < 0) ? 1 : sign;
            var _dividend = dividend;
            var _divisor = divisor;

            if (_dividend <= int.MinValue)
                _dividend += 1;
            if (_dividend >= int.MaxValue)
                _dividend -= 1;

            if (_divisor <= int.MinValue)
                _divisor += 1;
            if (_divisor >= int.MaxValue)
                _divisor -= 1;
            _dividend = Math.Abs(_dividend);
            _divisor = Math.Abs(_divisor);
            while (_dividend >= _divisor)
            {
                _dividend -= _divisor;
                count++;
            }
            result.Remainder = _dividend;
            result.Quotient = sign * count;
            return result;
        }
    }
}
