using System;

namespace WritingTestableCode.Exercise2
{
    public class CalculatorRegister
    {
        private const double InitialValue = 0;
        private static readonly Func<double, double, double> InitialOperation = (a, b) => b;

        private double _value = InitialValue;
        private Func<double, double, double> _operation = InitialOperation;

        public double Value
        {
            get => _value;
            set => _value = _operation(_value, value);
        }

        public void Queue(Func<double, double, double> operation)
        {
            _operation = operation;
        }

        public void Clear()
        {
            _value = InitialValue;
            _operation = InitialOperation;
        }
    }
}