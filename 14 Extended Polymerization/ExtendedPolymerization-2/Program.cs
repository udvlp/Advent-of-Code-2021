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
            var translate = new Dictionary<string, string>();

            string polymer = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Length > 0)
                {
                    var p = line.Split(" -> ");
                    translate.Add(p[0], p[1]);
                }
            }

            var pairs = new Dictionary<string, ulong>();
            var elements = new Dictionary<string, ulong>();

            for (int k = 0; k < polymer.Length - 1; k++)
            {
                var p = polymer.Substring(k, 2);
                pairs.TryAdd(p, 0);
                pairs[p]++;
            }

            for (int k = 0; k < polymer.Length; k++)
            {
                elements.TryAdd(polymer[k].ToString(), 0);
                elements[polymer[k].ToString()]++;
            }

            for (int i = 0; i < 40; i++)
            {
                var newpairs = new Dictionary<string, ulong>();
                foreach (var p in pairs.Keys)
                {
                    var insert = translate[p];
                    var c = pairs[p];
                    newpairs.TryAdd(p[0] + insert, 0);
                    newpairs[p[0] + insert] += c;
                    newpairs.TryAdd(insert + p[1], 0);
                    newpairs[insert + p[1]] += c;
                    elements.TryAdd(insert, 0);
                    elements[insert] += c;
                }
                pairs = newpairs;
            }

            ulong min = ulong.MaxValue;
            ulong max = ulong.MinValue;

            foreach (var a in elements.Values)
            {
                if (a > max) max = a;
                if (a < min) min = a;
            }

            Console.WriteLine($"Result: {max} - {min} = {max - min}");
        }
    }
}
