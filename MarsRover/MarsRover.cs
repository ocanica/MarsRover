using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class MarsRover : IRover
    {
        private int[] _xyPosition = new int[2];
        private char _orientation;
        private string _instruction;

        public void SetRoverPosition(string controlString)
        {
            // Parse character as integer
            _xyPosition[0] = Int32.Parse(controlString[0].ToString());
            _xyPosition[1] = Int32.Parse(controlString[1].ToString());

            _orientation = controlString[2];
        }

        public void MoveToPosition(string controlString)
        {
            _instruction = controlString.ToUpper();
            var charArray = _instruction.ToCharArray();

            foreach (var currentChar in charArray)
            {
                switch (_orientation)
                {
                    case 'N':
                        if (currentChar == 'L') _orientation = 'W';
                        else if (currentChar == 'R') _orientation = 'E';
                        else if (currentChar == 'M') _xyPosition = IncrementPosition('N', _xyPosition[0], _xyPosition[1]);
                        break;
                    case 'W':
                        if (currentChar == 'L') _orientation = 'S';
                        else if (currentChar == 'R') _orientation = 'N';
                        else if (currentChar == 'M') _xyPosition = IncrementPosition('W', _xyPosition[0], _xyPosition[1]);
                        break;
                    case 'S':
                        if (currentChar == 'L') _orientation = 'E';
                        else if (currentChar == 'R') _orientation = 'W';
                        else if (currentChar == 'M') _xyPosition = IncrementPosition('S', _xyPosition[0], _xyPosition[1]);
                        break;
                    case 'E':
                        if (currentChar == 'L') _orientation = 'N';
                        else if (currentChar == 'R') _orientation = 'S';
                        else if (currentChar == 'M') _xyPosition = IncrementPosition('E', _xyPosition[0], _xyPosition[1]);
                        break;
                }
            }
        }

        private static int[] IncrementPosition(char orientation, int x, int y)
        {
            switch (orientation)
            {
                case 'N':
                    return new int[] { x, y+1};
                case 'W':
                    return new int[] { x-1, y};
                case 'S':
                    return new int[] { x, y-1};
                case 'E':
                    return new int[] { x+1, y};
                default:
                    return null;
            }
        }

        public void OutputCurrentPosAndHeading()
        {
            Console.WriteLine("Current rover coordinates are:");
            Console.WriteLine($"{_xyPosition[0]} {_xyPosition[1]} {_orientation}");
        }
    }
}
