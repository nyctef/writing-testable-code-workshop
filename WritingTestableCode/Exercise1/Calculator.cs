using System;
using System.Collections.Generic;

namespace WritingTestableCode.Exercise1
{
    public class Calculator
    {
        private readonly Queue<double> _numbers = new Queue<double>();
        private CalculatorKey _key;

        public void TypeNumber(double number)
        {
            _numbers.Enqueue(number);
        }

        public void PressKey(CalculatorKey key)
        {
            if (_numbers.Count > 1)
            {
                var leftOperand = _numbers.Dequeue();
                var rightOperand = _numbers.Dequeue();
                var result = Calculate(leftOperand, rightOperand, _key);
                _numbers.Enqueue(result);
            }

            _key = key;
        }

        private double Calculate(double leftOperand, double rightOperand, CalculatorKey key)
        {
            switch (key)
            {
                case CalculatorKey.Add:
                    return leftOperand + rightOperand;
                case CalculatorKey.Subtract:
                    return leftOperand - rightOperand;
                case CalculatorKey.Multiply:
                    return leftOperand * rightOperand;
                case CalculatorKey.Divide:
                    return leftOperand / rightOperand;
                case CalculatorKey.Equal:
                    return rightOperand;
                default:
                    throw new ArgumentOutOfRangeException(nameof(key), key, null);
            }
        }

        public double Display => _numbers.Peek();
    }
}