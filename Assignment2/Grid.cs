using System;
using System.IO;

namespace Assignment2
{
    public class Grid
    {
        private int[,] cells; // cells[y, x]
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Grid(string filename)
        {
            LoadGrid(filename);
        }

        public void LoadGrid(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                Height = lines.Length;
                Width = lines[0].Length;
                cells = new int[Height, Width];

                for (int y = 0; y < Height; y++)
                {
                    string line = lines[y];
                    for (int x = 0; x < Width; x++)
                    {
                        cells[y, x] = line[x] - '0'; // Convert char to int
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading the grid file: " + e.Message);
                Environment.Exit(1);
            }
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public bool IsAccessible(int x, int y)
        {
            return IsValidPosition(x, y) && cells[y, x] == 1;
        }

        public int GetCellValue(int x, int y)
        {
            return cells[y, x];
        }
    }
}
