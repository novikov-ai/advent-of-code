using System;
using System.IO;

namespace AdventOfCode
{
    static class Day02
    {
        public static void ShowResult()
        {
            string input = File.ReadAllText("Input02.txt");
            string[] allPasswords = input.Split('\n');

            int posOne = -1; // position one
            int posTwo = -1; // position two

            char letter = ' '; // a given letter
            string pass = " "; // current password

            int passwords = 0; // quantity of correct passwords

            foreach (string item in allPasswords)
            {
                string[] array = item.Split(' ');
                string[] length = array[0].Split('-');

                posOne = Convert.ToInt32(length[0]) - 1;
                posTwo = Convert.ToInt32(length[1]) - 1;

                letter = array[1][0];

                pass = array[2];

                if (pass[posOne] == letter)
                {
                    if (pass[posTwo] != letter)
                        passwords++;
                }
                else
                {
                    if (pass[posTwo] == letter)
                        passwords++;
                }
            }
            Console.WriteLine("Day 02: " + passwords);
        }
    }
}