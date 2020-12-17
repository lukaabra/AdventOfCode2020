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

            List<int> seatIDs = new List<int>();

            foreach (var seat in seats)
            {
                string binaryRow = "";
                string binaryCol = "";

                for (int i = 0; i < seat.Length; i++)
                {
                    switch (seat[i])
                    {
                        case 'F':
                            binaryRow += '0';
                            break;
                        case 'B':
                            binaryRow += '1';
                            break;
                        case 'L':
                            binaryCol += '0';
                            break;
                        case 'R':
                            binaryCol += '1';
                            break;
                    }
                }

                int rowID = Convert.ToInt32(binaryRow, 2);
                int colID = Convert.ToInt32(binaryCol, 2);

                seatIDs.Add(rowID * 8 + colID);
            }

            return seatIDs.Max(t => t);
        }

        public static int SolvePartTwo(string filePath)
        {
            string[] seats = File.ReadAllText(filePath).Split('\n');
            seats = seats.Take(seats.Count() - 1).ToArray();

            List<int> seatIDs = new List<int>();

            foreach (var seat in seats)
            {
                string binaryRow = "";
                string binaryCol = "";

                for (int i = 0; i < seat.Length; i++)
                {
                    switch (seat[i])
                    {
                        case 'F':
                            binaryRow += '0';
                            break;
                        case 'B':
                            binaryRow += '1';
                            break;
                        case 'L':
                            binaryCol += '0';
                            break;
                        case 'R':
                            binaryCol += '1';
                            break;
                    }
                }

                int rowID = Convert.ToInt32(binaryRow, 2);
                int colID = Convert.ToInt32(binaryCol, 2);

                seatIDs.Add(rowID * 8 + colID);
            }

            foreach (var seat in seatIDs)
            {
                if (seatIDs.Contains(seat + 2) && !seatIDs.Contains(seat + 1))
                    return seat + 1;
            }

            return 0;
        }
    }
}
