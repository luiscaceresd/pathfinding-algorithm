using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public enum RoverCommand { Start, Forward, Left, Right, Backtrack }

    public struct PathStep
    {
        public int x;
        public int y;
        public RoverCommand command;

        public PathStep(int x, int y, RoverCommand command)
        {
            this.x = x;
            this.y = y;
            this.command = command;
        }
    }
}
