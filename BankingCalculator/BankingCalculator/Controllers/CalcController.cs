using BankingCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingCalculator.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            var calculator = new Calc();
            return View(calculator);
        }

        public ActionResult Count()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Interest(Calc calc)
        {
            string bank = calc.bankName.ToString();
            string sum = calc.sum.ToString();

            double profit = calc.GetInterest(calc.bankName, calc.period, calc.sum);

            string output = string.Format("You are going to place {0} NIS for 1 {1} at {2} bank.\nYour profit will be {3} NIS.",
                                          sum, calc.period, bank, profit);
            return Content(output);
        }
    }
}