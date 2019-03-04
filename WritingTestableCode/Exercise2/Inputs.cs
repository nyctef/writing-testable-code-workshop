namespace WritingTestableCode.Exercise2
{

    public static class Inputs
    {
        public static ICalculatorInput Number(int num) => new Number(num);
        public static ICalculatorInput Add() => new Operator((x, y) => x + y);
        public static ICalculatorInput Subtract() => new Operator((x, y) => x - y);
        public static ICalculatorInput Multiply() => new Operator((x, y) => x * y);
        public static ICalculatorInput Divide() => new Operator((x, y) => x / y);
        public static ICalculatorInput Equals() => new Operator((x, y) => y);
        public static ICalculatorInput AddToMemory() => new MemoryFunction("Add");
        public static ICalculatorInput SubtractFromMemory() => new MemoryFunction("Subtract");
        public static ICalculatorInput FetchFromMemory() => new MemoryFunction("Recall");
    }
}