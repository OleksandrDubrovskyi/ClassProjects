using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    class Program
    {
        struct test { public string x; public int y; }


        static void Main(string[] args)
        {
            Planet Earth = new Planet("Earth");
            Earth.Mass = 34;
            //Satellite Moon = new Satellite("Moon");
            //Earth.SetSatellites(Moon);

         


            test[] items = new test[4];
            
            //test first = new test { x = "Jupiter", y = 2 };
            //test second = new test { x = "Saturn", y = 0 };

            items[0] = new test { x = "Jupiter", y = 2 };
            items[1] = new test { x = "Saturn", y = 0 };
            items[2] = new test { x = "Jungo", y = 3 };
            items[3] = new test { x = "Pluto", y = 0 };

            var filteredNames = items.OrderBy(n => n.y);
            int min = filteredNames.First().y;
            var filteredNames2 = items.Where(n => n.y == min);

            //Console.WriteLine(filteredNames.First().y);
            foreach (test name in filteredNames2) Console.WriteLine(name.x + " " + name.y);

            Moon first = new Moon("First", 20, 34.9);
            Moon second = new Moon("Second", 24, 35.8);
            Moon third = new Moon("Third", 11, 5.8);

            List<Moon> Moons = new List<Moon>();
            Moons.Add(first);
            Moons.Add(second);
            Moons.Add(third);

            Moons.Sort();


            Console.WriteLine(Moons[Moons.Count-1]);
            Console.WriteLine("\nLIST OF MOONS:\n");
            foreach (var item in Moons)
            {
                Console.WriteLine(item);
            }


        }

      
    }
}
