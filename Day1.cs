using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    static class Day1
    {
        static public int SolvePartOne(string filePath)
        {
            string file = File.ReadAllText(filePath);
            string[] numbers = file.Split("\n", StringSplitOptions.None);
            int target = 2020;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int a = Convert.ToInt32(numbers[i]);

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (i != j)
                    {
                        int b = Convert.ToInt32(numbers[j]);

                        if (a + b == target)
                            return a * b;
                    }
                }
            }

            return 0;
        }

        static public int SolvePartTwo(string filePath)
        {
            string file = File.ReadAllText(filePath);
            string[] numbers = file.Split("\n", StringSplitOptions.None);
            int target = 2020;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int a = Convert.ToInt32(numbers[i]);

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    int b = Convert.ToInt32(numbers[j]);

                    for (int k = 0; k < numbers.Length - 1; k++)
                    {
                        if (i != j && j != k)
                        {
                            int c = Convert.ToInt32(numbers[k]);

                            if (a + b + c == target)
                                return a * b * c;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
