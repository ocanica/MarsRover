using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public interface IRover
    {
        void SetRoverPosition(string controlString);
        void MoveToPosition(string controlString);
        void OutputCurrentPosAndHeading();
    }
}
