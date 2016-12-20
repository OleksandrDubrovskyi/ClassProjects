using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_var_1
{
    class Menu
    {
        public string Item { get; set; }

        public static void CallMenu()
        {
            List<Menu> items = new List<Menu>();
            items.Add(new Menu() { Item = "1.  Item" });
            items.Add(new Menu() { Item = "2.  Item" });
            items.Add(new Menu() { Item = "3.  Item" });
            items.Add(new Menu() { Item = "4.  Item" });
            items.Add(new Menu() { Item = "5.  Item" });
            items.Add(new Menu() { Item = "6.  Item" });
            items.Add(new Menu() { Item = "7.  Item" });
            items.Add(new Menu() { Item = "8.  Item" });
            items.Add(new Menu() { Item = "9.  Item" });
            items.Add(new Menu() { Item = "10. Item" });
            items.Add(new Menu() { Item = "0.  Exit" });


            foreach (Menu item in items)
            {
                Console.WriteLine(item.Item);
            }

            Console.ReadLine();
            

        }
        
    }
}
