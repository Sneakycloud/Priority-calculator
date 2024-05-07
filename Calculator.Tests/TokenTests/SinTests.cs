using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class SinTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(Math.PI / 2,1)]
        [InlineData(-Math.PI * 0.5, -1)]
        public void SinFunc_Eval_ReturnsDouble(double input, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new SinFunc());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);

        }

        [Fact]
        public void SinFunc_ToString_ReturnsString()
        {
            //Arrange
            SinFunc Test = new SinFunc();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("Sin");

        }

        [Fact]
        public void SinFunc_Eval_ReturnsException()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new SinFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }
    }
}
