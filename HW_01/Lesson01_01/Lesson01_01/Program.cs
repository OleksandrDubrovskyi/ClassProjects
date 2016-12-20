using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            MonthToNumber();
        }

        static void PositiveNegative()
        {
            int x = -16;

            if (x > 0)
                Console.WriteLine("Positive.");
            else
                Console.WriteLine("Negative or zero.");
        }

        static void Age()
        {
            int x = 16;

            /*
            if ((x - 18) * (55 - x) >= 0) // ((x - 17) * (56 - x) > 0) // (17 < x && x < 56)
                Console.WriteLine("Accepted.");
            else
                Console.WriteLine("Denied.");
            */

            /*
            if (!(x < 18 || x > 56))
                Console.WriteLine("Accepted.");
            else
                Console.WriteLine("Denied.");
            */

            /*
            if (!(x < 18) && !(x > 56))
                Console.WriteLine("Accepted.");
            else
                Console.WriteLine("Denied.");
            */

            if (x < 18 || x > 56)
               Console.WriteLine("Denied.");
           else
               Console.WriteLine("Accepted.");
          
        }

        static void DaysOfWeek()
        {
            string[] days = {"0", "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"};

            int x = 1;

            if (0 < x && x < days.Length)
                Console.WriteLine(days[x]);
            else
                Console.WriteLine("Wrong day number.");
        }

        static void SimpleMath()
        {
            float x = 5; float y = 6;

            Console.WriteLine("x + y = " + (x + y));
            Console.WriteLine("x - y = " + (x - y));
            Console.WriteLine("x * y = " + (x * y));
            Console.WriteLine("x / y = " + Math.Round((x / y), 3));

            //double example = 12.34567;
            //Console.Out.WriteLine(example.ToString("#.000"));
        }

        static void Seasons()
        {
            string[] seasons = {"Zero", "Winter", "Winter",
                                 "Spring", "Spring", "Spring",
                                 "Summer", "Summer", "Summer",
                                 "Autumn", "Autumn", "Autumn", "Winter"};
            int x = 8;

            if (0 < x && x < seasons.Length)
                Console.WriteLine(seasons[x]);
            else
                Console.WriteLine("Invalid month number.");
        }

        static void Months()
        {
            string[] months = {"Zero", "Jan", "Feb",
                                 "Mar", "Apr", "May",
                                 "Jun", "Jul", "Aug",
                                 "Sep", "Oct", "Nov", "Dec"};
            int x = 4;

            if (0 < x && x < months.Length)
                Console.WriteLine(months[x]);
            else
                Console.WriteLine("Invalid month number.");
        }

        static void MonthToNumber()
        {
            string[] months = {"Zero", "Jan", "Feb",
                                 "Mar", "Apr", "May",
                                 "Jun", "Jul", "Aug",
                                 "Sep", "Oct", "Nov", "Dec"};
            string mon = "Mar";
            bool isMonth = false;

            for (int i = 1; i < months.Length; i++)
            {
                if (months[i] == mon)
                {
                    isMonth = true;
                    Console.WriteLine(mon + " is month number " + i + ".\n");
                    break;
                }
            }
            if (!isMonth)
                Console.WriteLine("Invalid month name.");
        }
    }
}
