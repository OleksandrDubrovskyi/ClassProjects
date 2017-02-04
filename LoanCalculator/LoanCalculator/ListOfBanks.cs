using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator
{
    class ListOfBanks
    {
        //Use random num generator to make 60 interest rates
        public static void GenerateInterests()
        {
            string[] banks = new string[]
            {
                "Mizrahi", "Leumi", "Discont", "Hapoalim"
            };

            int[] period = new int[] { 1, 7, 30 };

            int[] sumRange = new int[] { 1, 2, 3, 4, 5 };

            for (int b = 0; b < banks.Length; b++)
            {
                for (int p = 0; p < period.Length; p++)
                {
                    for (int s = 0; s < sumRange.Length; s++)
                    {
                        Random r = new Random();
                        double random = (r.NextDouble() * (0.09 - 0.01) + 0.01);
                        double trunc = Math.Round(random, 2);
                        Console.WriteLine("\"{0}#{1}#{2}#{3}\",", banks[b], period[p], sumRange[s], trunc);
                        System.Threading.Thread.Sleep(1012);
                    }
                }
            }
        }

        //The previous method takes more than a minute
        //to generate the list, so we use this variable
        //in order to make demonstration shorter
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

        public static void Banks()
        {
            
        }
        
    }
}
