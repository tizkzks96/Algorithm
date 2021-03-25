using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace A9663
{
    class A9663
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
        int count = 0;
        public void Run()
        {
            sw.AutoFlush = true;

            var value = GetCaseValues();
            bool[,] map = new bool[value, value];
            //SetQ(2, 1, map);
            //ViewMap(map);
            DFS(0, map, 0);
            sw.WriteLine(count);
        }

        private void DFS(int currentDepth, bool[,] remain, int count)
        {

            if (count == remain.GetLength(0))
            {
                this.count++;
            }

            if (currentDepth >= remain.GetLength(0))
            {
                return;
            }

            for (int x = 0; x < remain.GetLength(0); x++)
            {
                if (remain[x, currentDepth] == false)
                {
                    remain[x, currentDepth] = true;
                    bool[,] newMap = (bool[,])remain.Clone();
                    SetQ(x, currentDepth, newMap);
                    DFS(currentDepth + 1, newMap, count + 1);
                }
            }
        }

        private void DFSWhile(int size)
        {
            int[] positions = new int[size];

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = -1;
            }

            for (int y = 0; y < size; y++)
            {
                int startIndex = 0;

                if (positions[y] != -1)
                {
                    startIndex = positions[y];
                }

                for (int x = startIndex; x < size; x++)
                {
                    if (Check(positions, x, y))
                    {
                        positions[y] = x;
                        break;
                    }
                }

                if(positions[y] == -1)
                {
                    if (positions[y - 1] > size)
                    {
                        y--;
                        positions[y - 1]++;
                    }
                    y--;
                    positions[y - 1]++;
                }
            }
        }

        private bool Check(int[] position , int x, int y)
        {
            for (int i = 0; i < position.Length - 1; i++)
            {
                //세로
                if (position[i] == x)
                {
                    return false;
                }

                //오른쪽 대각
                if(position[i] + y == x)
                {
                    return false;
                }

                //왼쪽 대각
                if (position[i] - y == x)
                {
                    return false;
                }
            }

            return true;
        }

        private int GetCaseValues()
        {
            int value = int.Parse(sr.ReadLine());

            return value;
        }

        private void SetQ(int x, int y, bool[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                //가로
                map[i, y] = true;

                //세로
                if (i > y)
                {
                    map[x, i] = true;
                }

                //오른쪽 대각
                if (x + i < map.GetLength(0) && y + i < map.GetLength(0))
                {
                    map[x + i, y + i] = true;
                }

                //왼쪽 대각
                if (x - i >= 0 && y + i < map.GetLength(0))
                {
                    map[x - i, y + i] = true;
                }
            }
            map[x, y] = true;
        }

        private void SetQ(int x, int y, int[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                //가로
                map[i, y] = 1;

                //세로
                if (i > y)
                {
                    map[x, i] = 1;
                }

                //오른쪽 대각
                if (x + i < map.GetLength(0) && y + i < map.GetLength(0))
                {
                    map[x + i, y + i] = 1;
                }

                //왼쪽 대각
                if (x - i >= 0 && y + i < map.GetLength(0))
                {
                    map[x - i, y + i] = 1;
                }
            }
            map[x, y] = 1;
        }

        private void ViewMap(int[,] map)
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[x, y] == 1) 
                    {
                        sb.Append(" x ");
                    }
                    else if(map[x,y] == 0)
                    {
                        sb.Append(" o ");
                    }
                    else
                    {
                        sb.Append(" q ");
                    }
                }
                sb.AppendLine();
            }

            sw.WriteLine(sb);
        }

        private void ViewMap(bool[,] map)
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[x, y])
                    {
                        sb.Append(" x ");
                    }
                    else
                    {
                        sb.Append(" q ");
                    }
                }
                sb.AppendLine();
            }

            sw.WriteLine(sb);
        }
    }
}
