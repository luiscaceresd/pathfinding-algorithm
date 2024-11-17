using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment2
{
    public class PathFinder
    {
        private Grid grid;
        private Rover rover;
        private Visualizer visualizer;
        private bool[,] visited;
        private int startX, startY, endX, endY;
        public bool Interrupted { get; private set; }

        public PathFinder(Grid grid, Rover rover, Visualizer visualizer, int startX, int startY, int endX, int endY)
        {
            this.grid = grid;
            this.rover = rover;
            this.visualizer = visualizer;
            this.startX = startX;
            this.startY = startY;
            this.endX = endX;
            this.endY = endY;
            visited = new bool[grid.Height, grid.Width];
            Interrupted = false;
        }

        public bool FindPath(int endX, int endY)
        {
            Interrupted = false;
            return MoveRover(rover.X, rover.Y, endX, endY) && !Interrupted;
        }

        private bool MoveRover(int x, int y, int endX, int endY)
        {
            if (Interrupted)
                return false;

            if (x == endX && y == endY)
            {
                return true;
            }

            // Mark the current position as visited
            visited[y, x] = true;

            // Try moving forward first
            if (TryMove(x, y - 1, endX, endY, RoverCommand.Forward))
            {
                return true;
            }

            // Try moving right
            if (TryMove(x + 1, y, endX, endY, RoverCommand.Right))
            {
                return true;
            }

            // Try moving left
            if (TryMove(x - 1, y, endX, endY, RoverCommand.Left))
            {
                return true;
            }

            return false;
        }

        private bool TryMove(int newX, int newY, int endX, int endY, RoverCommand command)
        {
            if (Interrupted)
                return false;

            if (grid.IsAccessible(newX, newY) && !visited[newY, newX])
            {
                rover.Move(newX, newY, command);
                visualizer.DrawGrid(rover.X, rover.Y, rover.VisitedPositions, startX, startY, endX, endY);
                Thread.Sleep(50);

                // Check if user wants to interrupt
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Interrupted = true;
                        return false;
                    }
                }

                // Mark the new position as visited
                visited[newY, newX] = true;

                if (MoveRover(newX, newY, endX, endY))
                {
                    return true;
                }

                // Backtrack
                rover.Backtrack();

                visualizer.DrawGrid(rover.X, rover.Y, rover.VisitedPositions, startX, startY, endX, endY);
                Thread.Sleep(50);

                // Check for interruption again
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Interrupted = true;
                        return false;
                    }
                }
            }
            return false;
        }
    }
}

