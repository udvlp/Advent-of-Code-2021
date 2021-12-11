using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = { 3, 57, 1197, 25137 };
            string brackets = "([{<)]}>";

            var sr = new StreamReader(@"..\..\input.txt");
            int totalscore = 0;
            while (!sr.EndOfStream)
            {
                var l = sr.ReadLine();
                var stack = new Stack<char>();

                foreach (char c in l)
                {
                    int i = brackets.IndexOf(c);
                    if (i < 4)
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        var d = brackets[brackets.IndexOf(stack.Pop()) + 4];
                        if (c != d)
                        {
                            totalscore += scores[i - 4];
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Result: " + totalscore);
        }
    }
}
