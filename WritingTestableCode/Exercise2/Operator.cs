using System;

namespace WritingTestableCode.Exercise2
{
    public class Operator : ICalculatorInput
    {
        private readonly Func<double, double, double> _operation;

        private Operator(Func<double, double, double> operation)
        {
            _operation = operation;
        }

        public void ApplyTo(CalculatorRegister register)
        {
            register.Queue(_operation);
        }

        public static readonly Operator Add = new Operator((a, b) => a + b);

        public static readonly Operator Subtract = new Operator((a, b) => a - b);

        public static readonly Operator Multiply = new Operator((a, b) => a * b);

        public static readonly Operator Divide = new Operator((a, b) => a / b);

        public static readonly Operator Equal = new Operator((a, b) => b);
    }
}