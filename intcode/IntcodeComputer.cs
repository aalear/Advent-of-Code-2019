using System;
using System.Linq;

namespace AdventOfCode2019 
{
    public class IntcodeComputer 
    {
        private int[] _sourceData;
        private int[] _workingData;

        private IntcodeComputer(int[] data) {
            _sourceData = data;
            Reset();
        }

        public static IntcodeComputer InitializeFrom(string rawData) 
        {
            var data = rawData.Split(",").Select(i => int.Parse(i)).ToArray();
            return new IntcodeComputer(data);
        }

        public int[] WorkingData => _workingData;

        public void Reset() 
        {
            _workingData = new int[_sourceData.Length];
            Array.Copy(_sourceData, _workingData, _sourceData.Length);
        }

        public void SetInputs(int noun, int verb) 
        {
            _workingData[1] = noun;
            _workingData[2] = verb;
        }

        public int Run() {
            var opcodeIdx = 0;
            OpCode opcode;
            while((opcode = (OpCode)_workingData[opcodeIdx]) != OpCode.Halt) 
            {
                var a = _workingData[_workingData[opcodeIdx + 1]];
                var b = _workingData[_workingData[opcodeIdx + 2]];
                var destIdx = _workingData[opcodeIdx + 3];
                switch(opcode) 
                {
                    case OpCode.Add:
                        _workingData[destIdx] = a + b;
                        break;
                    case OpCode.Multiply:
                        _workingData[destIdx] = a * b;
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown opcode {opcode} found at idx {opcodeIdx}");
                }
                
                opcodeIdx += 4;
            }

            return _workingData[0];
        }
    }
}