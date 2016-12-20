using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les_01_08
{
    enum EMonths
    {
        January = 1, February, March, April, May, June,
        July, August, September, October, November, December
    }

    class Program
    {
        const int MONTHS_IN_YEAR = 12;

        static void Main(string[] args)
        {
            int monthNumber = 8;
            string monthName = "May";

            CheckMonthNumber(monthNumber);
            CheckMonthName(monthName);
        }

        static void CheckMonthNumber(int monthNumber)
        {
            if (0 < monthNumber && monthNumber <= MONTHS_IN_YEAR)
            {
                EMonths month = (EMonths)monthNumber;
                Console.WriteLine("Month number {0} is {1}.\n", monthNumber, month);
            }
            else
                Console.WriteLine("{0} is invalid month number.\n", monthNumber);
        }

        static void CheckMonthName(string monthName)
        {
            if (Enum.IsDefined(typeof(EMonths), monthName))
            {
                EMonths month;
                Enum.TryParse(monthName, out month);
                int monthNumber = (int)month;
                Console.WriteLine("{0} is month number {1}.\n", monthName, monthNumber);
            }
            else
                Console.WriteLine("{0} is a wrong month name.\n", monthName);
        }
    }
}
