using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            int count = 0;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                var parts = line.Split(" | ");
                var samples = parts[0].Split(' ');
                var codes = parts[1].Split(' ');

                foreach (var code in codes)
                {
                    int l = code.Length;
                    if (l == 2 || l == 3 || l == 4 || l == 7)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("Result: " + count);
        }
    }
}
