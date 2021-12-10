using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"..\..\input.txt");
            int width = lines[0].Length;
            int height = lines.Length;
            int[,] field = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    field[x, y] = lines[y][x] - '0';
                }
            }

            int risklevel = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (
                        field[x, y] < (x > 0 ? field[x - 1, y] : int.MaxValue) &&
                        field[x, y] < (y > 0 ? field[x, y - 1] : int.MaxValue) &&
                        field[x, y] < (x < width - 1 ? field[x + 1, y] : int.MaxValue) &&
                        field[x, y] < (y < height - 1 ? field[x, y + 1] : int.MaxValue)
                        )
                    {
                        risklevel += field[x, y] + 1;
                    }
                }
            }

            Console.WriteLine("Result: " + risklevel);
        }
    }
}
