using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Rover
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public List<PathStep> Path { get; private set; } = new List<PathStep>();
        public List<PathStep> AllMoves { get; private set; } = new List<PathStep>();
        public HashSet<(int x, int y)> VisitedPositions { get; private set; } = new HashSet<(int x, int y)>();

        public Rover(int startX, int startY)
        {
            X = startX;
            Y = startY;
            AddMove(RoverCommand.Start, X, Y);
        }

        public void Move(int newX, int newY, RoverCommand command)
        {
            X = newX;
            Y = newY;
            AddMove(command, X, Y);
        }

        public void Backtrack()
        {
            if (Path.Count > 0)
            {
                // Remove the last step from Path
                Path.RemoveAt(Path.Count - 1);

                // Set X and Y to the previous position if any
                if (Path.Count > 0)
                {
                    var lastStep = Path[Path.Count - 1];
                    X = lastStep.x;
                    Y = lastStep.y;
                }
                else
                {
                    // Handle if no previous position (back at start)
                    // For this example, we'll keep X and Y unchanged
                }

                // Record the backtrack in AllMoves
                AllMoves.Add(new PathStep(X, Y, RoverCommand.Backtrack));

                // Do NOT remove the position from VisitedPositions
                // This ensures that all visited positions remain marked
            }
        }

        private void AddMove(RoverCommand command, int x, int y)
        {
            var step = new PathStep(x, y, command);
            Path.Add(step);
            AllMoves.Add(step);
            VisitedPositions.Add((x, y));
        }
    }
}
