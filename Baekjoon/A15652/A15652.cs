using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace A15652
{
    class A15652
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
            List<int> remain = new List<int>();

            for (int i = 1; i <= values.Key; i++)
            {
                remain.Add(i);
            }

            BackTracking(values.Value, 0, remain, new List<int>());
            sw.WriteLine(sb);
        }

        private void BackTracking(int targetDepth, int currentDepth, List<int> remain, List<int> list)
        {
            List<int> newList;
            int addNum;

            if (targetDepth == currentDepth)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sb.Append($"{list[i]} ");
                }
                sb.AppendLine();
                return;
            }

            for (int i = 0; i < remain.Count; i++)
            {
                addNum = remain[i];

                if(currentDepth > 0 && addNum < list[^1])
                {
                    continue;
                }

                newList = new List<int>(list)
                {
                    addNum
                };
                BackTracking(targetDepth, currentDepth + 1, remain, newList);
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
