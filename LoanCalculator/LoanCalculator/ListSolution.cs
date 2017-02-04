using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator
{
    class ListSolution
    {
        const int NUM_OF_BANKS = 4;
        const int NUM_OF_RANGES = 5;
        const int NUM_OF_PERIODS = 3;


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

        
        private static void ChooseBestRate()
        {
            Period p = Data.GetPeriod();
            int period = Data.GetPeriodNumber(p);
            double sum = Data.GetSum();
            int range = (Data.FindSumRange(sum) - 1); //We have zero based List

            List<Tuple<int, double>> interest = BestInterestRate(period, range);

            
            foreach (var item in interest)
            {
                string bankName = GetBankName(item.Item1);
                //double interestRate = item.Item2;
                Console.WriteLine("Bank {0}: deposit of {1} shekels for one {2} gives {3}%.",
                                    bankName, sum, p, item.Item2);
            }
        }

        private static List<Tuple<int, double>> BestInterestRate(int period, int range)
        {
            double[] rates = new double[4];
            List<Tuple<int, double>> bestRates = new List<Tuple<int, double>>();
            double currentBest = 0.0;

            for (int i = 0; i < rates.Length; i++)
            {
                rates[i] = BankInterestRate(i, period, range);
                var t = Tuple.Create(i, BankInterestRate(i, period, range));

                if (rates[i] > currentBest)
                {
                    bestRates.Clear();
                    bestRates.Add(t);
                    currentBest = rates[i];
                }
                else if (rates[i] == currentBest)
                {
                    bestRates.Add(t);
                }

            }

            return bestRates;
        }

        private static void ShowInterestRate()
        {
            Tuple<string, int> bank = GetBankName();
            Period p = Data.GetPeriod();
            int period = Data.GetPeriodNumber(p);
            double sum = Data.GetSum();
            int range = (Data.FindSumRange(sum) - 1); //We have zero based List
            double interest = BankInterestRate(bank.Item2, period, range);

            Console.WriteLine("Bank {0}: deposit of {1} shekels for one {2} gives {3}%.",
                bank.Item1, sum, p, interest);
        }

        public static double BankInterestRate(int bank, int period, int sum)
        {
            List<List<List<List<double>>>> Banks = GetInterestRates();
            
            return Banks[bank][period][sum][0];
        }





        //HELPER METHODS

        private static Tuple<string, int> GetBankName()
        {
            string usersChoice;

            do
            {
                Console.WriteLine("Choose your bank:\n\nM Mizrahi\nL Leumi\nD Discont\nH Hapoalim");
                usersChoice = Console.ReadLine().ToLower();
            }
            while (usersChoice != "m" && usersChoice != "l" && usersChoice != "d" && usersChoice != "h");

            string name = "";
            int code = -1;

            switch (usersChoice)
            {
                case "m":
                    code = 0;
                    name = "Mizrahi";
                    break;

                case "l":
                    code = 1;
                    name = "Leumi";
                    break;

                case "d":
                    code = 2;
                    name = "Discont";
                    break;

                case "h":
                    code = 3;
                    name = "Hapoalim";
                    break;
            }

            Tuple<string, int> bank = new Tuple<string, int>(name, code);

            return bank;
        }

        private static string GetBankName(int code)
        {
            string name = "";

            switch (code)
            {
                case 0: name = "Mizrahi"; break;
                case 1: name = "Leumi"; break;
                case 2: name = "Discont"; break;
                case 3: name = "Hapoalim"; break;
            }
            return name;
        }

        private static List<List<List<List<double>>>> GetInterestRates()
        {
            string[] banks = ListOfBanks.banks;
            string[] temp = new string[4];
            int counter = 0; //To work with string[] banks

            List<List<List<List<double>>>> Banks = CreateBanks();

            for (int bank = 0; bank < NUM_OF_BANKS; bank++)
            {
                for (int period = 0; period < NUM_OF_PERIODS; period++)
                {
                    for (int sum = 0; sum < NUM_OF_RANGES; sum++)
                    {
                        temp = banks[counter].Split('#');
                        counter++;
                        double interest = double.Parse(temp[3]);
                        Banks[bank][period][sum].Add(interest);
                    }
                }
            }
            return Banks;
        }

        static List<List<List<List<double>>>> CreateBanks()
        {
            var banks = new List<List<List<List<double>>>>(NUM_OF_BANKS);

            for (int i = 0; i < NUM_OF_BANKS; i++)
            {
                var period = CreatePeriods();
                banks.Add(period);
            }

            return banks;
        }

        static List<List<List<double>>> CreatePeriods()
        {
            var period = new List<List<List<double>>>(NUM_OF_PERIODS);

            for (int i = 0; i < NUM_OF_PERIODS; i++)
            {
                var sumRange = CreateSumRanges();
                period.Add(sumRange);
            }

            return period;
        }

        static List<List<double>> CreateSumRanges()
        {
            var sumRange = new List<List<double>>(NUM_OF_RANGES);

            for (int i = 0; i < NUM_OF_RANGES; i++)
            {
                List<double> interestRate = new List<double>();
                sumRange.Add(interestRate);
            }

            return sumRange;
        }
    }
}
