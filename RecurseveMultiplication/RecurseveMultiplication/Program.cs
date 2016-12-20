using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurseveMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Power(10, 10));
        }

        static long Power(long number, long power)
        {
            long result;

            if (power == 1)
            {
                result = number;
            }
            else
                result = number * Power(number, power - 1);

            return result;
        }
    }
}
