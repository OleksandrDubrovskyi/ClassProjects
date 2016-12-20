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
            //input data
            double firstNumber = 5; double secondNumber = 0;

            //calculations
            double sum = Addition(firstNumber, secondNumber);
            double difference = Substraction(firstNumber, secondNumber);
            double product = Multiplication(firstNumber, secondNumber);

            //data output
            Console.WriteLine(" {0} + {1} = {2}\n", firstNumber, secondNumber, sum);
            Console.WriteLine(" {0} - {1} = {2}\n", firstNumber, secondNumber, difference);
            Console.WriteLine(" {0} × {1} = {2}\n", firstNumber, secondNumber, product);
            Division(firstNumber, secondNumber);
        }

        static double Addition(double summandOne, double summandTwo)
        {
            double sum = summandOne + summandTwo;

            return sum;
        }

        static double Substraction(double minuend, double subtrahend)
        {
            double difference = minuend - subtrahend;

            return difference;
        }

        static double Multiplication(double multiplier, double multiplicand)
        {
            double product = multiplier * multiplicand;

            return product;
        }

        static void Division(double divident, double divisor)
        {
            if(divisor != 0)
			{
				double rawQuotient = divident / divisor;
				double quotient = Math.Round(rawQuotient, 3);

                Console.WriteLine(" {0} ÷ {1} = {2}\n", divident, divisor, quotient);
			}
			else
				Console.WriteLine("Unable to divide by zero, please enter another divisor.\n");
        }
    }

}