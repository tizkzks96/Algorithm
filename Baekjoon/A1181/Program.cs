using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace A1181
{
    class Program
    {
        static void Main(string[] args)
        {
            A1181 a1181 = new A1181();

            a1181.Run();
        }
    }

    class A1181
    {
        StringBuilder sb = new StringBuilder();
        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        
        public void Run()
        {
            sw.AutoFlush = true;
            
            Solution();
            //TestSolution();
        }

        private void Solution()
        {
            int caseCount = int.Parse(sr.ReadLine());

            List<string> caseValues = GetCaseValues(caseCount);

            caseValues = CustomSort(caseValues);

            ViewArray(caseValues);
        }

        private void TestSolution()
        {
            Random r = new Random();
            int runCount = 0;
            while (true)
            {
                int testCaseCount = r.Next(1, 10000);

                List<string> testCaseValues = GetTestCaseValues(testCaseCount);

                testCaseValues = CustomSort(testCaseValues);

                Console.WriteLine(runCount++);
                ViewArray(testCaseValues);
                Console.ReadLine();
            }
        }

        private void ViewArray(List<string> values)
        {
            sb.Clear();
            string check = "";
            foreach (var item in values)
            {
                if(check.Equals(item) == false)
                {
                    sb.AppendLine(item);
                    check = item;
                }
            }
            sw.Write(sb);
        }

        private List<string> CustomSort(List<string> values)
        {
            values.Sort((a, b) =>
            {
                if (a.Length < b.Length)
                    return -1;
                else if (a.Length > b.Length)
                {
                    return 1;
                }
                else
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i].Equals(b[i]) == false)
                        {
                            if(a[i] < b[i])
                            {
                                return -1;
                            }
                            else if(a[i] > b[i])
                            {
                                return 1;
                            }
                        }
                    }
                    return 1;
                }
            });

            return values;
        }

        private List<string> GetCaseValues(int count)
        {
            List<string> caseValues = new List<string>();
            for (int i = 0; i < count; i++)
            {
                caseValues.Add(sr.ReadLine());
            }

            return caseValues;
        }

        private List<string> GetTestCaseValues(int count)
        {
            List<string> testCaseValues = new List<string>();
            Random r = new Random();

            for (int i = 0; i < count; i++)
            {
                int stringLength = r.Next(1, 10);
                char[] value = new char[stringLength];

                for (int j = 0; j < stringLength; j++)
                {
                    value[j] = (char)r.Next(97, 123);
                    //value[j] = (char)r.Next(97, 98);
                }

                testCaseValues.Add(new string(value));
            }

            return testCaseValues;
        }

    }
}
