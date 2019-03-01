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
            _calculator.TypeNumber(1);
            _calculator.PressKey(CalculatorKey.Add);
            _calculator.TypeNumber(2);
            _calculator.PressKey(CalculatorKey.Equal);

            _calculator.Display.Should().Be(3);
        }

        [Test]
        public void Subtract_two_numbers()
        {
            _calculator.TypeNumber(5);
            _calculator.PressKey(CalculatorKey.Subtract);
            _calculator.TypeNumber(2);
            _calculator.PressKey(CalculatorKey.Equal);

            _calculator.Display.Should().Be(3);
        }

        [Test]
        public void Multiply_two_numbers()
        {
            _calculator.TypeNumber(3);
            _calculator.PressKey(CalculatorKey.Multiply);
            _calculator.TypeNumber(2);
            _calculator.PressKey(CalculatorKey.Equal);

            _calculator.Display.Should().Be(6);
        }

        [Test]
        public void Divide_two_numbers()
        {
            _calculator.TypeNumber(6);
            _calculator.PressKey(CalculatorKey.Divide);
            _calculator.TypeNumber(2);
            _calculator.PressKey(CalculatorKey.Equal);

            _calculator.Display.Should().Be(3);
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
    }
}