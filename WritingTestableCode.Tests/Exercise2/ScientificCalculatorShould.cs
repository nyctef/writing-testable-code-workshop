using FluentAssertions;
using NUnit.Framework;
using WritingTestableCode.Exercise2;

namespace WritingTestableCode.Tests.Exercise2
{
    [TestFixture]
    public class ScientificCalculatorShould
    {
        private ScientificCalculator _calculator;

        [SetUp]
        public void Set_up()
        {
            _calculator = new ScientificCalculator();
        }

        [Test]
        public void Add_two_numbers()
        {
            Input(Number(2), AddOperator, Number(3), EqualOperator);
            Result.Should().Be(5);
        }

        [Test]
        public void Subtract_two_numbers()
        {
            Input(Number(5), SubtractOperator, Number(3), EqualOperator);
            Result.Should().Be(2);
        }

        [Test]
        public void Multiply_two_numbers()
        {
            Input(Number(2), MultiplyOperator, Number(3), EqualOperator);
            Result.Should().Be(6);
        }

        [Test]
        public void Divide_two_numbers()
        {
            Input(Number(6), DivideOperator, Number(3), EqualOperator);
            Result.Should().Be(2);
        }

        [Test]
        public void Use_the_result_from_a_previous_operation_in_a_subsequent_operation()
        {
            Input(Number(2));
            Input(AddOperator, Number(3));
            Input(SubtractOperator, Number(1));
            Input(MultiplyOperator, Number(4));
            Input(DivideOperator, Number(8));
            Input(EqualOperator);

            Result.Should().Be(2);
        }

        [Test]
        public void Display_partial_results_for_multi_step_operation()
        {
            Input(Number(3), AddOperator, Number(4), EqualOperator);
            Result.Should().Be(7);
        }

        [Test]
        public void Refresh_result()
        {
            Input(Number(1), EqualOperator, Number(2), EqualOperator);
            Result.Should().Be(2);
        }

        [Test]
        public void Have_a_memory()
        {
            Input(Number(10), AddOperator, Number(5), AddMemoryFunction);
            Clear();
            Input(Number(12), SubtractMemoryFunction);
            Clear();
            Input(Number(3));
            Input(AddOperator, RecallMemoryFunction);

            Result.Should().Be(6);
        }

        private static ICalculatorInput Number(double value) => new Number(value);

        private static ICalculatorInput AddOperator => new Operator((a, b) => a + b);

        private static ICalculatorInput SubtractOperator => new Operator((a, b) => a - b);

        private static ICalculatorInput MultiplyOperator => new Operator((a, b) => a * b);

        private static ICalculatorInput DivideOperator => new Operator((a, b) => a / b);

        private static ICalculatorInput EqualOperator => new Operator((a, b) => b);

        private static ICalculatorInput AddMemoryFunction => new MemoryFunction("Add");

        private static ICalculatorInput SubtractMemoryFunction => new MemoryFunction("Subtract");

        private static ICalculatorInput RecallMemoryFunction => new MemoryFunction("Recall");

        private void Input(params ICalculatorInput[] inputs)
        {
            foreach (var input in inputs)
            {
                _calculator.Input(input);
            }
        }

        private void Clear()
        {
            _calculator.Clear();
        }

        private double Result => _calculator.Display;
    }
}