using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    class CelestialBody
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Radius { get; set; }
        public double Mass { get; set; }
        public double DistanceFromSun { get; set; }

        public CelestialBody(string name, double radius, double mass, double distance)
        {
            Name = name;
            Radius = radius;
            Mass = mass;
            DistanceFromSun = distance;
        }

        public CelestialBody(string name)
        {
            Name = name;            
        }
    }

    

}
