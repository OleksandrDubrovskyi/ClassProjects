using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator
{
    class TupleSolution
    {
        public static void Start()
        {
            Console.WriteLine("To check interest rate of your bank depending on period and sum press: 1");
            Console.WriteLine("To check the best interest rate depending on period and sum press: 2");

            string usersInput = Console.ReadLine();
            
            while (usersInput == "1" || usersInput == "2")
            {
                Console.WriteLine("To check interest rate of your bank depending on period and sum press: 1");
                Console.WriteLine("To check the best interest rate depending on period and sum press: 2");

                usersInput = Console.ReadLine();
            }
            
            if (usersInput == "1")
            {
                ShowInterestRate();
            }
        }


        //Get the database of banks and their interest rates
        private static Tuple<string, Period, int, double>[] BankInterests(string[] banks)
        {
            string[] temp = new string[4];
            var listOfBanks = new Tuple<string, Period, int, double>[banks.Count()];

            for (int i = 0; i < listOfBanks.Count(); i++)
            {
                temp = banks[i].Split('#');
                string name = temp[0];
                Period period = (Period)int.Parse(temp[1]);
                int sum = int.Parse(temp[2]);
                double interest = double.Parse(temp[3]);

                listOfBanks[i] = Tuple.Create(name, period, sum, interest);
            }

            return listOfBanks;
        }


        //Get the best interest rate on your sum over a given period of time
        private static void BestInterestRate(Period period, int sumRange)
        {
            var banks = BankInterests(ListOfBanks.banks);
            
            //Best rate(s) for output
            var filtered = new List<Tuple<string, Period, int, double>>();

            double max = banks[0].Item4;    //Item4 = interest rate

            foreach (var item in banks)
            {
                //Item2 = period of the deposit
                //Item3 = sum range
                if (item.Item2 == period && item.Item3 == sumRange)
                {
                    if (item.Item4 > max)
                    {
                        filtered.Clear();
                        filtered.Add(item);
                        max = item.Item4;
                    }
                    else if (item.Item4 == max)
                    {
                        filtered.Add(item);
                    }

                }
            }
            Console.WriteLine(filtered.Count);

            foreach (var item in filtered)
            {
                //Item1 = bank name
                Console.WriteLine("{0} - {1} - {2} - {3}%.", item.Item1, item.Item2, item.Item3, item.Item4);
            }
        }

        //Get the interest rate of a given mank on your sum over a period of time
        private static double BankInterestRate(string name, Period period, int sumRange)
        {
            var banks = BankInterests(ListOfBanks.banks);

            double interest = 0;
            foreach (var item in banks)
            {
                //Item1 = bank name
                //Item2 = period of the deposit
                //Item3 = sum range
                if (item.Item1 == name && item.Item2 == period && item.Item3 == sumRange)
                {
                    interest = item.Item4;
                    break;
                }
            }

            return interest;
        }


        //HELPER METHODS USED FOR USER DATA INPUT

        private static int FindSumRange(double sum)
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
            else return 0;
        }

        private static void ChooseBestRate()
        {
            throw new NotImplementedException();
        }

        private static void ShowInterestRate()
        {
            string bank = GetBankName();
            Period period = GetPeriod();
            double sum = GetSum();
            int range = FindSumRange(sum);
            double interest = BankInterestRate(bank, period, range);

            Console.WriteLine("{0} - {1} - {2} - {3}%.", bank, period, sum, interest);
        }

        private static double GetSum()
        {
            double sum;
            string usersInput;

            do
            {
                Console.WriteLine("Please enter your sum in range 5,000 to 500,000 shekels.");
                usersInput = Console.ReadLine();
            }
            while (!double.TryParse(usersInput, out sum));

            return sum;
        }

        private static Period GetPeriod()
        {
            string usersChoice;

            do
            {
                Console.WriteLine("For how many days do you want to place a deposit?");
                Console.WriteLine("Choose one of the following: 1, 7, 30");
                usersChoice = Console.ReadLine().ToLower();
            }
            while (usersChoice != "1" || usersChoice != "7" || usersChoice != "30");

            Period period = Period.day;

            switch (usersChoice)
            {
                case "1": period = Period.day; break;
                case "7": period = Period.week; break;
                case "30": period = Period.month; break;
            }

            return period;
        }

        private static string GetBankName()
        {
            string usersChoice;

            do
            {
                Console.WriteLine("Choose your bank:\n\nM Mizrahi\nL Leumi\nD Discont\nH Hapoalim");
                usersChoice = Console.ReadLine().ToLower();
            }
            while (usersChoice != "m" || usersChoice != "l" || usersChoice != "d" || usersChoice != "h");

            string bank = "";

            switch (usersChoice)
            {
                case "m": bank = "Mizrahi"; break;
                case "l": bank = "Leumi"; break;
                case "d": bank = "Discont"; break;
                case "h": bank = "Hapoalim"; break;
            }

            return bank;
        }
    }
}
