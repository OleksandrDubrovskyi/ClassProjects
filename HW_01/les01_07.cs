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
								 
            string mon = "klgh";
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