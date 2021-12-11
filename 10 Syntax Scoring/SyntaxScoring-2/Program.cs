using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string brackets = "([{<)]}>";
            List<long> scores = new List<long>();
            var sr = new StreamReader(@"..\..\input.txt");
            while (!sr.EndOfStream)
            {
                var l = sr.ReadLine();
                var stack = new Stack<char>();
                bool ok = true;

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
                            ok = false;
                            break;
                        }
                    }
                }

                if (ok)
                {
                    long score = 0;
                    while (stack.Count > 0)
                    {
                        score = 5 * score + brackets.IndexOf(stack.Pop()) + 1;
                    }
                    scores.Add(score);
                }
            }

            scores.Sort();
            Console.WriteLine(scores[scores.Count / 2]);
        }
    }
}
