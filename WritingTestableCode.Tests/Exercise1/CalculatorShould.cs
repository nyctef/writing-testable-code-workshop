using FluentAssertions;
using NUnit.Framework;
using WritingTestableCode.Exercise1;

namespace WritingTestableCode.Tests.Exercise1
{
    [TestFixture]
    public class CalculatorShould
    {
        private Calculator _calculator;

        [SetUp]
        public void Set_up()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_two_numbers()
        {
            PerformOperation(1, CalculatorKey.Add, 2).Should().Be(3);
        }

        [Test]
        public void Subtract_two_numbers()
        {
            PerformOperation(5, CalculatorKey.Subtract, 2).Should().Be(3);
        }

        [Test]
        public void Multiply_two_numbers()
        {
            PerformOperation(3, CalculatorKey.Multiply, 2).Should().Be(6);
        }

        [Test]
        public void Divide_two_numbers()
        {
            PerformOperation(6, CalculatorKey.Divide, 2).Should().Be(3);
        }

        [Test]
        public void Use_the_result_from_a_previous_operation_in_a_subsequent_operation()
        {
            ProvideInput(2, CalculatorKey.Add);
            ProvideInput(3, CalculatorKey.Subtract);
            ProvideInput(1, CalculatorKey.Multiply);
            ProvideInput(4, CalculatorKey.Divide);
            ProvideInput(8, CalculatorKey.Equal);

            Result.Should().Be(2);
        }

        [Test]
        public void Display_partial_results_for_multi_step_operation()
        {
            ProvideInput(3, CalculatorKey.Add);
            ProvideInput(4, CalculatorKey.Subtract);

            Result.Should().Be(7);
        }

        [Test]
        public void Refresh_result()
        {
            ProvideInput(1, CalculatorKey.Equal);
            ProvideInput(2, CalculatorKey.Equal);

            Result.Should().Be(2);
        }

        private double PerformOperation(double leftOperand, CalculatorKey operation, double rightOperand)
        {
            ProvideInput(leftOperand, operation);
            ProvideInput(rightOperand, CalculatorKey.Equal);

            return Result;
        }

        private void ProvideInput(double number, CalculatorKey key)
        {
            _calculator.TypeNumber(number);
            _calculator.PressKey(key);
        }

        private double Result => _calculator.Display;
    }
}