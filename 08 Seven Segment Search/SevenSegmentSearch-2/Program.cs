using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static HashSet<char> createdigit(string segments)
        {
            var result = new HashSet<char>();
            foreach (char c in segments) result.Add(c);
            return result;
        }


        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            int sum = 0;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                var parts = line.Split(new String[] { " | ", " " }, StringSplitOptions.RemoveEmptyEntries);

                HashSet<char>[] digit = new HashSet<char>[10];

                foreach (var sample in parts)
                {
                    switch (sample.Length)
                    {
                        case 2: digit[1] = createdigit(sample); break;
                        case 3: digit[7] = createdigit(sample); break;
                        case 4: digit[4] = createdigit(sample); break;
                        case 7: digit[8] = createdigit(sample); break;
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    var d = createdigit(parts[i]);
                    if (parts[i].Length == 5)
                    {
                        if (d.IsSupersetOf(digit[7]))
                        {
                            digit[3] = d;
                        }
                        else
                        {
                            var t = new HashSet<char>(d);
                            t.IntersectWith(digit[4]);
                            if (t.Count == 3) digit[5] = d; else digit[2] = d;
                        }
                    }
                    else if (parts[i].Length == 6)
                    {
                        var t = new HashSet<char>(d);
                        t.IntersectWith(digit[7]);
                        if (t.Count == 2)
                        {
                            digit[6] = d;
                        }
                        else
                        {
                            t = new HashSet<char>(d);
                            t.IntersectWith(digit[4]);
                            if (t.Count == 4) digit[9] = d; else digit[0] = d;
                        }
                    }
                }

                int value = 0;
                for (int i = 10; i < 14; i++)
                {
                    var d = createdigit(parts[i]);
                    for (int n = 0; n < digit.Length; n++)
                    {
                        var t = new HashSet<char>(d);
                        t.SymmetricExceptWith(digit[n]);
                        if (t.Count == 0)
                        {
                            value = value * 10 + n;
                            break;
                        }
                    }
                }

                sum += value;

            }

            Console.WriteLine("Result: " + sum);
        }
    }
}
