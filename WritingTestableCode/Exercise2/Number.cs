namespace WritingTestableCode.Exercise2
{
    internal class Number : ICalculatorInput
    {
        private readonly double _value;

        public Number(double value)
        {
            _value = value;
        }

        public void ApplyTo(CalculatorRegister register)
        {
            register.Value = _value;
        }
    }
}