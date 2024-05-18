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
        public void ExpOP_ToString_ReturnsString()
        {
            //Arrange
            ExpOP Test = new ExpOP();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("^");
        }

        [Theory]
        [InlineData(-1,1.4)]
        [InlineData(-5,2.4)]
        public void ExpOP_Eval_ReturnsException(double baseNum, double exponent)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(baseNum));
            testStack.Push(new Num(exponent));
            testStack.Push(new ExpOP());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<Exception>();
        }
    }
}
