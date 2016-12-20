using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_var_1
{
    class GetItem
    {
        public static void GetNumberOfItem()
        {

            string input = "";
            int numberOfItem = 0;
            bool isParsed = false;
            bool isPositive = false;
            bool isRightNumber = false;


            Console.Clear();



            while ((!(isParsed)) || (!(isPositive)) || (!(isRightNumber)))
            {
                Console.Clear();
                input = Console.ReadLine();
                isParsed = int.TryParse(input, out numberOfItem);
                isPositive = numberOfItem > 0;
                isRightNumber = numberOfItem <= 10;


            }
            Console.Clear();

            switch (numberOfItem)
            {
                case 1:
                    Console.WriteLine("Item 1");
                    break;

                case 2:
                    Console.WriteLine("Item 2");
                    break;

                case 3:
                    Console.WriteLine("Item 3");
                    break;

                case 4:
                    Console.WriteLine("Item 4");
                    break;

                case 5:
                    Console.WriteLine("Item 5");
                    break;

                case 6:
                    Console.WriteLine("Item 6");
                    break;
            }

            Console.ReadLine();
        }
    }
}
