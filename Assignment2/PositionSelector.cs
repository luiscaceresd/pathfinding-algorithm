using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
     public class PositionSelector
    {
        private Grid grid;
        private Visualizer visualizer;

        public PositionSelector(Grid grid, Visualizer visualizer)
        {
            this.grid = grid;
            this.visualizer = visualizer;
        }

        public void SelectPositions(out int? startX, out int? startY, out int? endX, out int? endY)
        {
            startX = null;
            startY = null;
            endX = null;
            endY = null;

            int cursorX = 0;
            int cursorY = 0;

            bool selectingStart = true;
            bool positionsSelected = false;

            while (!positionsSelected)
            {
                visualizer.DrawInteractiveGrid(cursorX, cursorY, startX, startY, endX, endY);

                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursorY > 0) cursorY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorY < grid.Height - 1) cursorY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursorX > 0) cursorX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorX < grid.Width - 1) cursorX++;
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (grid.IsAccessible(cursorX, cursorY))
                        {
                            if (selectingStart)
                            {
                                startX = cursorX;
                                startY = cursorY;
                                selectingStart = false;
                            }
                            else
                            {
                                endX = cursorX;
                                endY = cursorY;
                                positionsSelected = true;
                            }
                        }
                        else
                        {
                            // Cannot select an obstacle
                            Console.Beep();
                        }
                        break;
                    case ConsoleKey.Escape:
                        // Exit the selection
                        positionsSelected = true;
                        break;
                }
            }
        }
    }
}
