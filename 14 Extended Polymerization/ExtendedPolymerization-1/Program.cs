using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            var dict = new Dictionary<string, string>();

            string polymer = sr.ReadLine();
            
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Length > 0)
                {
                    var p = line.Split(" -> ");
                    dict.Add(p[0], p[1]);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                string newpoly = "";
                for (int k = 0; k < polymer.Length - 1; k++)
                {
                    newpoly += polymer[k] + dict[polymer.Substring(k, 2)];
                }
                newpoly += polymer[polymer.Length - 1];
                polymer = newpoly;
            }

            var count = new Dictionary<char, int>();
            
            foreach (char c in polymer)
            {
                count.TryAdd(c, 0);
                count[c]++;
            }

            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (int a in count.Values)
            {
                if (a > max) max = a;
                if (a < min) min = a;
            }

            Console.WriteLine($"Result: {max}-{min}={max-min}");
        }
    }
}
