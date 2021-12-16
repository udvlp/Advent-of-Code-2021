using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static int versionsum = 0;

        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            var line = sr.ReadLine();
            Console.WriteLine(line);
            int count = line.Length / 2;
            byte[] data = new byte[count + 4];
            for (int i = 0; i < count; i++)
            {
                data[i] = Convert.ToByte(line.Substring(i * 2, 2), 16);
            }
            for (int i = count; i < count + 4; i++)
            {
                data[i] = 0;
            }
            parse(data, 0);

            Console.WriteLine(versionsum);
        }

        static int parse(byte[] data, int startoffset)
        {
            int offset = startoffset;

            int bits(int length)
            {
                int i = offset / 8;
                int b = offset % 8;
                uint r = (uint)(data[i] << 24 | data[i + 1] << 16 | data[i + 2] << 8 | data[i + 3]);
                r = (r << b);
                r = r >> (32 - length);
                offset += length;
                return (int)r;
            }

            int version = bits(3);

            versionsum += version;

            int typeid = bits(3);

            Console.WriteLine($"v{version} t{typeid}");

            if (typeid == 4)
            {
                while (true)
                {
                    int v = bits(5);
                    if ((v & 0x10) == 0) break;
                }
            }
            else
            {
                int lentypeid = bits(1);
                int length;
                if (lentypeid == 0)
                {
                    length = bits(15);
                    int end = offset + length;
                    int i = 0;
                    while (offset < end)
                    {
                        offset = parse(data, offset);
                        i++;
                    }
                }
                else
                {
                    length = bits(11);
                    for (int i = 0; i < length; i++)
                    {
                        offset = parse(data, offset);
                    }
                }
            }
            return offset;
        }
    }
}
