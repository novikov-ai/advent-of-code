using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    static class Day07
    {
        public static void ShowResult()
        {
            string input = File.ReadAllText("Input07.txt");
            input = input.Replace("bags", "");
            input = input.Replace("bag", "");

            string[] puzzle = input.Split('\n');

            List<string> listContainsAllGoldBags = new List<string>();
            List<string> listContainsBags = new List<string>();
            int goldBags = 0;
            string find = "shiny gold";

            while (find != "")
            {
                foreach (string item in puzzle)
                {
                    string[] bags = item.Split("contain"); // [0] = light red bags ; [1] = 1 bright white bag, 2 muted yellow bags.
                    bags[0] = bags[0].Trim();
                    if (bags[1].Contains(find))
                        if (!listContainsBags.Contains(bags[0]))
                            listContainsBags.Add(bags[0]); // 1) Count all the colors in the list
                }

                if (listContainsBags.Count > 0)
                {
                    foreach (string item in listContainsBags)
                    {
                        if (!listContainsAllGoldBags.Contains(item))
                            listContainsAllGoldBags.Add(item);
                    }

                    find = listContainsBags[0];
                    listContainsBags.RemoveAt(0);
                }
                else
                    find = "";
            }

            goldBags = listContainsAllGoldBags.Count;
            Console.WriteLine("Day 07: " + goldBags);
        }
    }

    class Node
    {
        public string Name;
        public int Quantity;
        public List<Node> Children;

        public Node(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
            Children = null;
        }

        public void AddChild(Node node)
        {
            if (Children == null)
                Children = new List<Node>();

            Children.Add(node);
        }
    }
}