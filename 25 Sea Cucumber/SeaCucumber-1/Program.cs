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
            var field = new char[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    field[x, y] = lines[y][x];
                }
            }
            lines = null;

            bool changed = true;
            int steps = 0;
            while (changed)
            {
                changed = false;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (field[x, y] == '>')
                        {
                            if (field[(x + 1) % width, y] == '.')
                            {
                                field[x, y] = 'X';
                                field[(x + 1) % width, y] = '>';
                                x++;
                                changed = true;
                            }
                        }
                    }
                }

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (field[x, y] == 'X') field[x, y] = '.';
                    }
                }

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (field[x, y] == 'v')
                        {
                            if (field[x, (y + 1) % height] == '.')
                            {
                                field[x, y] = 'X';
                                field[x, (y + 1) % height] = 'v';
                                y++;
                                changed = true;
                            }
                        }
                    }
                }

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (field[x, y] == 'X') field[x, y] = '.';
                    }
                }

                steps++;
            }

            Console.WriteLine($"Result: {steps}");
        }
    }

}
