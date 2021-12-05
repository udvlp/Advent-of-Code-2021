using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            int hpos = 0;
            int depth = 0;
            while (!sr.EndOfStream)
            {
                string l = sr.ReadLine();
                string[] p = l.Split(' ');
                string cmd = p[0];
                int param = int.Parse(p[1]);
                switch (cmd)
                {
                    case "up":
                        depth -= param;
                        break;
                    case "down":
                        depth += param;
                        break;
                    case "forward":
                        hpos += param;
                        break;
                }
            }
            Console.WriteLine(hpos + " " + depth + " " + hpos*depth);
        }
    }
}
