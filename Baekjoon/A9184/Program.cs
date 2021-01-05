using System;
using System.Collections.Generic;
using System.Text;

namespace A9184
{
    class Program
    {
        static int[,,] values = new int[21, 21, 21];
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            List<int[]> inputs = new List<int[]>();

            while (true)
            {
                var input = Console.ReadLine();
                string[] value = input.Split(' ');
                int a = int.Parse(value[0]);
                int b = int.Parse(value[1]);
                int c = int.Parse(value[2]);

                if (a == -1 && b == -1 && c == -1)
                    break;
                else
                    inputs.Add(new int[] { a, b, c });
            }
            foreach (var item in inputs)
            {
                sb.AppendLine($"w({item[0]}, {item[1]}, {item[2]}) = {w(item[0], item[1], item[2])}");
            }
            Console.WriteLine(sb);
        }

        static int w(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return 1;
            }
            else if (a > 20 || b > 20 || c > 20)
            {
                return values[20, 20, 20] = w(20, 20, 20);
            }
            else if (values[a, b, c] != 0)
            {
                return values[a, b, c];
            }
            else if (a < b && b < c)
            {
                return values[a, b, c] = w(a, b, c - 1) + w(a, b - 1, c - 1) - w(a, b - 1, c);
            }
            else
            {
                return values[a, b, c] = w(a - 1, b, c) + w(a - 1, b - 1, c) + w(a - 1, b, c - 1) - w(a - 1, b - 1, c - 1);
            }
        }
    }
}
