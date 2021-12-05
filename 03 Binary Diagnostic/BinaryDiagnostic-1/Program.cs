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
            const int width = 12;
            int c = 0;
            int[] a = new int[width];

            while (!sr.EndOfStream)
            {
                string l = sr.ReadLine();
                Debug.Assert(l.Length == width);
                int v = Convert.ToInt32(l, 2);
                for (int i = 0; i < width; i++)
                {
                    if ((v & (1 << i)) != 0) a[i]++;
                }
                c++;
            }
            int r = 0;
            for (int i = 0; i < width; i++)
            {
                if (a[i] > c - a[i]) r |= (1 << i);  
            }
            int n = r ^ ((1 << width) - 1);
            
            Console.WriteLine(r + " " + n + " " + r * n);
        }
    }
}
