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

    class Planet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Radius { get; set; }
        public double Mass { get; set; }
        public double DistanceFromSun { get; set; }

        List<Satellite> satellites = new List<Satellite>();

        static List<Planet> Planets = new List<Planet>();

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

        public void SetSatellites(Satellite satellite)
        {
            if (!satellites.Contains(satellite))
            {
                satellites.Add(satellite);
            }
        }

        public List<Satellite> GetSatellites()
        {
            return satellites;
        }

        public int NumberOfSatellites()
        {
            return satellites.Count;
        }

        static void MakePlanets()
        {
            string[] planets = { "Mercury", "Venus", "Earth", "Mars",
                                 "Jupiter", "Saturn", "Uranus", "Neptun", "Pluto" };

            for (int i = 0; i < planets.Length; i++)
            {
                Planets.Add(new Planet(planets[i]));
            }

        }

    }

    class Satellite
    {
        public string Name { get; set; }
        public double Radius { get; set; }
        public double Mass { get; set; }
        public string HomePlanet { get; set; }
        public double DistanceFromPlanet { get; set; }

        public Satellite(string name, double radius, double mass, double distance)
        {
            Name = name;
            Radius = radius;
            Mass = mass;
            DistanceFromPlanet = distance;
        }

        public Satellite(string name)
        {
            Name = name;
        }
    }

    

}
