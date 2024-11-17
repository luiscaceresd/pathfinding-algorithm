using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class MapSelector
    {
        private List<string> mapFiles;

        public MapSelector()
        {
            mapFiles = new List<string> { "grid1.txt", "grid2.txt", "grid3.txt" };
        }

        public string SelectMap()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select a map to load:");

                for (int i = 0; i < mapFiles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Map {i + 1} ({mapFiles[i]})");
                }
                Console.WriteLine($"{mapFiles.Count + 1}. Exit the app");
                Console.Write("Please enter your choice (1-{0}): ", mapFiles.Count + 1);

                var key = Console.ReadKey(intercept: true);
                Console.WriteLine();

                int choice;
                if (int.TryParse(key.KeyChar.ToString(), out choice))
                {
                    if (choice >= 1 && choice <= mapFiles.Count)
                    {
                        return mapFiles[choice - 1];
                    }
                    else if (choice == mapFiles.Count + 1)
                    {
                        return null; // Exit the app
                    }
                }

                Console.WriteLine("Invalid choice. Please try again.");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
