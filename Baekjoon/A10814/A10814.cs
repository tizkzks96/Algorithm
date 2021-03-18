using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace A10814
{
    class A10814
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            solution.Run();
        }
    }

    public class Solution
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        StringBuilder sb = new StringBuilder();

        public void Run()
        {
            sw.AutoFlush = true;

            int count = int.Parse(sr.ReadLine());
            var values = GetCase(count);
            values = CustomSort(values);
            View(values);
        }

        
        private List<KeyValuePair<int, KeyValuePair<int, string>>> CustomSort(List<KeyValuePair<int, KeyValuePair<int, string>>> values)
        {
            values.Sort((a, b) => 
            {
                if (a.Value.Key < b.Value.Key)
                {
                    return -1;
                }
                else if (a.Value.Key > b.Value.Key)
                {
                    return 1;
                }
                else
                {
                    return a.Key.CompareTo(b.Key);
                }
            });

            return values;
        }

        private List<KeyValuePair<int, KeyValuePair<int, string>>> GetCase(int count)
        {
            List<KeyValuePair<int, KeyValuePair<int, string>>> values = new List<KeyValuePair<int, KeyValuePair<int, string>>>();
            for (int i = 0; i < count; i++)
            {
                string[] value = sr.ReadLine().Split(" ");
                KeyValuePair<int, string> user = new KeyValuePair<int, string>(int.Parse(value[0]), value[1]);
                KeyValuePair<int, KeyValuePair<int, string>> item = new KeyValuePair<int, KeyValuePair<int, string>>(i, user);
                values.Add(item);
            }
            return values;
        }

        private void View(List<KeyValuePair<int, KeyValuePair<int, string>>> values)
        {
            sb.Clear();
            foreach (var item in values)
            {
                sb.AppendLine($"{item.Value.Key} {item.Value.Value}");
            }
            sw.Write(sb);
        }
    }
}
