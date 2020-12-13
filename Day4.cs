using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    static class Day4
    {
        public static int SolvePartOne(string filePath)
        {
            string file = File.ReadAllText(filePath);
            Regex passportRegex = new Regex(@"(((\w+):.+)( |\n)?)+", RegexOptions.IgnoreCase);

            Regex iyrRegex = new Regex(@"(iyr:.*)");
            Regex eyrRegex = new Regex(@"(eyr:.*)");
            Regex byrRegex = new Regex(@"(byr:.*)");
            Regex eclRegex = new Regex(@"(ecl:.*)");
            Regex hgtRegex = new Regex(@"(hgt:.*)");
            Regex hclRegex = new Regex(@"(hcl:.*)");
            Regex pidRegex = new Regex(@"(pid:.*)");

            MatchCollection passportMatches = passportRegex.Matches(file);
            int validPassports = 0;

            foreach (Match passport in passportMatches)
            {
                if (iyrRegex.IsMatch(passport.Value) &&
                    eyrRegex.IsMatch(passport.Value) &&
                    byrRegex.IsMatch(passport.Value) &&
                    eclRegex.IsMatch(passport.Value) &&
                    hgtRegex.IsMatch(passport.Value) &&
                    hclRegex.IsMatch(passport.Value) &&
                    pidRegex.IsMatch(passport.Value))
                    validPassports++;
            }


            return validPassports;
        }

        public static int SolvePartTwo(string filePath)
        {
            string file = File.ReadAllText(filePath);
            Regex passportRegex = new Regex(@"(((\w+):.+)( |\n)?)+");

            Regex iyrRegex = new Regex(@"(iyr:(201[0-9]|2020))");
            Regex eyrRegex = new Regex(@"(eyr:(202[0-9]|2030]))");
            Regex byrRegex = new Regex(@"(byr:(19[2-9][0-9]|200[0-2]))");
            Regex eclRegex = new Regex(@"(ecl:(amb|blu|brn|gry|grn|hzl|oth))");
            Regex hgtRegex = new Regex(@"(hgt:(((1[5-8][0-9]|19[0-3])cm)|((59|6[0-9]|7[0-6])in)))");
            Regex hclRegex = new Regex(@"(hcl:\#[0-9a-f]{6})");
            Regex pidRegex = new Regex(@"(pid:\d{9})");

            MatchCollection passportMatches = passportRegex.Matches(file);
            int validPassports = 0;

            foreach (Match passport in passportMatches)
            {
                if (iyrRegex.IsMatch(passport.Value) &&
                    eyrRegex.IsMatch(passport.Value) &&
                    byrRegex.IsMatch(passport.Value) &&
                    eclRegex.IsMatch(passport.Value) &&
                    hgtRegex.IsMatch(passport.Value) &&
                    hclRegex.IsMatch(passport.Value) &&
                    pidRegex.IsMatch(passport.Value))
                    validPassports++;
            }

            return validPassports;
        }
    }
}
