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
            Input(new Number(2));
            Input(new Operator((a, b) => a + b));
            Input(new Number(3));
            Input(new Operator((a, b) => b));

            Result.Should().Be(5);
        }

        [Test]
        public void Subtract_two_numbers()
        {
            Input(new Number(5));
            Input(new Operator((a, b) => a - b));
            Input(new Number(3));
            Input(new Operator((a, b) => b));

            Result.Should().Be(2);
        }

        [Test]
        public void Multiply_two_numbers()
        {
            Input(new Number(2));
            Input(new Operator((a, b) => a * b));
            Input(new Number(3));
            Input(new Operator((a, b) => b));

            Result.Should().Be(6);
        }

        [Test]
        public void Divide_two_numbers()
        {
            Input(new Number(6));
            Input(new Operator((a, b) => a / b));
            Input(new Number(3));
            Input(new Operator((a, b) => b));

            Result.Should().Be(2);
        }

        [Test]
        public void Use_the_result_from_a_previous_operation_in_a_subsequent_operation()
        {
            Input(new Number(2));
            Input(new Operator((a, b) => a + b));
            Input(new Number(3));
            Input(new Operator((a, b) => a - b));
            Input(new Number(1));
            Input(new Operator((a, b) => a * b));
            Input(new Number(4));
            Input(new Operator((a, b) => a / b));
            Input(new Number(8));
            Input(new Operator((a, b) => b));

            Result.Should().Be(2);
        }

        [Test]
        public void Display_partial_results_for_multi_step_operation()
        {
            Input(new Number(3));
            Input(new Operator((a, b) => a + b));
            Input(new Number(4));
            Input(new Operator((a, b) => a - b));

            Result.Should().Be(7);
        }

        [Test]
        public void Refresh_result()
        {
            Input(new Number(1));
            Input(new Operator((a, b) => b));
            Input(new Number(2));
            Input(new Operator((a, b) => b));

            Result.Should().Be(2);
        }

        [Test]
        public void Have_a_memory()
        {
            Input(new Number(10));
            Input(new Operator((a, b) => a + b));
            Input(new Number(5));
            Input(new MemoryFunction("Add"));
            Clear();
            Input(new Number(12));
            Input(new MemoryFunction("Subtract"));
            Clear();
            Input(new Number(3));
            Input(new Operator((a, b) => a + b));
            Input(new MemoryFunction("Recall"));

            Result.Should().Be(6);
        }

        private void Input(ICalculatorInput input)
        {
            _calculator.Input(input);
        }

        private void Clear()
        {
            _calculator.Clear();
        }

        private double Result => _calculator.Display;
    }
}