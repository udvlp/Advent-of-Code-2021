using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            var line = sr.ReadLine();
            Console.WriteLine(line);
            int count = line.Length / 2;
            byte[] data = new byte[count + 8];
            for (int i = 0; i < count; i++)
            {
                data[i] = Convert.ToByte(line.Substring(i * 2, 2), 16);
            }
            for (int i = count; i < count + 8; i++)
            {
                data[i] = 0;
            }
            long start = 0;
            long result = parse(data, ref start);

            Console.WriteLine($"Final Result: {result}");
        }

        static long parse(byte[] data, ref long startoffset)
        {
            long offset = startoffset;
            long result;

            long bits(int length)
            {
                int i = (int)offset / 8;
                int b = (int)offset % 8;
                ulong r = 0;
                for (int k = 0; k < 8; k++) r = r << 8 | data[i+k];
                r = (r << b);
                r = r >> (64 - length);
                offset += length;
                return (long)r;
            }

            long version = bits(3);
            long typeid = bits(3);

            Console.WriteLine($"v{version} t{typeid}");

            if (typeid == 4)
            {
                long value = 0;
                while (true)
                {
                    long v = bits(5);
                    value = (value << 4) | (v & 0x0F);
                    if ((v & 0x10) == 0) break;
                }
                result = value;
            }
            else
            {
                long lentypeid = bits(1);
                long length;
                var list = new List<long>();
                if (lentypeid == 0)
                {
                    length = bits(15);
                    long end = offset + length;
                    long i = 0;
                    while (offset < end)
                    {
                        list.Add(parse(data, ref offset));
                        i++;
                    }
                }
                else
                {
                    length = bits(11);
                    for (long i = 0; i < length; i++)
                    {
                        list.Add(parse(data, ref offset));
                    }
                }

                if (typeid == 0) // sum
                {
                    result = 0;
                    foreach (long v in list) result += v;
                }
                else if (typeid == 1) // product 
                {
                    result = 1;
                    foreach (long v in list) result *= v;
                }
                else if (typeid == 2) // minimum  
                {
                    result = long.MaxValue;
                    foreach (long v in list) if (v < result) result = v;
                }
                else if (typeid == 3) // maximum  
                {
                    result = long.MinValue;
                    foreach (long v in list) if (v > result) result = v;
                }
                else if (typeid == 5) // greater than 
                {
                    result = list[0] > list[1] ? 1 : 0;
                }
                else if (typeid == 6) // less than 
                {
                    result = list[0] < list[1] ? 1 : 0;
                }
                else if (typeid == 7) // equal to 
                {
                    result = list[0] == list[1] ? 1 : 0;
                }
                else
                {
                    result = -1;
                }
            }

            startoffset = offset;
            Console.WriteLine($"Result: {result}");
            return result;
        }
    }
}
