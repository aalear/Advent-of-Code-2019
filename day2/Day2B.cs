using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day2B : IPuzzle
    {
        public void Execute()
        {
            var src = File.ReadAllLines("day2/input.txt")[0];
            var computer = IntcodeComputer.InitializeFrom(src);

            for (var noun = 0; noun < 100; noun++) 
            {
                for (var verb = 0; verb < 100; verb++) 
                {
                    computer.Reset();
                    computer.SetInputs(noun, verb);
                    
                    var output = computer.Run();

                    if(output == 19690720) 
                    {
                        Console.WriteLine($"Inputs found: {100 * noun + verb}");
                    }
                }
            }
        }
    }
}