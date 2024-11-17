using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Visualizer
    {
        private Grid grid;
        private int viewportWidth;
        private int viewportHeight;

        public Visualizer(Grid grid, int viewportWidth = 50, int viewportHeight = 25)
        {
            this.grid = grid;
            this.viewportWidth = viewportWidth;
            this.viewportHeight = viewportHeight;
        }

        public void DrawInteractiveGrid(int cursorX, int cursorY, int? startX, int? startY, int? endX, int? endY)
        {
            // Calculate the viewport's top-left corner
            int halfWidth = viewportWidth / 2;
            int halfHeight = viewportHeight / 2;

            int viewportStartX = cursorX - halfWidth;
            int viewportStartY = cursorY - halfHeight;

            // Adjust viewport position if near edges
            if (viewportStartX < 0) viewportStartX = 0;
            if (viewportStartY < 0) viewportStartY = 0;
            if (viewportStartX + viewportWidth > grid.Width) viewportStartX = grid.Width - viewportWidth;
            if (viewportStartY + viewportHeight > grid.Height) viewportStartY = grid.Height - viewportHeight;

            // Ensure viewport does not go negative after adjustments
            if (viewportStartX < 0) viewportStartX = 0;
            if (viewportStartY < 0) viewportStartY = 0;

            Console.SetCursorPosition(0, 0);

            for (int y = viewportStartY; y < viewportStartY + viewportHeight; y++)
            {
                for (int x = viewportStartX; x < viewportStartX + viewportWidth; x++)
                {
                    if (!grid.IsValidPosition(x, y))
                    {
                        Console.Write(" ");
                        continue;
                    }

                    if (x == cursorX && y == cursorY)
                    {
                        // Draw the cursor
                        Console.BackgroundColor = ConsoleColor.Gray;
                        if (grid.GetCellValue(x, y) == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("#");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                        }
                        Console.ResetColor();
                    }
                    else if (startX.HasValue && x == startX.Value && y == startY.Value)
                    {
                        // Draw the starting position
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("S");
                    }
                    else if (endX.HasValue && x == endX.Value && y == endY.Value)
                    {
                        // Draw the ending position
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("E");
                    }
                    else if (grid.GetCellValue(x, y) == 0)
                    {
                        // Draw an obstacle
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("#");
                    }
                    else
                    {
                        // Empty space
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();

            // Instructions
            Console.WriteLine("\nUse arrow keys to move the cursor.");
            if (!startX.HasValue)
            {
                Console.WriteLine("Press Enter or Space to select the starting position.");
            }
            else if (!endX.HasValue)
            {
                Console.WriteLine("Press Enter or Space to select the ending position.");
            }
        }

        public void DrawGrid(int roverX, int roverY, HashSet<(int x, int y)> visitedPositions, int startX, int startY, int endX, int endY)
        {
            // Calculate the viewport's top-left corner
            int halfWidth = viewportWidth / 2;
            int halfHeight = viewportHeight / 2;

            int viewportStartX = roverX - halfWidth;
            int viewportStartY = roverY - halfHeight;

            // Adjust viewport position if near edges
            if (viewportStartX < 0) viewportStartX = 0;
            if (viewportStartY < 0) viewportStartY = 0;
            if (viewportStartX + viewportWidth > grid.Width) viewportStartX = grid.Width - viewportWidth;
            if (viewportStartY + viewportHeight > grid.Height) viewportStartY = grid.Height - viewportHeight;

            // Ensure viewport does not go negative after adjustments
            if (viewportStartX < 0) viewportStartX = 0;
            if (viewportStartY < 0) viewportStartY = 0;

            Console.SetCursorPosition(0, 0);

            for (int y = viewportStartY; y < viewportStartY + viewportHeight; y++)
            {
                for (int x = viewportStartX; x < viewportStartX + viewportWidth; x++)
                {
                    if (!grid.IsValidPosition(x, y))
                    {
                        Console.Write(" ");
                        continue;
                    }

                    if (x == roverX && y == roverY)
                    {
                        // Draw the rover
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("R");
                    }
                    else if (x == startX && y == startY)
                    {
                        // Draw the starting position
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("S");
                    }
                    else if (x == endX && y == endY)
                    {
                        // Draw the ending position
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("E");
                    }
                    else if (grid.GetCellValue(x, y) == 0)
                    {
                        // Draw an obstacle
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("#");
                    }
                    else if (visitedPositions.Contains((x, y)))
                    {
                        // Draw visited positions
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(".");
                    }
                    else
                    {
                        // Empty space
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
