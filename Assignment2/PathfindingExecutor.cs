using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class PathfindingExecutor
    {
        private Grid grid;
        private Visualizer visualizer;
        public bool ReachedTarget { get; private set; }

        public PathfindingExecutor(Grid grid, Visualizer visualizer)
        {
            this.grid = grid;
            this.visualizer = visualizer;
            ReachedTarget = false;
        }

        public bool ExecutePathfinding(Rover rover, int startX, int startY, int endX, int endY)
        {
            visualizer.DrawGrid(rover.X, rover.Y, rover.VisitedPositions, startX, startY, endX, endY);
            System.Threading.Thread.Sleep(500);

            PathFinder pathFinder = new PathFinder(grid, rover, visualizer, startX, startY, endX, endY);

            Console.WriteLine("Press 'Esc' at any time to interrupt the pathfinding.");
            ReachedTarget = pathFinder.FindPath(endX, endY);

            return pathFinder.Interrupted;
        }
    }
}
