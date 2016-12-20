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
            string[] days = {"0", "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"};

            int x = 1;

            if (0 < x && x < days.Length)
                Console.WriteLine(days[x]);
            else
                Console.WriteLine("Wrong day number.");
        }