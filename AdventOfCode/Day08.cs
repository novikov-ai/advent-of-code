using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    static class Day08
    {
        public static void ShowResult()
        {
            string input = File.ReadAllText("Input08.txt");
            string[] puzzle = input.Split('\n');

            int sign;
            string number;
            int num; // number before action
            int acc = 0; // accumulator value

            List<int> checkedList = new List<int>();
            List<int> doneSteps = new List<int>();

            for (int i = 0; i < puzzle.Length;)
            {
                if (!doneSteps.Contains(i))
                    doneSteps.Add(i);
                else
                    break;

                string[] line = puzzle[i].Split(" ");

                if (line[1].StartsWith('+'))
                {
                    sign = 1;
                    number = line[1].TrimStart('+');
                }
                else
                {
                    sign = -1;
                    number = line[1].TrimStart('-');
                }
                
                Int32.TryParse(number, out num);

                if (line[0] == "acc")
                {
                    acc += num * sign;
                    i++;
                }
                else if (line[0] == "jmp")
                    i += num * sign;
                else
                    i++;
            }

            Console.WriteLine("Day 08: " + acc);
        }
    }
}