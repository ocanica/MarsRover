using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Map upper boundary (ie. 5 8) ");
            var mapCoordinates = Console.ReadLine();

            // Passing initial boundary and two MarsRover() objects to the constructor
            var marsPlateau = new ExplorePlanet(mapCoordinates, new [] { new MarsRover(), new MarsRover(), });

            marsPlateau.Explore();
            marsPlateau.OutputCurrentLocation();

            Console.ReadLine();
        }
    }
}
