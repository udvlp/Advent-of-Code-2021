using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    struct Coords
    {
        public readonly int x;
        public readonly int y;

        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

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
                Trace.Assert(lines[y].Length == width);
                for (int x = 0; x < width; x++)
                {
                    field[x, y] = lines[y][x] - '0';
                }
            }

            List<Coords> lowpoints = new List<Coords>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (field[x, y] < (x > 0 ? field[x - 1, y] : int.MaxValue)
                        && field[x, y] < (y > 0 ? field[x, y - 1] : int.MaxValue)
                        && field[x, y] < (x < width - 1 ? field[x + 1, y] : int.MaxValue)
                        && field[x, y] < (y < height - 1 ? field[x, y + 1] : int.MaxValue))
                    {
                        lowpoints.Add(new Coords(x, y));
                    }
                }
            }

            List<int> basins = new List<int>();

            foreach (var lp in lowpoints)
            {
                Queue<Coords> todo = new Queue<Coords>();
                HashSet<Coords> done = new HashSet<Coords>();

                void Todo(int x, int y, int dx, int dy)
                {
                    var n = new Coords(x + dx, y + dy);
                    if (n.x >= 0 && n.y >= 0 && n.x < width && n.y < height && !done.Contains(n) && field[n.x, n.y] > field[x, y] && field[n.x, n.y] < 9) todo.Enqueue(n);
                }

                todo.Enqueue(lp);

                while (todo.Count > 0)
                {
                    var c = todo.Dequeue();
                    Todo(c.x, c.y, -1, 0);
                    Todo(c.x, c.y, +1, 0);
                    Todo(c.x, c.y, 0, -1);
                    Todo(c.x, c.y, 0, +1);
                    done.Add(c);
                }

                basins.Add(done.Count);
            }

            basins.Sort((a, b) => b.CompareTo(a));

            int prod = 1;
            for (int i = 0; i < 3; i++) prod *= basins[i];

            Console.WriteLine("Result: " + prod);
        }
    }
}
