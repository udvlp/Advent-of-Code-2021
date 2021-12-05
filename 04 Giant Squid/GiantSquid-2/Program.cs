using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdventOfCode
{
    class Board
    {
        public int[,] numbers = new int[5, 5];
        public bool[,] marked = new bool[5, 5];

        public void mark(int n)
        {
            for (int y = 0; y < numbers.GetLength(1); y++)
            {
                for (int x = 0; x < numbers.GetLength(0); x++)
                {
                    if (numbers[x, y] == n) marked[x, y] = true;
                }

            }
        }

        public bool check()
        {
            for (int y = 0; y < numbers.GetLength(1); y++)
            {
                bool w = true;
                for (int x = 0; x < numbers.GetLength(0); x++)
                {
                    if (!marked[x, y])
                    {
                        w = false;
                        break;
                    }
                }
                if (w) return true;
            }
            for (int x = 0; x < numbers.GetLength(0); x++)
            {
                bool w = true;
                for (int y = 0; y < numbers.GetLength(1); y++)
                {
                    if (!marked[x, y])
                    {
                        w = false;
                        break;
                    }
                }
                if (w) return true;
            }
            return false;
        }

        public int sum()
        {
            int result = 0;
            for (int y = 0; y < numbers.GetLength(1); y++)
            {
                for (int x = 0; x < numbers.GetLength(0); x++)
                {
                    if (!marked[x, y]) result += numbers[x, y];
                }
            }
            return result;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Board> boards = new List<Board>();
            List<int> numbers = new List<int>();

            var sr = new StreamReader(@"..\..\input.txt");

            {
                string[] split = sr.ReadLine().Split(',');
                foreach (string s in split) numbers.Add(int.Parse(s));
            }

            {
                Board board = null;
                int y = 0;
                while (!sr.EndOfStream)
                {
                    string l = sr.ReadLine();
                    if (l == "")
                    {
                        board = new Board();
                        boards.Add(board);
                        y = 0;
                    }
                    else
                    {
                        Debug.Assert(board != null);
                        Debug.Assert(y < 5);
                        string[] split = l.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        Debug.Assert(split.Length == 5);
                        int x = 0;
                        foreach (string s in split)
                        {
                            board.numbers[x, y] = int.Parse(s);
                            x++;
                        }
                        y++;
                    }
                }
            }

            List<Board> won = new List<Board>();
            foreach (int n in numbers)
            {
                foreach (Board b in boards)
                {
                    b.mark(n);
                }

                foreach (Board b in boards)
                {
                    if (!won.Contains(b))
                    {
                        if (b.check())
                        {
                            Console.WriteLine("Board " + boards.IndexOf(b) + " won, final score: " + (b.sum() * n));
                            won.Add(b);
                        }
                    }
                }

            }
        }
    }
}
