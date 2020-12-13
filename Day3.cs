using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    static class Day3
    {
        public static int SolvePartOne(string filePath)
        {
            string file = File.ReadAllText(filePath);
            string[] lines = file.Split("\n");

            int xStep = 3;
            int yStep = 1;
            int posX = 0;
            int posY = 0;
            int treeCount = 0;

            while(posY < lines.Length - 1)
            {
                if (lines[posY][posX] == '#')
                    treeCount++;

                if (posX + xStep >= lines[posY].Length)
                    posX = posX + xStep - lines[posY].Length;
                else
                    posX += xStep;

                posY += yStep;
            }

            return treeCount;
        }

        public static long SolvePartTwo(string filePath)
        {
            string file = File.ReadAllText(filePath);
            string[] lines = file.Split("\n");

            int[] xStep = new int[] { 1, 3, 5, 7, 1 };
            int[] yStep = new int[] { 1, 1, 1, 1, 2 };
            long[] treeCount = new long[xStep.Length];

            for (int i = 0; i < xStep.Length; i++)
            {
                int posX = 0;
                int posY = 0;

                while (posY < lines.Length - 1)
                {
                    if (lines[posY][posX] == '#')
                        treeCount[i]++;

                    if (posX + xStep[i] >= lines[posY].Length)
                        posX = posX + xStep[i] - lines[posY].Length;
                    else
                        posX += xStep[i];

                    posY += yStep[i];
                }
            }

            return treeCount.Aggregate(Convert.ToInt64(1), (acc, val) => acc * val);
        }
    }
}
