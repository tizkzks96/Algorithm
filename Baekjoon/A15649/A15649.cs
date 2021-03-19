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


        }

        private void BackTracking(KeyValuePair<int, int> values)
        {
            Tree
            <string> answer = new List<string>();
            Stack<int> list = new Stack<int>();
            for (int i = 1; i <= values.Key; i++)
            {
                list.Push(i);
            }

            int riseCount = values.Value;

            while (riseCount <= 0)
            {
                string value = "";
                for (int i = 1; i < riseCount; i++)
                {
                    value += i;
                }
            }
            


        }

        private KeyValuePair<int, int> GetCaseValues()
        {
            KeyValuePair<int, int> caseValues = new KeyValuePair<int, int>();

            string[] value = sr.ReadLine().Split(" ");

            caseValues = new KeyValuePair<int, int>(int.Parse(value[0]), int.Parse(value[1]));

            return caseValues;
        }
    }

    class Tree
    {

    }
}
