using System;
using System.IO;

namespace AdventOfCode
{
    static class Day03
    {
        public static void ShowResult()
        {
            string input = File.ReadAllText("Input03.txt");
            string[] map = input.Split('\n');

            int deep = map.Length; // 323
            int width = map[0].Length; // 31

            //Console.WriteLine("W: " + width + " D: " + deep);

            long count0 = 0; // tree count
            int moveDown0 = 1;
            int moveRight0 = 1;

            while (moveDown0 < deep)
            {
                if (moveRight0 > width - 1)
                    moveRight0 = moveRight0 - width;

                if (map[moveDown0][moveRight0] == '#')
                    count0++;

                moveDown0++;
                moveRight0++;
            }

            long count = 0; // tree count
            int moveDown = 1;
            int moveRight = 3;

            while (moveDown < deep)
            {
                if (moveRight > width - 1)
                    moveRight = moveRight - width;

                if (map[moveDown][moveRight] == '#')
                    count++;

                moveDown++;
                moveRight += 3;
            }

            long count1 = 0; // tree count
            int moveDown1 = 1;
            int moveRight1 = 5;

            while (moveDown1 < deep)
            {
                if (moveRight1 > width - 1)
                    moveRight1 = moveRight1 - width;

                if (map[moveDown1][moveRight1] == '#')
                    count1++;

                moveDown1++;
                moveRight1 += 5;
            }

            long count2 = 0; // tree count
            int moveDown2 = 1;
            int moveRight2 = 7;

            while (moveDown2 < deep)
            {
                if (moveRight2 > width - 1)
                    moveRight2 = moveRight2 - width;

                if (map[moveDown2][moveRight2] == '#')
                    count2++;

                moveDown2++;
                moveRight2 += 7;
            }

            long count3 = 0; // tree count
            int moveDown3 = 2;
            int moveRight3 = 1;

            while (moveDown3 < deep)
            {
                if (moveRight3 > width - 1)
                    moveRight3 = moveRight3 - width;

                if (map[moveDown3][moveRight3] == '#')
                    count3++;

                moveDown3 += 2;
                moveRight3++;
            }

            long res = count0 * count * count1 * count2 * count3;
            Console.WriteLine("Day 03: " + res);
        }
    }
}