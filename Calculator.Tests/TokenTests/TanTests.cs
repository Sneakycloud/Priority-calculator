using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class TanTests
    {
        const double sqrt3 = 1.73205081;
        const int digits = 8; //higest value without test failing, caused by floating point errors (and not exact sqrt(3) value)

        //tests if the values are within 8 decimals of each other
        [Theory]
        [InlineData(Math.PI / 4, 1)]
        [InlineData(Math.PI / 6, 1 / sqrt3)]
        public void TanFunc_Eval_ReturnsDouble(double input, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new TanFunc());

            //Act
            double result = Math.Round(testStack.Pop().eval(testStack), digits );

            //Assert
            result.Should().Be(Math.Round(expected, digits));

        }

        [Fact]
        public void TanFunc_ToString_ReturnsString()
        {
            //Arrange
            TanFunc Test = new TanFunc();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("Tan");

        }

        [Fact]
        public void TanFunc_Eval_ReturnsInvalidOperationException()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new TanFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void TanFunc_Eval_ReturnsException()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(Math.PI/2));
            testStack.Push(new TanFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<Exception>();
        }
    }
}
