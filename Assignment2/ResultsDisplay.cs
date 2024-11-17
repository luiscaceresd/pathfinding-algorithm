using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public static class ResultsDisplay
    {
        public static void ShowResults(Rover rover, bool reached)
        {
            Console.WriteLine("\nFinal path to the target:");
            foreach (var step in rover.Path)
            {
                Console.WriteLine($"Command: {step.command}, Position: ({step.x}, {step.y})");
            }

            Console.WriteLine("\nAll moves attempted by the rover (including backtracks):");
            foreach (var step in rover.AllMoves)
            {
                Console.WriteLine($"Command: {step.command}, Position: ({step.x}, {step.y})");
            }

            if (reached)
            {
                Console.WriteLine("\nThe rover has reached the target position.");
            }
            else
            {
                Console.WriteLine("\nThe rover did not reach the target position.");
            }
        }
    }
}
