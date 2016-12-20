using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_03_01
{
    class AddNumbers
    {
        public static void GreetUser()
        {
            Console.WriteLine("Please enter any number. To end the program, enter 0");
            ReceiveNextNumber();
        }

        static int AddCurrentNumber(int total, int currentNumber)
        {
            total += currentNumber;
            return total;
        }

        static void ReceiveNextNumber()
        {
            int count = 0;
            int currentNumber = 0;
            string currentInput = "";

            while (currentInput != "0")
            {
                currentInput = Console.ReadLine();
                bool isParsed = int.TryParse(currentInput, out currentNumber);

                if (isParsed)
                {
                    count = AddCurrentNumber(count, currentNumber);
                }
                else
                {
                    Console.WriteLine("Please, enter a number.");
                }
            }
            Console.WriteLine("\n\nFinal result is {0}", count);
            Environment.Exit(0);

        }

    }
}
