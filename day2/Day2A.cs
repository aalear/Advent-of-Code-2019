using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day2A : IPuzzle
    {
        public void Execute() 
        {
            var src = File.ReadAllLines("day2/input.txt")[0];
            var computer = IntcodeComputer.InitializeFrom(src);

            // Go back to 1202 program alarm state
            computer.SetInputs(12, 2);
            
            var output = computer.Run();

            Console.WriteLine($"Value in position 0: {output}");
        }
    }
}