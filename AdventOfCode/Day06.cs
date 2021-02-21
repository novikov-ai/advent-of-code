using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    static class Day06
    {
        public static void ShowResult()
        {
            string input = File.ReadAllText("Input06.txt");

            string[] puzzle = input.Split('\n');
            int uniqueSum = 0; // unique answers of one group summing with others

            List<char> uniqueAnswers = new List<char>();

            // first part of the pazzle:

            //foreach (string item in puzzle)
            //{
            //    if (item == "")
            //    {
            //        uniqueSum += uniqueAnswers.Count;
            //        uniqueAnswers.Clear();
            //        continue;
            //    }

            //    for (int i = 0; i < item.Length; i++)
            //    {
            //        if (!uniqueAnswers.Contains(item[i]))
            //            uniqueAnswers.Add(item[i]);
            //    }
            //}

            //if (uniqueAnswers.Count > 0)
            //    uniqueSum += uniqueAnswers.Count;

            // second part of the pazzle:

            bool firstItem = true;

            Dictionary<char, int> answers = new Dictionary<char, int>();

            int persons = 0;

            foreach (string item in puzzle)
            {
                if (item == "")
                {
                    foreach (int value in answers.Values)
                    {
                        if (value == persons)
                            uniqueSum++;
                    }
                    answers.Clear();
                    firstItem = true;
                    persons = 0;
                    continue;
                }

                for (int i = 0; i < item.Length; i++)
                {
                    if (firstItem == true)
                    {
                        if (!answers.ContainsKey(item[i]))
                            answers.Add(item[i], 1);
                    }
                    else if (answers.ContainsKey(item[i]))
                        answers[item[i]]++;
                }

                firstItem = false;

                persons++;
            }

            foreach (int value in answers.Values)
                if (value == persons)
                    uniqueSum++;

            Console.WriteLine("Day 06: "+uniqueSum);
        }
    }
}