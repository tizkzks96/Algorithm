using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace A1427
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());

            Run(sr.ReadLine());
            //TestCase(100);
        }

        static void Run(string inputCase)
        {
            StringBuilder sb = new StringBuilder();
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            int[] valuesCount = new int[10];
            for (int i = 0; i < inputCase.Length; i++)
            {
                valuesCount[inputCase[i] - 48]++;
            }

            for (int i = 9; i >= 0; i--)
            {
                for (int j = 0; j < valuesCount[i]; j++)
                {
                    sb.Append(i);
                }
            }
            sw.WriteLine(sb);
        }

        static void TestCase(int testCount)
        {
            Random r = new Random();
            for (int i = 0; i < testCount; i++)
            {
                Run(r.Next(0, 1000000000).ToString());
            }
        }
    }
}
