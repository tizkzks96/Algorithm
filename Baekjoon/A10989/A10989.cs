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
            StringBuilder sb = new StringBuilder();
            int[] countArray = new int[10000];

            //int input = int.Parse(Console.ReadLine());

            int input = 10000000;
            int[] testCase = GetTestCase();

            for (int i = 0; i < input; i++)
            {
                var temp = testCase[i];

                countArray[temp]++;
            }

            for (int i = 0; i < countArray.Length; i++)
            {
                if (countArray[i] == 0) continue;
                for (int j = 0; j < countArray[i]; j++)
                {
                    sb.AppendLine($"{i}");
                }
            }

            //Console.WriteLine(sb);
        }

        static int[] GetTestCase()
        {
            StringBuilder sb = new StringBuilder();

            int[] result = new int[10000000];
            Random r = new Random();

            for (int i = 0; i < 10000000; i++)
            {
                result[i] = r.Next(1, 10001);
                sb.AppendLine($"{result[i]}");
            }

            //Console.WriteLine(sb);
            return result;
        }
    }
}
