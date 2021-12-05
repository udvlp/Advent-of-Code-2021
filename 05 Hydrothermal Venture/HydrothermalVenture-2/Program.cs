using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");

            int[,] map = new int[1000, 1000];

            while (!sr.EndOfStream)
            {
                string l = sr.ReadLine();
                var p = l.Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries);
                (int x1, int y1, int x2, int y2) = (int.Parse(p[0]), int.Parse(p[1]), int.Parse(p[2]), int.Parse(p[3]));
                int dx = Math.Sign(x2 - x1);
                int dy = Math.Sign(y2 - y1);
                int x = x1;
                int y = y1;
                while (x != x2 + dx || y != y2 + dy)
                {
                    map[x, y]++;
                    x += dx;
                    y += dy;
                }
            }

            int c = 0;
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y] > 1) c++;
                }
            }

            Console.WriteLine(c);
        }
    }
}
