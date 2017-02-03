using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator
{
    enum Period { day = 1, week = 7, month = 30 }

    struct BankInterest
    {
        public string bankName;
        public Period period;
        public int sum_range;
        public double interest;
    }

    class Data
    {
        public static BankInterest[] InitializeBanks(string[] banks)
        {
            string[] temp = new string[4];
            BankInterest[] listOfBanks = new BankInterest[banks.Count()];

            for (int i = 0; i < banks.Count(); i++)
            {
                temp = banks[i].Split('#');
                listOfBanks[i].bankName = temp[0];
                listOfBanks[i].period = (Period)int.Parse(temp[1]);
                listOfBanks[i].sum_range = int.Parse(temp[2]);
                listOfBanks[i].interest = double.Parse(temp[3]);
            }

            return listOfBanks;
        }

        
    }

    
}
