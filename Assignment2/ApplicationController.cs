using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class ApplicationController
    {
        private MapSelector mapSelector;
        private Grid grid;
        private Visualizer visualizer;
        private PositionSelector positionSelector;
        private PositionInputHandler positionInputHandler;
        private PathfindingExecutor pathfindingExecutor;
        private UserInterface userInterface;

        public ApplicationController()
        {
            mapSelector = new MapSelector();
            userInterface = new UserInterface();
        }

        public void Run()
        {
            bool exitApp = false;

            while (!exitApp)
            {
                string mapFile = mapSelector.SelectMap();

                if (string.IsNullOrEmpty(mapFile))
                {
                    // User chose to exit the app
                    break;
                }

                grid = new Grid(mapFile);
                visualizer = new Visualizer(grid);
                positionSelector = new PositionSelector(grid, visualizer);
                positionInputHandler = new PositionInputHandler(grid, visualizer, positionSelector);
                pathfindingExecutor = new PathfindingExecutor(grid, visualizer);

                bool returnToMapSelection = false;
                while (!returnToMapSelection && !exitApp)
                {
                    Console.Clear();

                    // Select starting and ending positions
                    var positionsSelected = positionInputHandler.GetStartAndEndPositions(out int? startX, out int? startY, out int? endX, out int? endY);

                    // Validate positions
                    if (!positionsSelected)
                    {
                        Console.WriteLine("Positions not selected properly.");
                        System.Threading.Thread.Sleep(2000);
                        continue; // Allow the user to try again
                    }

                    // Execute pathfinding
                    var rover = new Rover(startX.Value, startY.Value);
                    bool interrupted = pathfindingExecutor.ExecutePathfinding(rover, startX.Value, startY.Value, endX.Value, endY.Value);

                    if (interrupted)
                    {
                        Console.WriteLine("\nPathfinding interrupted by the user.");
                    }
                    else
                    {
                        // Display results
                        ResultsDisplay.ShowResults(rover, pathfindingExecutor.ReachedTarget);
                    }

                    // Handle post-pathfinding options
                    var userChoice = userInterface.GetPostPathfindingOption();

                    switch (userChoice)
                    {
                        case UserInterface.PostPathfindingOption.AnotherSearch:
                            // Do another search on the same map
                            break;
                        case UserInterface.PostPathfindingOption.ChangeMap:
                            // Change the map
                            returnToMapSelection = true;
                            break;
                        case UserInterface.PostPathfindingOption.Exit:
                            // Exit the app
                            exitApp = true;
                            break;
                    }
                }
            }
        }
    }
}
