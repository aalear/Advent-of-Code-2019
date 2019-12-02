using System;
using System.IO;

namespace AdventOfCode2019
{
    public class Day1B : IPuzzle
    {
        public void Execute() 
        {
            var massList = File.ReadAllLines("day1/input.txt");
            var fuelTotal = 0;

            foreach(var m in massList) 
            {
                var mass = int.Parse(m);
                var fuel = CalcFuel(mass);
                fuelTotal += fuel;

                while (fuel > 0)
                {
                    fuel = CalcFuel(fuel);
                    if (fuel > 0)
                    {
                        fuelTotal += fuel;
                    }
                }
            }

            Console.WriteLine($"Fuel required: {fuelTotal}");
        }

        private int CalcFuel(int mass) 
        {
            return (int)Math.Floor(mass / 3.0) - 2;
        }
    }
}