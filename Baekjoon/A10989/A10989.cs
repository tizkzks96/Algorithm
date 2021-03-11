using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace A10989
{
    class A10989
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());

            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            StringBuilder sb = new StringBuilder();
            int[] countArray = new int[10000];

            int input = int.Parse(sr.ReadLine());

            //int input = 10000000;
            //int[] testCase = GetTestCase(input);

            for (int i = 0; i < input; i++)
            {
                //var temp = testCase[i] - 1;
                var temp = int.Parse(sr.ReadLine()) - 1;

                countArray[temp]++;
            }

            for (int i = 0; i < countArray.Length; i++)
            {
                sb.Clear();
                if (countArray[i] == 0) continue;
                for (int j = 0; j < countArray[i]; j++)
                {
                    sb.Append($"{i + 1}\n");
                }
                sw.Write(sb);
            }


            if (true)
            {

            }
        }

        static int[] GetTestCase(int input)
        {
            StringBuilder sb = new StringBuilder();

            int[] result = new int[input];
            Random r = new Random();

            for (int i = 0; i < input; i++)
            {
                result[i] = r.Next(1, 10001);
                sb.AppendLine($"{result[i]}");
            }

            //Console.WriteLine(sb);
            return result;
        }
    }
}
