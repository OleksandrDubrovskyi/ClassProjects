using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation_Ex11
{
    class Program
    {
        static void Main(string[] args)
        {

            //MyData data = new MyData();
            //int index = 0;


            //foreach (Tuple<double, char> tuple in data.savingInputData())
            //{
            //    Console.WriteLine(String.Format("{0}. Key:{1} Value:{2}", index, tuple.Item1, tuple.Item2));
            //    index++;

            //}


            Action act = new Action();

            act.PrintResultOfCalculationAccordingToUserInputOrder();
            act.PrintResultOfCalculationAccordingToMathematicalRules();
        }
    }
}
