using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLayout
{
    class SuperCalc
    {
        public static void Start()
        {
            Console.WriteLine(ShowMenu());

            string usersChoice = Console.ReadLine();

            while (true)
            {
                switch (usersChoice)
                {
                    case "1":
                        SimpleMath();
                        break;
                    case "2":
                        VATCalc();
                        break;
                    case "3":
                        LoanCalc();
                        break;
                    case "4":
                        IncomeTaxCalc();
                        break;
                    case "5":
                        InvestmentCalc();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("No such item in the menu. Try again.\n");
                            Console.WriteLine(ShowMenu());
                        }
                        break;
                }

                usersChoice = Console.ReadLine();
                if (usersChoice == "")
                {
                    Console.Clear();
                    Start();
                }
            }

        }

        static void SimpleMath()
        {
            Console.Clear();
            Console.WriteLine("You have chosen a Simple Math Calculator. Please enter your numbers.");

            double firsNumber, secondNumber, result;
            string mathOp;
            bool isSign = false;

            firsNumber = ReceiveNumber();
            mathOp = ReceiveSign();

            while (!isSign)
            {
                if (mathOp == "+" || mathOp == "-" || mathOp == "*" || mathOp == "/" || mathOp == "\\")
                {
                    isSign = true;
                }
                else
                {
                    isSign = false;
                    mathOp = ReceiveSign();
                }
            }

            secondNumber = ReceiveNumber();
            result = Calculate(firsNumber, secondNumber, mathOp);
            Console.WriteLine(result);
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

                case "\\":
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

        static void VATCalc()
        {
            Console.Clear();
            Console.WriteLine("You have chosen a VAT Calculator. Please enter the sum of your purchase.");

            double sum = ReceiveNumber();
            const double TAX = 0.17;

            double vat = Calculate(sum, TAX, "*");

            Console.WriteLine("Your tax sum is {0}.", vat);
        }

        static void LoanCalc()
        {
            Console.Clear();
            Console.WriteLine("Hello user!");
        }

        static void IncomeTaxCalc()
        {
            Console.Clear();
            Console.WriteLine("You have chosen a Income Tax Calculator. Please enter your salary");

            const int GRADE1 = 6220;
            const int GRADE2 = 8290;
            const int GRADE3 = 13680;
            const int GRADE4 = 19800;
            const int GRADE5 = 41410;

            const double INC_TAX1 = 0.00;
            const double INC_TAX2 = 0.14;
            const double INC_TAX3 = 0.20;
            const double INC_TAX4 = 0.31;
            const double INC_TAX5 = 0.35;
            const double INC_TAX6 = 0.47;

            const double GRADE3_TAX = (GRADE2 - GRADE1) * INC_TAX2;
            const double GRADE4_TAX = ((GRADE3 - GRADE2) * INC_TAX3) + GRADE3_TAX;
            const double GRADE5_TAX = ((GRADE4 - GRADE3) * INC_TAX4) + GRADE4_TAX;
            const double GRADE6_TAX = ((GRADE5 - GRADE4) * INC_TAX5) + GRADE5_TAX;

            double salary = ReceiveNumber();
            double incomeTax;

            if (salary <= GRADE1)
            {
                incomeTax = INC_TAX1;
            }
            else if (salary <= GRADE2)
            {
                incomeTax = (salary - GRADE1) * INC_TAX2;
            }
            else if (salary <= GRADE3)
            {
                incomeTax = ((salary - GRADE2) * INC_TAX3) + GRADE3_TAX;
            }
            else if (salary <= GRADE4)
            {
                incomeTax = ((salary - GRADE3) * INC_TAX4) + GRADE4_TAX;
            }
            else if (salary <= GRADE5)
            {
                incomeTax = ((salary - GRADE4) * INC_TAX5) + GRADE5_TAX;
            }
            else
            {
                incomeTax = ((salary - GRADE5) * INC_TAX6) + GRADE6_TAX;
            }

            Console.WriteLine("You owe {0} shekels to the State of Israel!", incomeTax);
        }

        static void InvestmentCalc()
        {
            Console.Clear();
            Console.WriteLine("Hello user!");
        }

        static string ShowMenu()
        {
            string userMenu =
                @"Welcome to the Super Calculator v. 0.1

Please make your choice:

1. Simple Math Calculator.
2. VAT Calculator.
3. Loan Calculator.
4. Income Tax Calculator.
5. Short Term Investment Calculator.
--------------------------------------
0. Quit the program.
";
            return userMenu;
        }
    }
}
