using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace A15649
{
    //N과 M(1)
    class A15649
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            solution.Run();
        }
    }

    class Solution
    {
        StringBuilder sb = new StringBuilder();
        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        public void Run()
        {
            sw.AutoFlush = true;

            var values = GetCaseValues();

            Queue<int> remain = new Queue<int>();

            for (int i = 1; i <= values.Key; i++)
            {
                remain.Enqueue(i);
            }

            BackTracking(values.Value, 0, remain, new List<int>());
            sw.WriteLine(sb);
        }

        private void BackTracking(int targetDepth, int currentDepth, Queue<int> remain, List<int> list, int addNum = 0)
        {
            if(targetDepth < currentDepth)
            {
                foreach (var item in list)
                {
                    sb.Append($"{item} ");
                }
                sb.AppendLine();
                return;
            }
            if (addNum != 0)
            {
                list.Add(addNum);
            }
            for (int i = 0; i < remain.Count; i++)
            {
                addNum = remain.Dequeue();
                BackTracking(targetDepth, currentDepth + 1, remain, list, addNum);
                remain.Enqueue(addNum);
            }

            return;
        }

        private KeyValuePair<int, int> GetCaseValues()
        {
            string[] value = sr.ReadLine().Split(" ");

            KeyValuePair<int, int> caseValues = new KeyValuePair<int, int>(int.Parse(value[0]), int.Parse(value[1]));

            return caseValues;
        }
    }
}
