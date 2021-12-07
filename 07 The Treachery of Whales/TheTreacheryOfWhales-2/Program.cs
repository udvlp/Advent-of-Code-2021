using System;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            string l = sr.ReadLine();

            var sw = new Stopwatch();
            sw.Start();

            var p = l.Split(',');
            int[] crabs = new int[p.Length];
            int maxpos = int.MinValue;
            int minpos = int.MaxValue;

            for (int i = 0; i < p.Length; i++)
            {
                crabs[i] = int.Parse(p[i]);
                if (crabs[i] > maxpos) maxpos = crabs[i];
                if (crabs[i] < minpos) minpos = crabs[i];
            }

            int minfuel = int.MaxValue;
            for (int pos = minpos; pos <= maxpos; pos++)
            {
                int fuel = 0;
                for (int i = 0; i < crabs.Length; i++)
                {
                    int c = Math.Abs(crabs[i] - pos);
                    fuel += c * (c + 1) / 2;
                }
                if (fuel < minfuel)
                {
                    minfuel = fuel;
                }
            }

            sw.Stop();

            Console.WriteLine("Result: " + minfuel);
            Console.WriteLine("Elapsed: " + sw.Elapsed.ToString());
        }
    }
}
