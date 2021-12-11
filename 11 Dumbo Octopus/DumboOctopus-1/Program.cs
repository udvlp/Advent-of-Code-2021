using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

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

            Console.WriteLine($"{width} x {height}");

            for (int y = 0; y < height; y++)
            {
                Trace.Assert(lines[y].Length == width);
                for (int x = 0; x < width; x++)
                {
                    field[x, y] = lines[y][x] - '0';
                }
            }

            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        field[x, y]++;
                    }
                }

                bool b = true;
                while (b)
                {
                    b = false;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            if (field[x, y] > 9)
                            {
                                field[x, y] = 0;
                                count++;
                                for (int dy = -1; dy <= 1; dy++)
                                {
                                    for (int dx = -1; dx <= 1; dx++)
                                    {
                                        if (dx == 0 && dy == 0 || x + dx < 0 || x + dx >= width || y + dy < 0 || y + dy >= height) continue;
                                        if (field[x + dx, y + dy] > 0 && field[x + dx, y + dy] <= 9)
                                        {
                                            field[x + dx, y + dy]++;
                                            b = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Console.Write(field[x, y]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine($"After Step: {i+1} Result: {count}");

            }

        }
    }
}
