using System;

namespace HW_03_01
{
    public static class Calculator
    {
        public static void AddAllNumbers()
        {
            int count = 0;
            int currentNumber = 0;
            string currentInput = "";

            while (currentInput != "0")
            {
                Console.WriteLine("Please enter any number. To end the program, enter 0");
                currentInput = Console.ReadLine();

                if (int.TryParse(currentInput, out currentNumber))
                {
                    count += currentNumber;
                    Console.WriteLine(count);
                }

                Console.WriteLine("\n\nFinal result is {0}", count);
            }

        }

        public static void StringMultiplier()
        {

        }

        public static void CalculateNumbers()
        {

        }

        public Calculator()
        {

        }

    }
}
