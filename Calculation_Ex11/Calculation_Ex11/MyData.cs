using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation_Ex11
{
    class MyData
    {
        private const string WELCOME_MESSAGE = "PROGRAMM HAVE BEEN STARTED";
        private const string REQUEST_FOR_INT_VALUE = "PLEASE, TYPE ONLY NUMERIC VALUE:";
        private const string REQUEST_FOR_STRING_VALUE = "NOW, PLEASE, TYPE ONLY ARITHMETIC SIGN:";
        private const string FIRST_VALUE_FOR_VERIFICATION = "A";

        private List<Tuple<double, char>> userValues { get; set; }

        public MyData() 
        {
            userValues = new List<Tuple<double, char>>();
        }

        public List<Tuple<double, char>> savingInputData() 
        {
            Console.WriteLine(WELCOME_MESSAGE);

            double tempNumericValue = new double();
            char tempArithmeticValue = new char();
            string tempStr = FIRST_VALUE_FOR_VERIFICATION;
            bool flagTypeOfInput = false;
            

            while(tempStr!= "=")
            {
                byte flagOfNecessaryAmountInputValues = 0;
                if (flagTypeOfInput)
                {
                    Console.WriteLine(REQUEST_FOR_STRING_VALUE);
                }
                else 
                {
                    Console.WriteLine(REQUEST_FOR_INT_VALUE);
                }
                tempStr = Console.ReadLine();

                if(flagTypeOfInput==false && double.TryParse(tempStr, out tempNumericValue))           // verification 1. If numeric value haven't been typed yet; 2. If we can parse this value to "double"
                {
                    flagTypeOfInput = true;
                    flagOfNecessaryAmountInputValues = 1;
                }
                else if ((flagTypeOfInput == true && (tempStr == "+" || tempStr == "-" || tempStr == "*" || tempStr == "/")) || tempStr == "=")          // verification 1. If arithmetic sign haven't been typed yet; 2. If this value one of those that we expected
                {
                    if (tempStr == "=" && flagTypeOfInput == false) { tempNumericValue = -1; }   // in case user typed '=' instead numaric value, 
                                                                                                //to avoid situation when we have such couple of values: Key:0 Value:=  and result will be incorrect

                    tempArithmeticValue = Convert.ToChar(tempStr);
                    flagTypeOfInput = false;
                    flagOfNecessaryAmountInputValues = 2;
                }

                if (flagOfNecessaryAmountInputValues == 2)                                   // verification if we got sufficient amount of user values for adding to dictionary
                {
                    userValues.Add(new Tuple<double, char>(tempNumericValue, tempArithmeticValue));
                }

            }


            return userValues;
        }
    }
}
