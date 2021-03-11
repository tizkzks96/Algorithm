using System;
using System.IO;

namespace A2108
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve solve = new Solve();
            //solve.CountingSortTest(5, false);
            solve.Run();
        }
    }

    class Solve
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        public void Run()
        {
            sw.AutoFlush = true;

            int count = int.Parse(sr.ReadLine());

            int[] values = GetValues(count);

            int[] countingSortResult = CountingSort(values);

            Calculate(countingSortResult, count, out float arithmeticMean, out int mode, out int median, out int range);

            sw.WriteLine(Math.Round(arithmeticMean, 0));
            sw.WriteLine(median);
            sw.WriteLine(mode);
            sw.WriteLine(range);
        }

        public int[] CountingSort(int[] values)
        {
            int[] result = new int[8001];
            for (int i = 0; i < values.Length; i++)
            {
                result[values[i]+4000]++;
            }

            return result;
        }

        public void CountingSortTest(int count, bool isRandom)
        {
            int[] values;
            if (isRandom)
            {
                values = GetValuesByRandom(count);
            }
            else
            {
                values = GetValues(count);
            }


            int[] result = CountingSort(values);
            for (int i = 0; i < 8001; i++)
            {
                if (result[i] == 0) continue;
                Console.WriteLine($"{i - 4000} {result[i]}");
            }
        }

        public int[] GetValuesByRandom(int count)
        {
            int[] result = new int[count];
            Random r = new Random();

            for (int i = 0; i < count; i++)
            {
                result[i] = r.Next(-4000, 4001);
            }

            return result;
        }

        public int[] GetValues(int count)
        {
            int[] values = new int[count];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = int.Parse(sr.ReadLine());
            }
            return values;
        }


        //산술 평균 : N개의 수들의 합을 N으로 나눈 값
        public void Calculate(int[] countingSortResult, int count, out float arithmeticMean, out int mode, out int median, out int range)
        {
            float middle = count / 2 + 0.5f;

            int valuesCount = 0;

            arithmeticMean = 0;

            int modeCount = 0;
            mode = 0;
            int mode1 = 0;

            median = -10000;

            int min = -10000;
            int max = -10000;

            for (int i = 0; i < countingSortResult.Length; i++)
            {
                if (countingSortResult[i] == 0) continue;

                int resultCount = countingSortResult[i];

                int index = i - 4000;

                //산술평균 : N개의 수들의 합을 N으로 나눈 값
                arithmeticMean += index * resultCount;

                //중앙값 : N개의 수들을 증가하는 순서로 나열했을 경우 그 중앙에 위치하는 값
                valuesCount += countingSortResult[i];
                if (valuesCount >= middle && median == -10000)
                {
                    median = index;
                }

                //최빈값 : N개의 수들 중 가장 많이 나타나는 값
                if (modeCount < resultCount)
                {
                    modeCount = resultCount;
                    mode = index;
                    mode1 = -10000;
                }
                else if(modeCount == resultCount && mode1 == -10000)
                {
                    mode1 = index;
                }

                

                //범위 : N개의 수들 중 최댓값과 최솟값의 차이
                if (min == -10000)
                {
                    min = index;
                }

                if(max < i - 4000)
                {
                    max = index;

                }
            }

            if(mode1 != -10000)
            {
                mode = mode1;
            }

            range = max - min;

            arithmeticMean /= count;
        }
    }
}
