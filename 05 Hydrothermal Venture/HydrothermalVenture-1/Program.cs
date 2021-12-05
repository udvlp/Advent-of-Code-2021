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
                if (y1 == y2)
                {
                    for (int i = Math.Min(x1, x2); i <= Math.Max(x1, x2); i++)
                    {
                        map[i, y1]++;
                    }
                }
                else if (x1 == x2)
                {
                    for (int i = Math.Min(y1, y2); i <= Math.Max(y1, y2); i++)
                    {
                        map[x1, i]++;
                    }
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
