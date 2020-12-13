using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    static class Day2
    {
        public static int SolvePartOne(string filePath)
        {
            string file = File.ReadAllText(filePath);
            int totalCount = 0;
            Regex regex = new Regex(@"(\d+)-(\d+) (\w): (\w+)", RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(file);

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                int min = Convert.ToInt32(groups[1].Value);
                int max = Convert.ToInt32(groups[2].Value);
                char character = Convert.ToChar(groups[3].Value);
                string password = groups[4].Value;

                int count = 0;
                foreach (char letter in password)
                {
                    if (letter == character)
                        count++;
                }

                if (count >= min && count <= max)
                    totalCount++;
            }

            return totalCount;
        }

        public static int SolvePartTwo(string filePath)
        {
            string file = File.ReadAllText(filePath);
            int totalCount = 0;
            Regex regex = new Regex(@"(\d+)-(\d+) (\w): (\w+)", RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(file);

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                int pos1 = Convert.ToInt32(groups[1].Value) - 1;
                int pos2 = Convert.ToInt32(groups[2].Value) - 1;
                char character = Convert.ToChar(groups[3].Value);
                string password = groups[4].Value;

                if (password[pos1] == character && password[pos2] != character)
                    totalCount++;
                else if (password[pos1] != character && password[pos2] == character)
                    totalCount++;
            }

            return totalCount;
        }
    }
}
