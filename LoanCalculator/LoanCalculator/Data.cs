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
        struct BankInterest
        {
            public string bankName;
            public Period period;
            public int sum_range;
            public double interest;
        }

        static void InitializeBanks()
        {
            string[] temp = new string[60, 4];
            for (int i = 0; i < 60; i++)
            {
                temp[i]=ListOfBanks.banks[i].Split('#');
            }

            BankInterest[] listOfBanks = new BankInterest[60];
            for (int i = 0; i < listOfBanks.Length; i++)
            {
                
                listOfBanks[i].bankName = temp[i, 0]; 
            }
        }
        
        

        
    }

    
}
