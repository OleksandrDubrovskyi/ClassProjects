using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator
{
    enum Period { day = 1, week = 7, month = 30 }

    class Data
    {
        public static string GetUsersChoice()
        {
            string usersInput;

            do
            {
                Console.WriteLine("To check interest rate of your bank depending on period and sum press: 1");
                Console.WriteLine("To check the best interest rate depending on period and sum press: 2");

                usersInput = Console.ReadLine();
            }
            while (usersInput != "1" && usersInput != "2");

            return usersInput;
        }

        public static double GetSum()
        {
            double sum = 0;
            string usersInput;

            while (sum < 5000 || sum > 500000)
            {
                do
                {
                    Console.WriteLine("Please enter your sum in range 5,000 to 500,000 shekels.");
                    usersInput = Console.ReadLine();
                }
                while (!double.TryParse(usersInput, out sum));
            }


            return sum;
        }

        public static int FindSumRange(double sum)
        {
            if (sum >= 5000 && sum <= 15000)
            {
                return 1;
            }
            else if (sum <= 25000)
            {
                return 2;
            }
            else if (sum <= 50000)
            {
                return 3;
            }
            else if (sum <= 100000)
            {
                return 4;
            }
            else if (sum <= 500000)
            {
                return 5;
            }
            else return -1;
        }


        public static Period GetPeriod()
        {
            string usersChoice;

            do
            {
                Console.WriteLine("For how many days do you want to place a deposit?");
                Console.WriteLine("Choose one of the following: 1, 7, 30");
                usersChoice = Console.ReadLine().ToLower();
            }
            while (usersChoice != "1" && usersChoice != "7" && usersChoice != "30");

            Period period = Period.day;

            switch (usersChoice)
            {
                case "1": period = Period.day; break;
                case "7": period = Period.week; break;
                case "30": period = Period.month; break;
            }

            return period;
        }

        public static int GetPeriodNumber(Period p)
        {
            int period = -1;

            switch (p)
            {
                case Period.day: period = 0; break;
                case Period.week: period = 1; break;
                case Period.month: period = 2; break;
            }

            return period;
        }


    }

    
}
