using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    static class Day04
    {
        public static void ShowResult()
        {
            string input = File.ReadAllText("Input04.txt");

            string[] passports = input.Split('\n');

            int valid = 0;
            int correct = 0;

            List<string> Data = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            foreach (string item in passports)
            {
                if (item == "")
                {
                    if (correct == 7)
                        valid++;

                    correct = 0;
                    continue;
                }

                string[] passport = item.Split(' ');
                foreach (string key in passport)
                {
                    string[] keys = key.Split(':');

                    if (Data.Contains(keys[0]))
                    {
                        switch (keys[0])
                        {
                            case "byr":
                                {
                                    if (keys[1].Length == 4)
                                    {
                                        int res;
                                        Int32.TryParse(keys[1], out res);
                                        if (res >= 1920 && res <= 2002)
                                            correct++;
                                    }
                                    break;
                                }

                            case "iyr":
                                {
                                    if (keys[1].Length == 4)
                                    {
                                        int res;
                                        Int32.TryParse(keys[1], out res);
                                        if (res >= 2010 && res <= 2020)
                                            correct++;
                                    }
                                    break;
                                }

                            case "eyr":
                                {
                                    if (keys[1].Length == 4)
                                    {
                                        int res;
                                        Int32.TryParse(keys[1], out res);
                                        if (res >= 2020 && res <= 2030)
                                            correct++;
                                    }
                                    break;
                                }

                            case "hgt":
                                {
                                    if (keys[1].EndsWith("cm"))
                                    {
                                        string heightNum = keys[1].Replace("cm", "");
                                        int res;
                                        Int32.TryParse(heightNum, out res);
                                        if (res >= 150 && res <= 193)
                                            correct++;
                                    }
                                    else if (keys[1].EndsWith("in"))
                                    {
                                        string heightNum = keys[1].Replace("in", "");
                                        int res;
                                        Int32.TryParse(heightNum, out res);
                                        if (res >= 59 && res <= 76)
                                            correct++;
                                    }

                                    break;
                                }

                            case "hcl":
                                {
                                    if (keys[1].Length == 7 && keys[1].StartsWith('#'))
                                    {
                                        List<char> ValidChars = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

                                        bool invalid = false;

                                        for (int i = 1; i < keys[1].Length; i++)
                                        {
                                            if (!ValidChars.Contains(keys[1][i]))
                                            {
                                                invalid = true;
                                                break;
                                            }
                                        }

                                        if (!invalid)
                                            correct++;
                                    }

                                    break;
                                }

                            case "ecl":
                                {
                                    List<string> Colors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                                    if (Colors.Contains(keys[1]))
                                        correct++;

                                    break;
                                }

                            case "pid":
                                {
                                    if (keys[1].Length == 9)
                                    {
                                        List<char> ValidChars = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                                        bool invalid = false;
                                        foreach (char ch in keys[1])
                                        {
                                            if (!ValidChars.Contains(ch))
                                            {
                                                invalid = true;
                                                break;
                                            }
                                        }

                                        if (!invalid)
                                            correct++;
                                    }
                                    break;
                                }
                        }
                    }
                }
            }

            if (correct == 7)
                valid++;

            // byr(Birth Year) - [1920 - 2002]
            // iyr(Issue Year) - [2010 - 2020]
            // eyr(Expiration Year) - [2020 - 2030]
            // hgt(Height) - [150-193cm / 59-76in]
            // hcl(Hair Color) - [#0-9 6times / #a-f 6times]
            // ecl(Eye Color) - [amb blu brn gry grn hzl oth]
            // pid(Passport ID) - [012345678]
            // cid(Country ID) - optional

            // byr(Birth Year) - four digits; at least 1920 and at most 2002.
            // iyr(Issue Year) - four digits; at least 2010 and at most 2020.
            // eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
            // hgt(Height) - a number followed by either cm or in:
            // If cm, the number must be at least 150 and at most 193.
            // If in, the number must be at least 59 and at most 76.
            // hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
            // ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
            // pid(Passport ID) - a nine - digit number, including leading zeroes.
            // cid(Country ID) - ignored, missing or not.

            Console.WriteLine("Day 04: " + valid);
        }
    }
}