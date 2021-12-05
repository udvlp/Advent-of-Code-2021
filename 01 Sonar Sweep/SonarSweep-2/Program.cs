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
            var l = new List<int>();
            while (!sr.EndOfStream)
            {
                l.Add(int.Parse(sr.ReadLine()));
            }
            int c = 0;
            for (int i = 3; i < l.Count; i++)
            {
                if (l[i - 3] + l[i - 2] + l[i - 1] < l[i - 2] + l[i - 1] + l[i])
                {
                    c++;
                }
            }
            Console.WriteLine(c);
        }
    }
}
