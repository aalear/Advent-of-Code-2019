using System;
using System.IO;

namespace AdventOfCode2019
{
    public class Day1A : IPuzzle
    {
        public void Execute() 
        {
            var massList = File.ReadAllLines("day1/input.txt");
            var fuel = 0;

            foreach(var m in massList) 
            {
                var mass = int.Parse(m);
                fuel += (int)Math.Floor(mass / 3.0) - 2;
            }

            Console.WriteLine($"Fuel required: {fuel}");
        }
    }
}