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
            string usersInput = Data.GetUsersChoice();

            if (usersInput == "1")
            {
                ShowInterestRate();
            }
            else
            {
                ChooseBestRate();
            }
        }

        


        //Get the database of banks and their interest rates
        private static Tuple<string, Period, int, double>[] GetBankInterests(string[] banks)
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
        private static List<Tuple<string, Period, int, double>> BestInterestRate(Period period, int sumRange)
        {
            var banks = GetBankInterests(ListOfBanks.banks);
            
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

            return filtered;
           
        }

        //Get the interest rate of a given bank on your sum over a period of time
        private static double BankInterestRate(string name, Period period, int sumRange)
        {
            var banks = GetBankInterests(ListOfBanks.banks);

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

        private static void ChooseBestRate()
        {
            Period period = Data.GetPeriod();
            double sum = Data.GetSum();
            int range = Data.FindSumRange(sum);
            List<Tuple<string, Period, int, double>> interest = BestInterestRate(period, range);

            foreach (var item in interest)
            {
                //Item1 = bank name, Item4 = interest rate
                Console.WriteLine("Bank {0}: deposit of {1} shekels for one {2} gives {3}%.",
                                    item.Item1, sum, period, item.Item4);
            }
        }

        private static void ShowInterestRate()
        {
            string bank = GetBankName();
            Period period = Data.GetPeriod();
            double sum = Data.GetSum();
            int range = Data.FindSumRange(sum);
            double interest = BankInterestRate(bank, period, range);

            Console.WriteLine("Bank {0}: deposit of {1} shekels for one {2} gives {3}%.",
                bank, sum, period, interest);
        }

        private static string GetBankName()
        {
            string usersChoice;

            do
            {
                Console.WriteLine("Choose your bank:\n\nM Mizrahi\nL Leumi\nD Discont\nH Hapoalim");
                usersChoice = Console.ReadLine().ToLower();
            }
            while (usersChoice != "m" && usersChoice != "l" && usersChoice != "d" && usersChoice != "h");

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
