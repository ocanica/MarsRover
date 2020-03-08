using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class ExplorePlanet
    {
        private readonly int[] _lowerLeftCoord = new int[2] { 0, 0 };
        private readonly int[] _upperRightCoord  = new int[2];
        private readonly IRover[] _rovers;
        private readonly  InputStringValidation validator = new InputStringValidation();

        public ExplorePlanet(string coordInput, IRover[] rovers)
        {
            coordInput = validator.CoordValidator(coordInput);

            // Parse character as integer
            _upperRightCoord[0] = Int32.Parse(coordInput[0].ToString());
            _upperRightCoord[1] = Int32.Parse(coordInput[1].ToString());

            _rovers = rovers;
        }

        public void Explore()
        {
            foreach (var rover in _rovers)
            {
                Console.WriteLine("Set initial rover XY coordinates and orientation (ie. 3 5 E):");
                var initPosition = validator.RoverPositionValidator(Console.ReadLine());
                rover.SetRoverPosition(initPosition);

                Console.WriteLine("Input rover heading (ie. RRMMMLMRMM):");
                var moveRover = validator.MovementValidator(Console.ReadLine());
                rover.MoveToPosition(moveRover);
            }
        }

        public void OutputCurrentLocation()
        {
            foreach (var rover in _rovers)
            {
                rover.OutputCurrentPosAndHeading();
            }
        }
        
    }
}
