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
            int aim = 0;
            while (!sr.EndOfStream)
            {
                string l = sr.ReadLine();
                string[] p = l.Split(' ');
                string cmd = p[0];
                int param = int.Parse(p[1]);
                switch (cmd)
                {
                    case "up":
                        aim -= param;
                        break;
                    case "down":
                        aim += param;
                        break;
                    case "forward":
                        hpos += param;
                        depth += param * aim;
                        break;
                }
            }
            Console.WriteLine(hpos + " " + depth + " " + hpos*depth);
        }
    }
}
