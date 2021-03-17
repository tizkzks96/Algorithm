using System;

namespace SA0001
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


    }

    public class Solution
    {
        public void Run()
        {
            GetCase(int.Parse(Console.ReadLine()));
        }

        int[] GetCase(int caseCount)
        {
            int[] A = new int[caseCount];
            for (int i = 0; i < caseCount; i++)
            {
                A[i] = int.Parse(Console.ReadLine());
            }
            return A;
        }
    }
}
