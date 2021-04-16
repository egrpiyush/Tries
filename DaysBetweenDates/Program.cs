using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysBetweenDates
{
    class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Date(int day, int month, int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string date1 = "2020-01-15";
                var dt1Split = date1.Split('-');
                var d1 = new Date(Convert.ToInt32(dt1Split[2]), Convert.ToInt32(dt1Split[1]), Convert.ToInt32(dt1Split[0]));

                var dt1 = new Date(16, 12, 1901);
                var dt2 = new Date(10, 3, 2015);
                Console.WriteLine(DaysBetween(dt1, dt2));
                Console.ReadLine();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * Algo -->
         * n1 = no. of days before dt1 = (y1 * 365) + 31 + leapYearsCount1
         * where leapYearsCount1 = no. of leap years before dt1.
         * n2 = no. of days before dt2 = (y2 * 365) + 31 + leapYearsCount2
         * where leapYearsCount2 = no. of leap years before dt2.
         * AND
         * if m <= 2
         * leapYearsCount = floor((y - 1)/4) - floor((y - 1)/100) + floor((y - 1)/400)
         * if m > 2
         * leapYearsCount = floor(y/4) - floor(y/100) + floor(y/400)
         */

        static int[] monthDays = { 31, 28, 31,
                                   30, 31, 30,
                                   31, 31, 30,
                                   31, 30, 31
                                 };

        private static int DaysBetween(Date dt1, Date dt2)
        {
            var leapYearsCount1 = GetLeapYears(dt1);
            var leapYearsCount2 = GetLeapYears(dt2);
            var n1 = (dt1.Year * 365) + dt1.Day;
            var n2 = (dt2.Year * 365) + dt2.Day;

            for (int i = 0; i < dt1.Month - 1; i++)
                n1 += monthDays[i];
            n1 += GetLeapYears(dt1);

            for (int i = 0; i < dt2.Month - 1; i++)
                n2 += monthDays[i];
            n2 += GetLeapYears(dt2);


            return n2 - n1;
        }

        private static int GetLeapYears(Date dt)
        {
            var leapYearsCount = 0;
            if (dt.Month <= 2)
                leapYearsCount = ((dt.Year - 1) / 4) - ((dt.Year - 1) / 100) + ((dt.Year - 1) / 400);
            else
                leapYearsCount = ((dt.Year) / 4) - ((dt.Year) / 100) + ((dt.Year) / 400);

            return leapYearsCount;
        }
    }
}
