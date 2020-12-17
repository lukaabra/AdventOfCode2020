using System;
using System.Collections.Generic;
using System.Text;
using System.IO;using System.Linq;

namespace AdventOfCode
{
    static class Day6
    {
        public static int SolvePartOne(string filePath)
        {
            string[] file = File.ReadAllText(filePath).Split("\n");

            string group = "";
            int total = 0;

            foreach (var line in file)
            {
                if (line == "")
                {
                    total += new String(group.ToCharArray().Distinct().ToArray()).Length;
                    group = "";
                }

                group += line;
            }

            return total;
        }

        public static int SolvePartTwo(string filePath)
        {
            string[] file = File.ReadAllText(filePath).Split("\n");

            List<List<char>> group = new List<List<char>>();
            int total = 0;

            foreach (var line in file)
            {
                if (line == "" || line == "\r")
                {
                    var intersection = group.Aggregate<IEnumerable<char>>(
                                       (previousList, nextList) => previousList.Intersect(nextList)
                                       ).ToList();
                    total += intersection.Count;
                    group.Clear();
                }
                else
                {
                    group.Add(line.TrimEnd('\r', '\n').ToList());
                }
            }

            return total;
        }
    }
}
