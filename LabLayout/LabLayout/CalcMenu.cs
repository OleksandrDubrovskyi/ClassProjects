using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLayout
{
    class CalcMenu
    {
        /// <summary>
        /// Methods of this class provide input/output operations
        /// for the SuperPuperCalc application.
        /// All calculations are executed in the SuperCalc.cs class
        /// </summary>
        
        public static void Start()
        {
            Console.WriteLine(ShowMenu());
            ShowMenuItem(Console.ReadLine());
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

        static void ShowMenuItem(string itemToShow)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("\nYou have chosen ");

                switch (itemToShow)
                {
                    case "1":
                        Console.WriteLine("Calculator. Please enter numbers to calculate.\n");
                        SimpleMath();
                        break;
                    case "2":
                        Console.WriteLine("VAT Calculator. Please enter the sum of your purchase.\n");
                        VATCalc();
                        break;
                    case "3":
                        Console.WriteLine("Loan Calculator. Please enter the details of your loan.\n");
                        LoanCalc();
                        break;
                    case "4":
                        Console.WriteLine("Income Calculator. Please enter your income brutto.\n");
                        IncomeTaxCalc();
                        break;
                    case "5":
                        Console.WriteLine("Investment Calculator. Please enter the details.\n");
                        InvestmentCalc();
                        break;
                    case "0":
                        Console.WriteLine("to quit the program. Welcome back later!\n");
                        Environment.Exit(0);
                        break;
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("No such item in the menu. Please try again.\n");
                            Console.WriteLine(ShowMenu());
                        }
                        break;
                }

                itemToShow = Console.ReadLine();
                if (itemToShow == "")
                {
                    Console.Clear();
                    Start();
                }
            }
        }

        static void SimpleMath()
        {
            double firsNumber, secondNumber, result;
            string mathOp, output;
            
            firsNumber = SuperCalc.ReceiveNumber();
            mathOp = SuperCalc.ReceiveSign();
            secondNumber = SuperCalc.ReceiveNumber();
            result = SuperCalc.Calculate(firsNumber, secondNumber, mathOp);

            output = String.Format("{0} {1} {2} = {3}\n", firsNumber, mathOp, secondNumber, result);
            Console.WriteLine(output);
        }

        static void VATCalc()
        {
            double sum = SuperCalc.ReceiveNumber();
            const double TAX = 0.17;

            SuperCalc.SumOutput((decimal)SuperCalc.Calculate(sum, TAX, "*"));
        }

        static void LoanCalc()
        {
            Console.WriteLine("Please, enter the sum of your loan.");
            double principal = SuperCalc.ReceiveNumber();

            Console.WriteLine("Please, enter your interest rate.");
            double rate = SuperCalc.ReceiveNumber();

            Console.WriteLine("Please, enter the period of your loan in months.");
            int months = (int)SuperCalc.ReceiveNumber();

            decimal interest = SuperCalc.InvestmentLoanCalc(principal, rate, months);
            SuperCalc.SumOutput(interest);
        }

        static void IncomeTaxCalc()
        {       
            decimal income = SuperCalc.IncomeTax((decimal)SuperCalc.ReceiveNumber());
            SuperCalc.SumOutput(income);
        }

        static void InvestmentCalc()
        {
            Console.WriteLine("Please, enter the sum of your deposit.");
            double principal = SuperCalc.ReceiveNumber();

            Console.WriteLine("Please, enter your interest rate.");
            double rate = SuperCalc.ReceiveNumber();

            Console.WriteLine("Please, enter the period of your deposit in months.");
            int months = (int)SuperCalc.ReceiveNumber();

            decimal interest = SuperCalc.InvestmentLoanCalc(principal, rate, months);
            SuperCalc.SumOutput(interest);
        }
    }
}
