using FluentAssertions;
using NUnit.Framework;
using WritingTestableCode.Exercise1;

namespace WritingTestableCode.Tests.Exercise1
{
    [TestFixture]
    public class CalculatorShould
    {
        [Test]
        public void Add_two_numbers()
        {
            var calculator = new Calculator();

            calculator.TypeNumber(1);
            calculator.PressKey(CalculatorKey.Add);
            calculator.TypeNumber(2);
            calculator.PressKey(CalculatorKey.Equal);

            calculator.Display.Should().Be(3);
        }

        [Test]
        public void Subtract_two_numbers()
        {
            var calculator = new Calculator();

            calculator.TypeNumber(5);
            calculator.PressKey(CalculatorKey.Subtract);
            calculator.TypeNumber(2);
            calculator.PressKey(CalculatorKey.Equal);

            calculator.Display.Should().Be(3);
        }

        [Test]
        public void Multiply_two_numbers()
        {
            var calculator = new Calculator();

            calculator.TypeNumber(3);
            calculator.PressKey(CalculatorKey.Multiply);
            calculator.TypeNumber(2);
            calculator.PressKey(CalculatorKey.Equal);

            calculator.Display.Should().Be(6);
        }

        [Test]
        public void Divide_two_numbers()
        {
            var calculator = new Calculator();

            calculator.TypeNumber(6);
            calculator.PressKey(CalculatorKey.Divide);
            calculator.TypeNumber(2);
            calculator.PressKey(CalculatorKey.Equal);

            calculator.Display.Should().Be(3);
        }

        [Test]
        public void Use_the_result_from_a_previous_operation_in_a_subsequent_operation()
        {
            var calculator = new Calculator();

            calculator.TypeNumber(2);
            calculator.PressKey(CalculatorKey.Add);
            calculator.TypeNumber(3);
            calculator.PressKey(CalculatorKey.Subtract);
            calculator.TypeNumber(1);
            calculator.PressKey(CalculatorKey.Multiply);
            calculator.TypeNumber(4);
            calculator.PressKey(CalculatorKey.Divide);
            calculator.TypeNumber(8);
            calculator.PressKey(CalculatorKey.Equal);

            calculator.Display.Should().Be(2);
        }

        [Test]
        public void Display_partial_results_for_multi_step_operation()
        {
            var calculator = new Calculator();

            calculator.TypeNumber(3);
            calculator.PressKey(CalculatorKey.Add);
            calculator.TypeNumber(4);
            calculator.PressKey(CalculatorKey.Subtract);

            calculator.Display.Should().Be(7);
        }

        [Test]
        public void Refresh_result()
        {
            var calculator = new Calculator();

            calculator.TypeNumber(1);
            calculator.PressKey(CalculatorKey.Equal);
            calculator.TypeNumber(2);
            calculator.PressKey(CalculatorKey.Equal);

            calculator.Display.Should().Be(2);
        }
    }
}