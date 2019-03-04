using FluentAssertions;
using NUnit.Framework;
using WritingTestableCode.Exercise2;
using static WritingTestableCode.Exercise2.Inputs;

namespace WritingTestableCode.Tests.Exercise2
{
    [TestFixture]
    public class ScientificCalculatorShould
    {
        [Test]
        public void Add_two_numbers()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(Number(2));
            calculator.Input(Add());
            calculator.Input(Number(3));
            calculator.Input(Inputs.Equals());

            calculator.Display.Should().Be(5);
        }

        [Test]
        public void Subtract_two_numbers()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(Number(5));
            calculator.Input(Subtract());
            calculator.Input(Number(3));
            calculator.Input(Inputs.Equals());

            calculator.Display.Should().Be(2);
        }

        [Test]
        public void Multiply_two_numbers()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(Number(2));
            calculator.Input(Multiply());
            calculator.Input(Number(3));
            calculator.Input(Inputs.Equals());

            calculator.Display.Should().Be(6);
        }

        [Test]
        public void Divide_two_numbers()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(Number(6));
            calculator.Input(Divide());
            calculator.Input(Number(3));
            calculator.Input(Inputs.Equals());

            calculator.Display.Should().Be(2);
        }

        [Test]
        public void Use_the_result_from_a_previous_operation_in_a_subsequent_operation()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(Number(2));
            calculator.Input(Add());
            calculator.Input(Number(3));
            calculator.Input(Subtract());
            calculator.Input(Number(1));
            calculator.Input(Multiply());
            calculator.Input(Number(4));
            calculator.Input(Divide());
            calculator.Input(Number(8));
            calculator.Input(Inputs.Equals());

            calculator.Display.Should().Be(2);
        }

        [Test]
        public void Display_partial_results_for_multi_step_operation()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(Number(3));
            calculator.Input(Add());
            calculator.Input(Number(4));
            calculator.Input(Subtract());

            calculator.Display.Should().Be(7);
        }

        [Test]
        public void Refresh_result()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(Number(1));
            calculator.Input(Inputs.Equals());
            calculator.Input(Number(2));
            calculator.Input(Inputs.Equals());

            calculator.Display.Should().Be(2);
        }

        [Test]
        public void Have_a_memory()
        {
            var calculator = new ScientificCalculator();

            calculator.Input(Number(10));
            calculator.Input(Add());
            calculator.Input(Number(5));
            calculator.Input(AddToMemory());
            calculator.Clear();
            calculator.Input(Number(12));
            calculator.Input(SubtractFromMemory());
            calculator.Clear();
            calculator.Input(Number(3));
            calculator.Input(Add());
            calculator.Input(FetchFromMemory());

            calculator.Display.Should().Be(6);
        }
    }
}