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