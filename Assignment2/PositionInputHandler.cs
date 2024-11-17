using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class PositionInputHandler
    {
        private Grid grid;
        private Visualizer visualizer;
        private PositionSelector positionSelector;

        public PositionInputHandler(Grid grid, Visualizer visualizer, PositionSelector positionSelector)
        {
            this.grid = grid;
            this.visualizer = visualizer;
            this.positionSelector = positionSelector;
        }

        public bool GetStartAndEndPositions(out int? startX, out int? startY, out int? endX, out int? endY)
        {
            startX = null;
            startY = null;
            endX = null;
            endY = null;

            Console.WriteLine("Select position entry method:");
            Console.WriteLine("1. Select positions on the map");
            Console.WriteLine("2. Enter positions manually");
            Console.Write("Please enter your choice (1-2): ");

            var key = Console.ReadKey(intercept: true);
            Console.WriteLine();

            switch (key.KeyChar)
            {
                case '1':
                    // Use PositionSelector
                    positionSelector.SelectPositions(out startX, out startY, out endX, out endY);
                    break;
                case '2':
                    // Prompt user to enter positions manually
                    EnterPositionsManually(out startX, out startY, out endX, out endY);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    System.Threading.Thread.Sleep(2000);
                    return false;
            }

            return startX.HasValue && startY.HasValue && endX.HasValue && endY.HasValue;
        }

        private void EnterPositionsManually(out int? startX, out int? startY, out int? endX, out int? endY)
        {
            startX = null;
            startY = null;
            endX = null;
            endY = null;

            Console.WriteLine("Enter the starting position coordinates.");
            Console.Write($"X (0 to {grid.Width - 1}): ");
            string startXInput = Console.ReadLine();
            Console.Write($"Y (0 to {grid.Height - 1}): ");
            string startYInput = Console.ReadLine();

            if (!int.TryParse(startXInput, out int sx) || !int.TryParse(startYInput, out int sy) ||
                !grid.IsValidPosition(sx, sy) || !grid.IsAccessible(sx, sy))
            {
                Console.WriteLine("Invalid starting position.");
                System.Threading.Thread.Sleep(2000);
                return;
            }

            Console.WriteLine("Enter the ending position coordinates.");
            Console.Write($"X (0 to {grid.Width - 1}): ");
            string endXInput = Console.ReadLine();
            Console.Write($"Y (0 to {grid.Height - 1}): ");
            string endYInput = Console.ReadLine();

            if (!int.TryParse(endXInput, out int ex) || !int.TryParse(endYInput, out int ey) ||
                !grid.IsValidPosition(ex, ey) || !grid.IsAccessible(ex, ey))
            {
                Console.WriteLine("Invalid ending position.");
                System.Threading.Thread.Sleep(2000);
                return;
            }

            startX = sx;
            startY = sy;
            endX = ex;
            endY = ey;
        }
    }
}
