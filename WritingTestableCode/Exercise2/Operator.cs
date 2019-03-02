using System;

namespace WritingTestableCode.Exercise2
{
    public class Operator : ICalculatorInput
    {
        private readonly Func<double, double, double> _operation;

        public Operator(Func<double, double, double> operation)
        {
            _operation = operation;
        }

        public void ApplyTo(CalculatorRegister register)
        {
            register.Queue(_operation);
        }
    }
}