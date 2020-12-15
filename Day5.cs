using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    static class Day5
    {
        public static int SolvePartOne(string filePath)
        {
            string[] seats = File.ReadAllText(filePath).Split('\n');
            seats = seats.Take(seats.Count() - 1).ToArray();

            int highestSeatID = 0;

            foreach (string seat in seats)
            {
                int low = 0;
                int high = 127;
                int mid = (low + high) / 2;

                // Find row
                for (int i = 0; i < 7; i++)
                {
                    mid = (low + high) / 2;

                    switch (seat[i])
                    {
                        case 'F':
                            high = mid;
                            break;
                        case 'B':
                            low = mid + 1;
                            break;
                    }
                }

                int rowNum = mid;

                low = 0;
                high = 7;

                // Find column
                for (int i = 7; i < 10; i++)
                {
                    mid = (low + high) / 2;

                    switch (seat[i])
                    {
                        case 'R':
                            low = mid + 1;
                            break;
                        case 'L':
                            high = mid;
                            break;
                    }
                }

                int colNum = mid == low ? low : high;
                int seatID = rowNum * 8 + colNum;

                Console.WriteLine($"{seatID}   {rowNum}   {colNum}");
                
                if (seatID > highestSeatID)
                    highestSeatID = seatID;
            }

            return highestSeatID;

        }

        public static int SolvePartTwo(string filePath)
        {
            string[] seats = File.ReadAllText(filePath).Split('\n');
            seats = seats.Take(seats.Count() - 1).ToArray();

            List<int> seatNums = new List<int>();

            foreach (string seat in seats)
            {
                int low = 0;
                int high = 127;
                int mid = (low + high) / 2;

                // Find row
                for (int i = 0; i < 7; i++)
                {
                    mid = (low + high) / 2;

                    switch (seat[i])
                    {
                        case 'F':
                            high = mid;
                            break;
                        case 'B':
                            low = mid + 1;
                            break;
                    }
                }

                int rowNum = mid;

                low = 0;
                high = 7;

                // Find column
                for (int i = 7; i < 10; i++)
                {
                    mid = (low + high) / 2;

                    switch (seat[i])
                    {
                        case 'R':
                            low = mid + 1;
                            break;
                        case 'L':
                            high = mid;
                            break;
                    }
                }

                int colNum = mid == low ? low : high;
                int seatID = rowNum * 8 + colNum;

                seatNums.Add(seatID);
            }

            // Find missing seat
            seatNums.Sort();
            var set = new HashSet<int>(seatNums);

            foreach (var item in set)
            {
                if (set.Contains(item - 2) && !set.Contains(item - 1))
                    return item - 1;
                else if (set.Contains(item + 2) && !set.Contains(item + 1))
                    return item + 1;
            }

            return 0;
        }
    }
}
