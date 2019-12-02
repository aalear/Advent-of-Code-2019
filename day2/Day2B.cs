using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day2B : IPuzzle
    {
        private int[] _source;
        public void Execute()
        {
            _source = File.ReadAllLines("day2/input.txt")[0].Split(",").Select(i => int.Parse(i)).ToArray();

            int[] data = new int[_source.Length];
            for (var noun = 0; noun < 100; noun++) 
            {
                for (var verb = 0; verb < 100; verb++) 
                {
                    // Reset
                    Array.Copy(_source, data, _source.Length);

                    // Set up inputs
                    data[1] = noun;
                    data[2] = verb;

                    var opcodeIdx = 0;
                    OpCode opcode;
                    while((opcode = (OpCode)data[opcodeIdx]) != OpCode.Halt) 
                    {
                        var a = data[data[opcodeIdx + 1]];
                        var b = data[data[opcodeIdx + 2]];
                        var destIdx = data[opcodeIdx + 3];
                        switch(opcode) 
                        {
                            case OpCode.Add:
                                data[destIdx] = a + b;
                                break;
                            case OpCode.Multiply:
                                data[destIdx] = a * b;
                                break;
                            default:
                                throw new InvalidOperationException($"Unknown opcode {opcode} found at idx {opcodeIdx}");
                        }
                        
                        opcodeIdx += 4;
                    }

                    if(data[0] == 19690720) 
                    {
                        Console.WriteLine($"Inputs found: {100 * noun + verb}");
                    }
                }
            }
        }
    }
}