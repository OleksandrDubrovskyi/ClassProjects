using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les_01_03
{
    class Program
    {
        enum EDays { Sunday = 1, Monday, Tueaday, Wednesday,
                    Thursday, Friday, Saturday }

        static void Main(string[] args)
        {
            

            int dayNumber = 8;
            EDays dayName;

            if (0 < dayNumber && dayNumber <= 7)
            {
                dayName = (EDays)dayNumber;
                Console.WriteLine("Day number {0} is {1}.\n", dayNumber, dayName);
            }              
            else
                Console.WriteLine("Invalid day number.\n");
        }
    }
}
