using System;
using System.Text;

namespace A2751
{
    class A2751
    {

        static void Run()
        {
            StringBuilder sb = new StringBuilder();
            int input = int.Parse(Console.ReadLine());
            int[] array = new int[input];

            for (int i = 0; i < input; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(array);

            for (int i = 0; i < array.Length; i++)
            {
                sb.AppendLine($"{array[i]}");
            }

            Console.WriteLine(sb);
        }

        static void Main(string[] args)
        {
            Run();
        }
    }
}
