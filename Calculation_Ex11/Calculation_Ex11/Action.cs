using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Calculation_Ex11
{
    class Action
    {
        private const double LATEST_VALUE = -1;
        private const char EXPECTED_FINAL_SIGN = '=';
        private const string WELCOME_MESSAGE = "CALCULATING HAVE BEEN STARTED";
        private const string RESULT_MESSAGE = "YOUR RESULT IS: ";
        private const string ERROR_MESSAGE = "DIVISION BY ZERO!\n ";

        List<double> arrOfUserNumericValues = new List<double>();
        List<char> arrOfUserArithmeticSigns = new List<char>();

        private MyData data;

        public Action()
        {
            data = new MyData();
        }

        private void ChangingDataStructure()
        {
            foreach (Tuple<double, char> kv in data.savingInputData())
            {
                arrOfUserNumericValues.Add(kv.Item1);
                arrOfUserArithmeticSigns.Add(kv.Item2);
            }
        }

        public double CalculationAccordingToUserInputOrder()
        {
            ChangingDataStructure();

            Console.WriteLine(WELCOME_MESSAGE);

            double result = arrOfUserNumericValues.ElementAt(0);               // result value should with first value from user input right from the beginning

            for (int i = 1; i < arrOfUserNumericValues.Count(); i++)
            {
                if (arrOfUserNumericValues.ElementAt(i) == LATEST_VALUE) { return result; }
                switch (arrOfUserArithmeticSigns.ElementAt(i - 1))
                {
                    case '+':
                        result += arrOfUserNumericValues.ElementAt(i);
                        break;
                    case '-':
                        result -= arrOfUserNumericValues.ElementAt(i);
                        break;
                    case '*':
                        result *= arrOfUserNumericValues.ElementAt(i);
                        break;
                    case '/':
                        try { result = result / arrOfUserNumericValues.ElementAt(i); }
                        catch(DivideByZeroException e)
                        {
                            Console.WriteLine(ERROR_MESSAGE + e.StackTrace);
                        }
                        
                        break;
                    case EXPECTED_FINAL_SIGN:
                        Console.WriteLine(RESULT_MESSAGE);
                        break;
                }
            }

            return result;

        }
//********************************************************************
        public double CalculationAccordingToMathematicalRules() 
        {
            ChangingDataStructure();

            Console.WriteLine(WELCOME_MESSAGE);

            DataTable myDataTable = new DataTable();
            double result = arrOfUserNumericValues.ElementAt(0);
            string containerOfUserExpression ="" +  result;

            for (int i = 1; i < arrOfUserNumericValues.Count(); i++)
            {
                if (arrOfUserNumericValues.ElementAt(i) == LATEST_VALUE) 
                {
                    result = Convert.ToDouble(myDataTable.Compute(containerOfUserExpression, ""));             // In case user entered "=" sign instead numeric value, =>
                    return result;                                                                                // => need to look for "-1" in the end of the numeric array
                }
                switch (arrOfUserArithmeticSigns.ElementAt(i - 1))
                {
                    case '+':
                        containerOfUserExpression += "+" + arrOfUserNumericValues.ElementAt(i);
                        break;
                    case '-':
                        containerOfUserExpression += "-" + arrOfUserNumericValues.ElementAt(i);
                        break;
                    case '*':
                        containerOfUserExpression += "*" + arrOfUserNumericValues.ElementAt(i);
                        break;
                    case '/':
                        containerOfUserExpression += "/" + arrOfUserNumericValues.ElementAt(i);
                        break;
                    case EXPECTED_FINAL_SIGN:
                        Console.WriteLine(RESULT_MESSAGE);
                        break;
                }
            }

            result = Convert.ToDouble(myDataTable.Compute(containerOfUserExpression, ""));

            return result;
        }
//********************************************************************

        public void PrintResultOfCalculationAccordingToUserInputOrder() 
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("CALCULATION ACCORDING TO USER INPUT ORDER:\n***** {0} *****", CalculationAccordingToUserInputOrder()));
        }

        public void PrintResultOfCalculationAccordingToMathematicalRules()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("CALCULATION ACCORDING TO MATHEMATICAL RULES:\n***** {0} *****", CalculationAccordingToMathematicalRules()));
        }
    }
}
