namespace WritingTestableCode.Exercise2
{
    public class MemoryFunction : ICalculatorInput
    {
        private static double _memory;

        private readonly string _name;

        private MemoryFunction(string name)
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

        public static readonly MemoryFunction Add = new MemoryFunction("Add");

        public static readonly MemoryFunction Subtract = new MemoryFunction("Subtract");

        public static readonly MemoryFunction Recall = new MemoryFunction("Recall");
    }
}