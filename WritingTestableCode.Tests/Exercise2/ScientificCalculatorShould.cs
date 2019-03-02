using FluentAssertions;
using NUnit.Framework;
using WritingTestableCode.Exercise2;

namespace WritingTestableCode.Tests.Exercise2
{
    [TestFixture]
    public class ScientificCalculatorShould
    {
        [Test]
        public void Add_two_numbers()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(new Number(2));
            calculator.Input(new Operator((a, b) => a + b));
            calculator.Input(new Number(3));
            calculator.Input(new Operator((a, b) => b));

            calculator.Display.Should().Be(5);
        }

        [Test]
        public void Subtract_two_numbers()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(new Number(5));
            calculator.Input(new Operator((a, b) => a - b));
            calculator.Input(new Number(3));
            calculator.Input(new Operator((a, b) => b));

            calculator.Display.Should().Be(2);
        }

        [Test]
        public void Multiply_two_numbers()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(new Number(2));
            calculator.Input(new Operator((a, b) => a * b));
            calculator.Input(new Number(3));
            calculator.Input(new Operator((a, b) => b));

            calculator.Display.Should().Be(6);
        }

        [Test]
        public void Divide_two_numbers()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(new Number(6));
            calculator.Input(new Operator((a, b) => a / b));
            calculator.Input(new Number(3));
            calculator.Input(new Operator((a, b) => b));

            calculator.Display.Should().Be(2);
        }

        [Test]
        public void Use_the_result_from_a_previous_operation_in_a_subsequent_operation()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(new Number(2));
            calculator.Input(new Operator((a, b) => a + b));
            calculator.Input(new Number(3));
            calculator.Input(new Operator((a, b) => a - b));
            calculator.Input(new Number(1));
            calculator.Input(new Operator((a, b) => a * b));
            calculator.Input(new Number(4));
            calculator.Input(new Operator((a, b) => a / b));
            calculator.Input(new Number(8));
            calculator.Input(new Operator((a, b) => b));

            calculator.Display.Should().Be(2);
        }

        [Test]
        public void Display_partial_results_for_multi_step_operation()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(new Number(3));
            calculator.Input(new Operator((a, b) => a + b));
            calculator.Input(new Number(4));
            calculator.Input(new Operator((a, b) => a - b));

            calculator.Display.Should().Be(7);
        }

        [Test]
        public void Refresh_result()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(new Number(1));
            calculator.Input(new Operator((a, b) => b));
            calculator.Input(new Number(2));
            calculator.Input(new Operator((a, b) => b));

            calculator.Display.Should().Be(2);
        }

        [Test]
        public void Have_a_memory()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(new Number(10));
            calculator.Input(new Operator((a, b) => a + b));
            calculator.Input(new Number(5));
            calculator.Input(new MemoryFunction("Add"));
            calculator.Clear();
            calculator.Input(new Number(12));
            calculator.Input(new MemoryFunction("Subtract"));
            calculator.Clear();
            calculator.Input(new Number(3));
            calculator.Input(new Operator((a, b) => a + b));
            calculator.Input(new MemoryFunction("Recall"));

            calculator.Display.Should().Be(6);
        }
    }
}