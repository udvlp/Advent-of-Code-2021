using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            string l = sr.ReadLine();
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

            Console.WriteLine(minfuel);
        }
    }
}
