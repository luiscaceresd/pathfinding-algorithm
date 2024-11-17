using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class UserInterface
    {
        public enum PostPathfindingOption
        {
            AnotherSearch,
            ChangeMap,
            Exit
        }

        public PostPathfindingOption GetPostPathfindingOption()
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Do another search on the same map");
            Console.WriteLine("2. Change the map");
            Console.WriteLine("3. Exit the app");
            Console.Write("Please enter your choice (1-3): ");

            var key = Console.ReadKey(intercept: true);
            Console.WriteLine();

            switch (key.KeyChar)
            {
                case '1':
                    return PostPathfindingOption.AnotherSearch;
                case '2':
                    return PostPathfindingOption.ChangeMap;
                case '3':
                    return PostPathfindingOption.Exit;
                default:
                    Console.WriteLine("Invalid choice. Exiting the app.");
                    System.Threading.Thread.Sleep(2000);
                    return PostPathfindingOption.Exit;
            }
        }
    }
}
