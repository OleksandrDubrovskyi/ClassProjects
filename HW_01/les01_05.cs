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