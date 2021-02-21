using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    static class Day09
    {
        public static void ShowResult()
        {
            string input = File.ReadAllText("Input09.txt");
            string[] puzzle = input.Split('\n');

            // part1:

            int preamble = 25;
            int start;
            int end;
            List<int> allNums = new List<int>();

            int invalidNum = -1;
            bool ok = false;

            for (int i = 0; i < puzzle.Length; i++)
            {
                if (invalidNum != -1)
                    break;

                int num;
                Int32.TryParse(puzzle[i], out num);
                allNums.Add(num);

                if (i > (preamble - 1))
                {
                    start = i - preamble;
                    end = i - 1;

                    for (int j = start; j <= end; j++)
                    {
                        for (int k = start; k <= end; k++)
                        {
                            if (j == k)
                                continue;

                            if ((allNums[j] + allNums[k]) == allNums[i])
                                ok = true;
                        }
                    }

                    if (!ok)
                    {
                        invalidNum = allNums[i];
                        break;
                    }
                    ok = false;
                }
            }

            // part 2:

            List<int> contiguousSet = new List<int>();

            int sum = 0;
            int setLength = 0;

            int min = -1;
            int max = -1;

            int startFrom = 0;

            for (int i = 0; i < puzzle.Length;)
            {
                int num;
                Int32.TryParse(puzzle[i], out num);
                contiguousSet.Add(num);
                sum += num;

                if (sum > invalidNum)
                {
                    contiguousSet.Clear();
                    sum = 0;

                    startFrom++;
                    i = startFrom;
                }
                else
                {
                    if (sum == invalidNum && contiguousSet.Count > setLength)
                    {
                        contiguousSet.Sort();

                        min = contiguousSet[0];
                        max = contiguousSet[contiguousSet.Count - 1];

                        setLength = contiguousSet.Count;
                        sum = 0;

                        contiguousSet.Clear();

                        startFrom++;
                        i = startFrom;
                    }
                    else
                        i++;
                }
            }

            int result = min + max;

            Console.WriteLine("Day 09: " + result);
        }
    }
}