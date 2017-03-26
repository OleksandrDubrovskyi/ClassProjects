using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingCalculator.Models
{
    public class Calc
    {
        [Required]
        [Display(Name = "Bank")]
        public Bank bankName { get; set; }

        [Required]
        [Display(Name = "Enter your sum")]
        public double sum { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(5000, 500000)]
        [Display(Name = "Period")]
        public Period period { get; set; }

        //Method for communication with controller
        public double GetInterest(Bank b, Period p, double sum)
        {
            int sumRange = GetSumRange(sum);
            double interestRate = BankInterestRate(b.ToString(), p, sumRange);
            double interest = (interestRate * sum) * ((int)p / 360.0);

            return Math.Round(interest, 2);
        }


        //Buisness logic methods
   //----------------------------------\\

        int GetSumRange(double sum)
        {
            //Numeration of ranges begins with one
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

        //Get the database of banks and their interest rates
        Tuple<string, Period, int, double>[] GetBankInterests(string[] banks)
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

        //Get the interest rate of a given bank on your sum over a period of time
        double BankInterestRate(string name, Period period, int sumRange)
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


    }

    public enum Period { Day = 1, Week = 7, Month = 30}

    public enum Bank { Discont, Hapoalim, Leumi, Mizrahi}

    //Database of interest rates
    public class ListOfBanks
    {
        public static string[] banks = new string[]
        {
            "Mizrahi#1#1#0.01",
            "Mizrahi#1#2#0.03",
            "Mizrahi#1#3#0.01",
            "Mizrahi#1#4#0.03",
            "Mizrahi#1#5#0.01",
            "Mizrahi#7#1#0.05",
            "Mizrahi#7#2#0.07",
            "Mizrahi#7#3#0.05",
            "Mizrahi#7#4#0.03",
            "Mizrahi#7#5#0.06",
            "Mizrahi#30#1#0.09",
            "Mizrahi#30#2#0.07",
            "Mizrahi#30#3#0.05",
            "Mizrahi#30#4#0.08",
            "Mizrahi#30#5#0.06",
            "Leumi#1#1#0.01",
            "Leumi#1#2#0.03",
            "Leumi#1#3#0.02",
            "Leumi#1#4#0.08",
            "Leumi#1#5#0.02",
            "Leumi#7#1#0.05",
            "Leumi#7#2#0.04",
            "Leumi#7#3#0.02",
            "Leumi#7#4#0.04",
            "Leumi#7#5#0.07",
            "Leumi#30#1#0.06",
            "Leumi#30#2#0.08",
            "Leumi#30#3#0.06",
            "Leumi#30#4#0.04",
            "Leumi#30#5#0.08",
            "Discont#1#1#0.02",
            "Discont#1#2#0.08",
            "Discont#1#3#0.06",
            "Discont#1#4#0.08",
            "Discont#1#5#0.04",
            "Discont#7#1#0.02",
            "Discont#7#2#0.04",
            "Discont#7#3#0.03",
            "Discont#7#4#0.09",
            "Discont#7#5#0.04",
            "Discont#30#1#0.06",
            "Discont#30#2#0.05",
            "Discont#30#3#0.03",
            "Discont#30#4#0.05",
            "Discont#30#5#0.08",
            "Hapoalim#1#1#0.07",
            "Hapoalim#1#2#0.09",
            "Hapoalim#1#3#0.07",
            "Hapoalim#1#4#0.05",
            "Hapoalim#1#5#0.09",
            "Hapoalim#7#1#0.03",
            "Hapoalim#7#2#0.01",
            "Hapoalim#7#3#0.07",
            "Hapoalim#7#4#0.01",
            "Hapoalim#7#5#0.05",
            "Hapoalim#30#1#0.03",
            "Hapoalim#30#2#0.05",
            "Hapoalim#30#3#0.03",
            "Hapoalim#30#4#0.02",
            "Hapoalim#30#5#0.05"
        };
    }
}