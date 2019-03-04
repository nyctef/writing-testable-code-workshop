namespace WritingTestableCode.Exercise2
{
    internal class MemoryFunction : ICalculatorInput
    {
        private static double _memory;

        private readonly string _name;

        public MemoryFunction(string name)
        {
            _name = name;
        }

        public void ApplyTo(CalculatorRegister register)
        {
            switch (_name)
            {
                case "Add":
                    _memory += register.Value;
                    break;
                case "Subtract":
                    _memory -= register.Value;
                    break;
                case "Recall":
                    register.Value = _memory;
                    break;
            }
        }
    }
}