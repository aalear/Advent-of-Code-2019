using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day2A : IPuzzle
    {
        public void Execute() 
        {
            var data = File.ReadAllLines("day2/input.txt")[0].Split(",").Select(i => int.Parse(i)).ToArray();

            // Go back to 1202 program alarm state
            data[1] = 12;
            data[2] = 2;

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

            Console.WriteLine($"Value in position 0: {data[0]}");
        }
    }
}