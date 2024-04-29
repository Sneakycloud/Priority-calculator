using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class MultOPTests
    {
        [Theory]
        [InlineData(7, 2, 14)]
        [InlineData(-1, 7, -7)]
        public void MultOP_Eval_ReturnsDouble(double a, double b, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(a));
            testStack.Push(new Num(b));
            testStack.Push(new MultOP());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void MultOP_ToString_ReturnsString()
        {
            //Arrange
            MultOP Test = new MultOP();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("*");
        }
    }
}
