using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            int width = 0;
            List<int> o2 = new List<int>();
            List<int> co2 = new List<int>();

            while (!sr.EndOfStream)
            {
                string l = sr.ReadLine();
                if (width == 0) width = l.Length; else Debug.Assert(l.Length == width);
                int v = Convert.ToInt32(l, 2);
                o2.Add(v);
                co2.Add(v);
            }

            for (int i = width - 1; i >= 0 && o2.Count > 1; i--)
            {
                int a = 0;
                foreach (int v in o2) if ((v & (1 << i)) != 0) a++;
                int k = a >= o2.Count - a ? 1 << i : 0;
                o2.RemoveAll(v => o2.Count > 1 && (v & (1 << i)) != k);
            }

            for (int i = width - 1; i >= 0 && co2.Count > 1; i--)
            {
                int a = 0;
                foreach (int v in co2) if ((v & (1 << i)) != 0) a++;
                int k = a < co2.Count - a ? 1 << i : 0;
                co2.RemoveAll(v => co2.Count > 1 && (v & (1 << i)) != k);
            }

            Console.WriteLine(o2[0]);
            Console.WriteLine(co2[0]);
            Console.WriteLine(o2[0] * co2[0]);
        }
    }
}
