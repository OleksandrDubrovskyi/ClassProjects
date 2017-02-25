using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    public class Moon : IComparable<Moon>
    {
        public double Mass { get; set; }
        public double Diameter { get; set; }
        public string Name { get; set; }

        public Moon(string name, double mass, double diameter)
        {
            Name = name;
            Mass = mass;
            Diameter = diameter;
        }

        public Moon()
        {

        }

        public int CompareTo(Moon other)
        {
            // Alphabetic sort if mass is equal. [A to Z]
            if (this.Mass == other.Mass)
            {
                return this.Name.CompareTo(other.Name);
            }
            // Default to mass sort. [High to low]
            return other.Mass.CompareTo(this.Mass);
        }

        public override string ToString()
        {
            // String representation.
            return this.Name + ", " + this.Mass.ToString() + ", " + this.Diameter.ToString();
        }

    }

}
