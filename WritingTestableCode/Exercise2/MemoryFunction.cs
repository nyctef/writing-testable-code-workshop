using System;

namespace WritingTestableCode.Exercise2
{
    public class MemoryFunction : ICalculatorInput
    {
        private static double _memory;

        private readonly Action<CalculatorRegister> _applyTo;

        private MemoryFunction(Action<CalculatorRegister> applyTo)
        {
            _applyTo = applyTo;
        }

        public void ApplyTo(CalculatorRegister register)
        {
            _applyTo(register);
        }

        public static readonly MemoryFunction Add = new MemoryFunction(r => _memory += r.Value);

        public static readonly MemoryFunction Subtract = new MemoryFunction(r => _memory -= r.Value);

        public static readonly MemoryFunction Recall = new MemoryFunction(r => r.Value = _memory);
    }
}