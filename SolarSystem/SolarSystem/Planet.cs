using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    class Planet
    {
        public string Name { get; set; }
        public double Radius { get; set; }
        public double Mass { get; set; }
        public double DistanceFromSun { get; set; }


        public Planet (string name, double radius, double mass, double distance)
        {
            Name = name;
            Radius = radius;
            Mass = mass;
            DistanceFromSun = distance;
        }

        public Planet (string name)
        {
            Name = name;
        }

        public List<Moon> GetListOfMoons()
        {
            string fileName = (Name + ".txt");
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            //string path = "C:/Users/user/Desktop/Specter_C#/ClassProjects/SolarSystem/" + Name + ".txt";

            string[] lines = File.ReadAllLines(path);

            List<Moon> moons = new List<Moon>();

            for (int i = 0; i < lines.Length; i++)
            {
                Moon sat = new Moon();
                string[] words = lines[i].Split('#');
                sat.Name = words[0];
                sat.Diameter = double.Parse(words[1]);
                sat.Mass = double.Parse(words[2]);

                moons.Add(sat);
            }

            return moons;
        }

        public int NumberOfMoons()
        {
            return GetListOfMoons().Count;
        }

    }

}
