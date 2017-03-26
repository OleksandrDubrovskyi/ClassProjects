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
            string period = ((int)calc.period).ToString();
            string sum = calc.sum.ToString();

            double output = calc.GetInterest(calc.bankName, calc.period, calc.sum);

            return Content(output.ToString());
        }
    }
}