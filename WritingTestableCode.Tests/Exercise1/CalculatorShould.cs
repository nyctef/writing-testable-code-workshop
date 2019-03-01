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
            _calculator.TypeNumber(2);
            _calculator.PressKey(CalculatorKey.Add);
            _calculator.TypeNumber(3);
            _calculator.PressKey(CalculatorKey.Subtract);
            _calculator.TypeNumber(1);
            _calculator.PressKey(CalculatorKey.Multiply);
            _calculator.TypeNumber(4);
            _calculator.PressKey(CalculatorKey.Divide);
            _calculator.TypeNumber(8);
            _calculator.PressKey(CalculatorKey.Equal);

            _calculator.Display.Should().Be(2);
        }

        [Test]
        public void Display_partial_results_for_multi_step_operation()
        {
            _calculator.TypeNumber(3);
            _calculator.PressKey(CalculatorKey.Add);
            _calculator.TypeNumber(4);
            _calculator.PressKey(CalculatorKey.Subtract);

            _calculator.Display.Should().Be(7);
        }

        [Test]
        public void Refresh_result()
        {
            _calculator.TypeNumber(1);
            _calculator.PressKey(CalculatorKey.Equal);
            _calculator.TypeNumber(2);
            _calculator.PressKey(CalculatorKey.Equal);

            _calculator.Display.Should().Be(2);
        }

        private double PerformOperation(double leftOperand, CalculatorKey operation, double rightOperand)
        {
            _calculator.TypeNumber(leftOperand);
            _calculator.PressKey(operation);
            _calculator.TypeNumber(rightOperand);
            _calculator.PressKey(CalculatorKey.Equal);

            return _calculator.Display;
        }
    }
}