using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    static class Day10
    {
        public static void ShowResult()
        {
            string input = File.ReadAllText("Input10.txt");
            string[] puzzle = input.Split('\n');

            int oneJolts = 0;
            int threeJolts = 0;
            int diff = 0;
            List<int> allNum = new List<int>();

            for (int i = 0; i < puzzle.Length; i++)
            {
                int num;
                Int32.TryParse(puzzle[i], out num);
                allNum.Add(num);
            }

            allNum.Sort();

            for (int i = 0; i < allNum.Count; i++)
            {
                if (i == 0)
                    diff = allNum[i] - 0;
                else
                    diff = allNum[i] - allNum[i - 1];

                if (diff == 1)
                    oneJolts++;

                if (diff == 3)
                    threeJolts++;

            }

            threeJolts++; // for device built-in adapter that is always 3 higher than the highest adapter

            int result = oneJolts * threeJolts; // 22*10=220

            Console.WriteLine("Day 10: " + result);
        }
    }
}