using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class LnTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(Math.E, 1)]
        [InlineData(Math.E*Math.E, 2)]
        public void LnFunc_Eval_ReturnsDouble(double input, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new LnFunc());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);

        }

        [Fact]
        public void LnFunc_ToString_ReturnsString()
        {
            //Arrange
            LnFunc Test = new LnFunc();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("Ln");

        }

        [Fact]
        public void LnFunc_Eval_ReturnsInvalidException_whenEmpty()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new LnFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void LnFunc_Eval_ReturnsException(double input)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new LnFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }
    }
}
