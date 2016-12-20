using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_03_01
{
    class CalcNew
    {
        public static void GreetUser()
        {
			// boolean values to control while-loops
            bool isOK = true;
            bool isSign = false;
			
			//sign of the math operation
            string mathOp;
			
            double total = 0.0;

            double numberOne = ReceiveNumber();
            total = numberOne; //for the case if user presses = 
			                   //right after the first number

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
					//check if there is a division by 0
                    double numberTwo = ReceiveNumber();
                    bool zeroDivision = (mathOp == "/" && numberTwo == 0);

                    while (zeroDivision)
                    {
                        Console.WriteLine("Unable to divide by zero, please enter another number.");
                        numberTwo = ReceiveNumber();
                        zeroDivision = (numberTwo == 0);
                    }
                    
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
			//lacks checks for numeric input
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
