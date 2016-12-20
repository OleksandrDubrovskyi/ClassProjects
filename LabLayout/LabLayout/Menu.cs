using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLayout
{
    class Menu
    {
        public static void ShowMenu()
        {
            List<string> menuItems = MenuItems();
            for (int i = 1; i <= menuItems.Count; i++)
            {
                Console.WriteLine("{0}. Item # {1}\n", i, i);
            }

            int itemToShow = 0;
            int usersChoice = UsersChoice(menuItems.Count);

            while (usersChoice != 0)
            {
                itemToShow = usersChoice - 1;

                Console.Clear();
                Console.WriteLine("{0}\nPress Enter to return to the menu.", menuItems[itemToShow]);

                string enter = Console.ReadLine();
                if (enter == "")
                {
                    Console.Clear();
                    ShowMenu();
                }
            }

            Environment.Exit(0);
        }

        static int UsersChoice(int count)
        {
            int choiceNumber = -1;
            Console.WriteLine("Please make your choice. Press 0 to quit.\n");

            while (true)
            {
                Console.WriteLine("Enter a number between 0 and {0}.\n", count);
                string choice = Console.ReadLine();
                bool isParsed = int.TryParse(choice, out choiceNumber);
                bool isInRange = (0 <= choiceNumber && choiceNumber <= count);

                if (isParsed && isInRange)
                {
                    break;
                }
            }

            return choiceNumber;
        }

        static List<string> MenuItems()
        {
            List<string> menuItems = new List<string>();
            for (int i = 1; i < 11; i++)
            {
                string textItem = String.Format("Some string # {0}\n", i);
                menuItems.Add(textItem);
            }

            return menuItems;
        }
    }
}
