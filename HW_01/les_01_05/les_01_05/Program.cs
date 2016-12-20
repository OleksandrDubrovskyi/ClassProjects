using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les_01_05
{
    enum ESeasons { Winter, Spring, Summer, Autumn }

    enum EMonths { January = 1, February, March, April, May, June,
                   July, August, September, October, November, December }

    class Program
    {
        const int MONTHS_IN_YEAR = 12;
        const int MONTHS_IN_SEASON = 3;

        static void Main(string[] args)
        {
            int monthNumber = 0;

            CheckMonthNumber(monthNumber);
        }

        static void CheckMonthNumber(int monthNumber)
        {
            if (0 < monthNumber && monthNumber <= MONTHS_IN_YEAR)
                MonthToSeason(monthNumber);
            else
                Console.WriteLine("{0} is not a valid month number.", monthNumber);
        }

        static void MonthToSeason(int monthNumber)
        {
            EMonths month = (EMonths)monthNumber;

            //line-up months from December to November
            int seasonNumber = (monthNumber % MONTHS_IN_YEAR) / MONTHS_IN_SEASON;
            ESeasons season = (ESeasons)seasonNumber;

            Console.WriteLine("{0} is a {1} month.\n", month, season);
        }
    }
}
