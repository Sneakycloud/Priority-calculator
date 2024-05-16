using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class LogTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(10, 1)]
        [InlineData(100, 2)]
        [InlineData(1000000000000, 12)]
        public void LogFunc_Eval_ReturnsDouble(double input, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new LogFunc());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);

        }

        [Fact]
        public void LogFunc_ToString_ReturnsString()
        {
            //Arrange
            LogFunc Test = new LogFunc();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("Log");

        }

        [Fact]
        public void LogFunc_Eval_ReturnsExceptionInvalidException_WhenEmpty()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new LogFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void LogFunc_Eval_ReturnsException(double input)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new LogFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }
    }
}
