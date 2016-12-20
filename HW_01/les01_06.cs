using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = {"Zero", "Jan", "Feb",
                                 "Mar", "Apr", "May",
                                 "Jun", "Jul", "Aug",
                                 "Sep", "Oct", "Nov", "Dec"};
            int x = 4;

            if (0 < x && x < months.Length)
                Console.WriteLine("Month number " + x + " is " + months[x] + ".\n");
            else
                Console.WriteLine("Invalid month number.");
        }