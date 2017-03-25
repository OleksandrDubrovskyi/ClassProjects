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



        public int GetSumRange(double sum)
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

        public double GetInterest(Bank b, Period p, double sum)
        {

            return (int)p * sum;
        }
    }

    public enum Period { Day = 1, Week = 7, Month = 30}

    public enum Bank { Discont, Hapoalim, Leumi, Mizrakhi}
}