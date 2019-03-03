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
            Input(Number(2), Operator.Add, Number(3), Operator.Equal);
            Result.Should().Be(5);
        }

        [Test]
        public void Subtract_two_numbers()
        {
            Input(Number(5), Operator.Subtract, Number(3), Operator.Equal);
            Result.Should().Be(2);
        }

        [Test]
        public void Multiply_two_numbers()
        {
            Input(Number(2), Operator.Multiply, Number(3), Operator.Equal);
            Result.Should().Be(6);
        }

        [Test]
        public void Divide_two_numbers()
        {
            Input(Number(6), Operator.Divide, Number(3), Operator.Equal);
            Result.Should().Be(2);
        }

        [Test]
        public void Use_the_result_from_a_previous_operation_in_a_subsequent_operation()
        {
            Input(Number(2));
            Input(Operator.Add, Number(3));
            Input(Operator.Subtract, Number(1));
            Input(Operator.Multiply, Number(4));
            Input(Operator.Divide, Number(8));
            Input(Operator.Equal);

            Result.Should().Be(2);
        }

        [Test]
        public void Display_partial_results_for_multi_step_operation()
        {
            Input(Number(3), Operator.Add, Number(4), Operator.Equal);
            Result.Should().Be(7);
        }

        [Test]
        public void Refresh_result()
        {
            Input(Number(1), Operator.Equal, Number(2), Operator.Equal);
            Result.Should().Be(2);
        }

        [Test]
        public void Have_a_memory()
        {
            Input(Number(10), Operator.Add, Number(5), MemoryFunction.Add);
            Clear();
            Input(Number(12), MemoryFunction.Subtract);
            Clear();
            Input(Number(3));
            Input(Operator.Add, MemoryFunction.Recall);

            Result.Should().Be(6);
        }

        private static ICalculatorInput Number(double value) => new Number(value);

        private void Input(params ICalculatorInput[] inputs)
        {
            _calculator.Input(inputs);
        }

        private void Clear()
        {
            _calculator.Clear();
        }

        private double Result => _calculator.Display;
    }
}