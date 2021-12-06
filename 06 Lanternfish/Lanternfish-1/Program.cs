using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            const int days = 80;
            const int maxage = 8;
            var sr = new StreamReader(@"..\..\input.txt");
            int[] age = new int[maxage + 1];

            string l = sr.ReadLine();
            var p = l.Split(',');
            foreach (string s in p)
            {
                int i = int.Parse(s);
                age[i]++;
            }

            for (int i = 0; i < days; i++)
            {
                int a0 = age[0];
                for (int j = 1; j <= maxage; j++)
                {
                    age[j - 1] = age[j];
                    age[j] = 0;
                }
                age[8] += a0;
                age[6] += a0;
            }

            int e = 0;
            for (int j = 0; j <= maxage; j++) e += age[j];
            Console.WriteLine(e);
        }
    }
}
