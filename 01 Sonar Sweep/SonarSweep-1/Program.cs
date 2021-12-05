using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = int.MinValue;
            var sr = new StreamReader(@"..\..\input.txt");
            int c = 0;
            while (!sr.EndOfStream)
            {
                string l = sr.ReadLine();
                int v = int.Parse(l);
                if (p != int.MinValue)
                {
                    if (v > p) c++;
                }
                p = v;
            }
            Console.WriteLine(c);
        }
    }
}
