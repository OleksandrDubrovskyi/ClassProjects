using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_03_01
{
    class StringMultiplier
    {
        public static void InputReceiver()
        {
            int inputNumber = 0;
            string currentInput = "";
            bool isParsed = false;
            bool isPositive = false;

            do
            {
                Console.WriteLine("Please, enter a positive number.");
                currentInput = Console.ReadLine();
                isParsed = int.TryParse(currentInput, out inputNumber);
                isPositive = inputNumber > 0;
            }
            while (! isParsed || ! isPositive);

            Console.WriteLine("Please, enter a string.");
            currentInput = Console.ReadLine();
            PrintOutput(inputNumber, currentInput);
        }

        static void PrintOutput(int times, string inputString)
        {
            Console.WriteLine("\n\n");

            for (int i = 1; i <= times; i++)
            {
                Console.WriteLine("{0} {1}.", i, inputString);
            }

            Console.WriteLine("\n\n");
        }
    }
}
