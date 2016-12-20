using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_03_01
{
    class Calculator
    {
        public static void GreetUser()
        {
            bool isOK = true;
            bool isSign = false;
            string mathOp;
            double total = 0.0;

            double numberOne = ReceiveNumber();
            total = numberOne;

            while (isOK)
            {
                mathOp = ReceiveSign();

                while (!isSign)
                {
                    if (mathOp == "+" || mathOp == "-" || mathOp == "*" || mathOp == "/" || mathOp == "=")
                    {
                        isSign = true;
                    }
                    else
                    {
                        isSign = false;
                        mathOp = ReceiveSign();
                    }
                }

                if (mathOp == "=")
                {
                    isOK = false;
                    Console.WriteLine("Total is {0}", total);
                }
                else
                {
                    double numberTwo = ReceiveNumber();
                    total = Calculate(numberOne, numberTwo, mathOp);
                    numberOne = total;
                }
            }
        }

        static double Calculate(double x, double y, string sign)
        {
            double result = 0.0;

            switch (sign)
            {
                case "+":
                    result = x + y;
                    break;

                case "-":
                    result = x - y;
                    break;

                case "*":
                    result = x * y;
                    break;

                case "/":
                    result = x / y;
                    break;
            }
            return result;
        }

        static double ReceiveNumber()
        {
            Console.WriteLine("\nEnter number");
            string input = Console.ReadLine();
            double numberOne = double.Parse(input);

            return numberOne;
        }

        static string ReceiveSign()
        {
            Console.WriteLine("\nEnter sign");
            string sign = Console.ReadLine();

            return sign;
        }
    }
}
