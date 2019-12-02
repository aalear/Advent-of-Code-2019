using System;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Advent of Code 2019!");
            Console.WriteLine("*******************************");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("1a. Day 1A");
            Console.WriteLine("1b. Day 1B");
            Console.WriteLine("2a. Day 2A");
            Console.WriteLine("2b. Day 2B");
            Console.WriteLine("Q. Quit");

            Console.WriteLine();
            Console.WriteLine("Enter selection: ");

            string choice;
            while ((choice = Console.ReadLine().ToLowerInvariant()) != "q")
            {
                switch (choice)
                {
                    case "1a":
                        new Day1A().Execute();
                        break;
                    case "1b":
                        new Day1B().Execute();
                        break;
                    case "2a":
                        new Day2A().Execute();
                        break;
                    case "2b":
                        new Day2B().Execute();
                        break;
                    default:
                        Console.WriteLine("wat");
                        break;
                }
            }

            Environment.Exit(0);
        }
    }
}
