using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = {"Zero", "Jan", "Feb",
                                 "Mar", "Apr", "May",
                                 "Jun", "Jul", "Aug",
                                 "Sep", "Oct", "Nov", "Dec"};

            Months("Sep", months);
        }

        static void Months(int x, string[] months)
        {
            if (0 < x && x < months.Length)
                Console.WriteLine("Month number " + x + " is " + months[x] + ".\n");
            else
                Console.WriteLine("Invalid month number.");
        }

        static void Months(string month, string[] months)
        {
            bool isMonth = false;

            for (int i = 1; i < months.Length; i++)
            {
                if (months[i] == month)
                {
                    isMonth = true;
                    Console.WriteLine(month + " is month number " + i + ".\n");
                    break;
                }
            }
            if (!isMonth)
                Console.WriteLine("Invalid month name.");
        }
    }
}