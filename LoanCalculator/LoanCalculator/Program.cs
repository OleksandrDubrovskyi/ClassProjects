using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator
{
    class Program
    {
        static void Main(string[] args)
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
                        double trunc =    Math.Round(random, 2);
                        Console.WriteLine("\"{0}#{1}#{2}#{3}\",", banks[b], period[p], sumRange[s], trunc);
                        System.Threading.Thread.Sleep(1012);
                    }
                }
            }


        }
    }
}
