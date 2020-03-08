using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRover
{
    public class InputStringValidation
    {
        public string CoordValidator(string input)
        {
            string output = null;
            bool retry = true;

            do
            {
                CheckStringIsEmpty(input);
                output = FormatString(input);

                if (output.Length != 2)
                {
                    Console.WriteLine("Input does not match required length, please try again...");
                    input = Console.ReadLine();
                    continue;
                }

                var regex = new Regex("^[0-9]+$");

                if (!regex.IsMatch(output))
                {
                    Console.WriteLine("Input must be an integer between 0-9, please try again...");
                    input = Console.ReadLine();
                    continue;
                }

                retry = false;

            } while (retry);

            return output;
        }

        public string RoverPositionValidator(string input)
        {
            string output = null;
            char[] compassPoints = {'N', 'W', 'S', 'E'};
            bool retry = true;

            do
            {
                CheckStringIsEmpty(input);
                output = FormatString(input);

                if (output.Length != 3)
                {
                    Console.WriteLine("Input does not match required length, please try again...");
                    input = Console.ReadLine();
                    continue;
                }

                var regex = new Regex("^[0-9]+$");

                if (!regex.IsMatch(output[0].ToString() + output[1].ToString()))
                {
                    Console.WriteLine("Input must be an integer between 0-9, please try again...");
                    input = Console.ReadLine();
                    continue;
                }

                if (!output.Any(compassPoints.Contains))
                {
                    Console.WriteLine("Input cardinal compass point, please try again...");
                    input = Console.ReadLine();
                    continue;
                }

                retry = false;

            } while (retry);
            
            return output;
        }

        public string MovementValidator(string input)
        {
            string output = null;
            char[] movementVectors = { 'L', 'R', 'M'};
            bool retry = true;

            do
            {
                CheckStringIsEmpty(input);
                output = FormatString(input);

                if (!output.Any(movementVectors.Contains))
                {
                    Console.WriteLine("Input valid movements vectors, please try again...");
                    input = Console.ReadLine();
                    continue;
                }

                retry = false;

            } while (retry);

            return output;
        }

        private string FormatString(string input)
        {
            string output = null;
            output = input.Replace(" ", "");
            output = output.ToUpper();

            return output;
        }

        private string CheckStringIsEmpty(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input empty, please try again...");
                input = Console.ReadLine();
            }
            else
            {
                return input;
            }

            return input;
        }
    }
}
