using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les_01_07
{
    enum EMonths { January = 1, February, March, April, May, June,
                   July, August, September, October, November, December }

    class Program
    {
        static void Main(string[] args)
        {
            string monthName = "May";

            CheckMonthName(monthName);
        }

        static void CheckMonthName(string monthName)
        {
            if (Enum.IsDefined(typeof(EMonths), monthName))
            {
                EMonths month;
                Enum.TryParse(monthName, out month);
                int monthNumber = (int)month;
                Console.WriteLine("{0} is month number {1}.", monthName, monthNumber);
            }
            else
                Console.WriteLine("{0} is a wrong month name.", monthName);
        }
    }
}
