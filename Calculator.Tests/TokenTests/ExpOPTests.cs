using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class ExpOPTests
    {
        [Theory]
        [InlineData(2, 3, 8)]
        [InlineData(-1, 2, 1)]
        public void ExpOP_Eval_ReturnsDouble(double a, double b, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(a));
            testStack.Push(new Num(b));
            testStack.Push(new ExpOP());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ExpOP_ToString_ReturnsStringDivisor()
        {
            //Arrange
            ExpOP Test = new ExpOP();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("^");
        }
    }
}
