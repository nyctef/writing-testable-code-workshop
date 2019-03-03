using System.Collections.Generic;

namespace WritingTestableCode.Exercise2
{
    public class ScientificCalculator
    {
        private readonly CalculatorRegister _register = new CalculatorRegister();

        public void Input(IEnumerable<ICalculatorInput> inputs)
        {
            foreach (var input in inputs)
            {
                input.ApplyTo(_register);
            }
        }

        public void Clear()
        {
            _register.Clear();
        }

        public double Display => _register.Value;
    }
}