using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLayout
{
    class SuperCalc
    {
        /// <summary>
        /// Methods of this class are used for processing of the data received from
        /// the CalcMenu.cs class and provide respective calculations and formating.
        /// </summary>

        public static double Calculate(double x, double y, string sign)
        {
            //Division by zero check
            if (y == 0 && (sign == "/" || sign == "\\"))
            {
                DivideByZeroException e = new DivideByZeroException();
                Console.WriteLine(e.Message);
            }

            //For variables of the type double, the operation of
            //division by zero is actually defined. That's why we
            //continue the application even after rasing the exception.

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
                case "\\":
                    result = x / y;
                    break;
            }
            return result;
        }

        public static decimal IncomeTax(decimal income)
        {
            //Brutto income in NIS to be taxed with different tax rates.
            const decimal GRADE1 = 6220.00m;
            const decimal GRADE2 = 8290.00m;
            const decimal GRADE3 = 13680.00m;
            const decimal GRADE4 = 19800.00m;
            const decimal GRADE5 = 41410.00m;

            //Income tax rates applied to the brutto income of respective grades.
            const decimal INC_TAX1 = 0.00m;
            const decimal INC_TAX2 = 0.14m;
            const decimal INC_TAX3 = 0.20m;
            const decimal INC_TAX4 = 0.31m;
            const decimal INC_TAX5 = 0.35m;
            const decimal INC_TAX6 = 0.47m; //Applied to the income of over 41410.00 NIS.

            //Only income over certain sum is taxed with the rate applied to that grade.
            //Here are the BASE RATE calculations for the respective grades.
            //Base rate for GRADE1 and GRADE2 == 0.00 NIS.
            const decimal GRADE3_BASE = (GRADE2 - GRADE1) * INC_TAX2;
            const decimal GRADE4_BASE = ((GRADE3 - GRADE2) * INC_TAX3) + GRADE3_BASE;
            const decimal GRADE5_BASE = ((GRADE4 - GRADE3) * INC_TAX4) + GRADE4_BASE;
            const decimal GRADE6_BASE = ((GRADE5 - GRADE4) * INC_TAX5) + GRADE5_BASE;

            decimal incomeTax = 0.0m;

            if (income <= GRADE1)
            {
                incomeTax = INC_TAX1;
            }
            else if (income <= GRADE2)
            {
                incomeTax = (income - GRADE1) * INC_TAX2;
            }
            else if (income <= GRADE3)
            {
                incomeTax = ((income - GRADE2) * INC_TAX3) + GRADE3_BASE;
            }
            else if (income <= GRADE4)
            {
                incomeTax = ((income - GRADE3) * INC_TAX4) + GRADE4_BASE;
            }
            else if (income <= GRADE5)
            {
                incomeTax = ((income - GRADE4) * INC_TAX5) + GRADE5_BASE;
            }
            else
            {
                incomeTax = ((income - GRADE5) * INC_TAX6) + GRADE6_BASE;
            }

            return incomeTax;
        }

        public static decimal InvestmentLoanCalc(double principal, double rate, int months)
        {
            /*  The formula of compound interest we use here:
            
                A = P*(1 + r/n)^(n*t)
            
                Where:
                A = the future value of the investment/loan, including interest
                P = the principal investment amount(the initial deposit or loan amount)
                r = the annual interest rate(decimal): r/100 in our calculation
                n = the number of times that interest is compounded per year
                t = the number of years the money is invested or borrowed for
            */

            const int INCREMENTS = 12; // the number of times that interest is compounded per year
            double futureValue; //The sum to pay/recive, inc. principal amount and interest
            double years = months / 12.0; // The loan/investment period in years
            double x = (1 + rate / 100 / INCREMENTS); // (1 + r/n) in the formula
            double y = (INCREMENTS * years); // (n*t) in the formula

            futureValue = principal * (Math.Pow(x, y));
            decimal interest = (decimal)(futureValue - principal);

            return interest;
        }

        public static double ReceiveNumber()
        {
            double currentNumber = 0.0;
            string currentInput = "";
            bool isParsed = false;

            while (!isParsed)
            {
                Console.Write("Number: ");
                currentInput = Console.ReadLine();
                isParsed = double.TryParse(currentInput, out currentNumber);
            }

            return currentNumber;
        }

        public static string ReceiveSign()
        {
            bool isSign = false;

            Console.Write("Sign: ");
            string sign = Console.ReadLine();

            while (!isSign)
            {
                if (sign == "+" || sign == "-" || sign == "*" || sign == "/" || sign == "\\")
                {
                    isSign = true;
                }
                else
                {
                    isSign = false;
                    sign = ReceiveSign();
                }
            }
            return sign;
        }

        public static void SumOutput(decimal money)
        {
            string output = money.ToString("C", CultureInfo.CreateSpecificCulture("he-IL"));
            Console.WriteLine("Your interest is {0} !", output);
        }

    }
}
