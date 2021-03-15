using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace A11651
{
    class Program
    {
        static void Main(string[] args)
        {
            A11651 a11651 = new A11651();
            a11651.Run();
        }
    }

    class A11651
    {
        StringBuilder sb = new StringBuilder();
        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        public void Run()
        {
            Solve(GetCase(int.Parse(sr.ReadLine())));

        }

        public void RunTest()
        {
            Random r = new Random();

            while (true)
            {
                Solve(TestCase(r.Next(-1, 100001)));
            }
        }

        void Solve(List<KeyValuePair<int, int>> values)
        {

            values.Sort((a, b) =>
            {
                if (a.Value == b.Value)
                {
                    return a.Key.CompareTo(b.Key);
                }
                else
                {
                    return a.Value.CompareTo(b.Value);
                }
            });

            foreach (var item in values)
            {
                sb.AppendLine(item.Key + " " + item.Value);
            }
            sw.AutoFlush = true;
            sw.Write(sb);
        }

        List<KeyValuePair<int, int>> GetCase(int count)
        {
            List<KeyValuePair<int, int>> values = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < count; i++)
            {
                var value = sr.ReadLine().Split(" ");
                values.Add(new KeyValuePair<int, int>(int.Parse(value[0]), int.Parse(value[1])));
            }
            return values;
        }

        public List<KeyValuePair<int, int>> TestCase(int count)
        {
            List<KeyValuePair<int, int>> values = new List<KeyValuePair<int, int>>();
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                int x = r.Next(-100000, 100001);
                int y = r.Next(-100000, 100001);
                values.Add(new KeyValuePair<int, int>(x, y));
            }
            return values;
        }

    }
}
