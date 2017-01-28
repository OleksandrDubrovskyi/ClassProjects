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
            Satellite Moon = new Satellite("Moon");
            Earth.SetSatellites(Moon);

            List<Satellite> EarthSat = new List<Satellite>();
            EarthSat = Earth.GetSatellites();


            foreach (var item in EarthSat)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine(Earth.NumberOfSatellites());



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

        }

        void Start()
        {
            List<CelestialBody> Planets = new List<CelestialBody>();
        }
    }
}
