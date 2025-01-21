using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace LeetContest27042024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new int[] {1,0,0,0},
                new int[] {0,1,0,1},
                new int[] {1,0,0,0},
            };
            
            Console.WriteLine(NumberOfRightTriangles(grid));
            Console.ReadLine();
        }
        public static bool CanMakeSquare(char[][] grid)
        {
            bool result = false;

            for (int i = 0; i < 4; i++)
            {
                result = CheckOneColorSqr(grid,  i);
                if(result == true) return true;
            }
            return false;
        }

        /// <summary>
        /// https://leetcode.com/problems/make-a-square-with-the-same-color/description/
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool CheckOneColorSqr(char[][] grid, int x)
        {
            int counterW = 0;
            int counterB = 0;

            switch (x)
            {
                case 0:
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (grid[i][j] == 'B') counterB++;
                            else counterW++;
                        }
                    } 
                    break;
                case 1:
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 1; j < 3; j++)
                        {
                            if (grid[i][j] == 'B') counterB++;
                            else counterW++;
                        }
                    }
                    break;
                case 2:
                    for (int i = 1; i < 3; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (grid[i][j] == 'B') counterB++;
                            else counterW++;
                        }
                    }
                    break;
                case 3:
                    for (int i = 1; i < 3; i++)
                    {
                        for (int j = 1; j < 3; j++)
                        {
                            if (grid[i][j] == 'B') counterB++;
                            else counterW++;
                        }
                    }
                    break;
            }
            if (counterW >= 3 || counterB >= 3) { return true; }
            return false;
        }

        /// <summary>
        /// https://leetcode.com/problems/right-triangles/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static long NumberOfRightTriangles(int[][] grid)
        {
            long oneRowCounter, oneColumnCounter, triangleCounter = 0;
            Dictionary<long, long> columnsMap = new Dictionary<long, long>(grid[0].Length);
            /*for(int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    oneRowCounter = 0;
                    oneColumnCounter = 0;
                    if (grid[i][j] == 0) continue;
                    oneColumnCounter = CountOnesInColumn(grid, j);
                    oneRowCounter = CountOnesInRow(grid, i);

                    if (oneColumnCounter > 1 && oneRowCounter > 1)
                        triangleCounter += GetTriangleCount(oneRowCounter, oneColumnCounter);
                }                
            }*/

            for (int i = 0; i < grid.Length; i++)
            { 
                oneRowCounter = 0;
                oneRowCounter = CountOnesInRow(grid, i);
                for (int j = 0; j < grid[i].Length; j++)
                {                   
                    oneColumnCounter = 0;
                    if (grid[i][j] == 0) continue;                        
                    
                    if(!columnsMap.ContainsKey(j))
                    {
                        columnsMap[j] = CountOnesInColumn(grid, j);
                        oneColumnCounter = columnsMap[j];
                    }
                    else
                    {
                        oneColumnCounter = columnsMap[j];
                    }

                    if (oneColumnCounter > 1 && oneRowCounter > 1)
                        triangleCounter += GetTriangleCount(oneRowCounter, oneColumnCounter);
                } 
                
            }
            return triangleCounter;
        }

        public static long CountOnesInRow(int[][] grid, int i)
        {
            int count = 0;
            for(int n = 0; n < grid[i].Length; n++)
            {
                if (grid[i][n] == 1)
                {
                    count++;
                }
            }
            return count;
        }
        public static long CountOnesInColumn(int[][] grid, int j)
        {
            int count = 0;
            for(int n = 0; n < grid.Length; n++)
            {
                if (grid[n][j] == 1)
                {
                    count++;
                }
            }
            return count;
        }
        public static long GetTriangleCount(long oneRowCounter, long oneColumnCounter)
        {
            return (oneRowCounter - 1) * (oneColumnCounter - 1);
        }
    }
}
