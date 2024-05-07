using Calculator.Tokens;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class MaxFuncTests
    {

        [Theory]
        [InlineData(3, 5, 5)]
        [InlineData(-3, -5, -3)]
        [InlineData(-3, 5, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 5, 5)]
        [InlineData(3, 3, 3)]
        [InlineData(double.PositiveInfinity, 5, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, 5, 5)]

        public void MaxFunc_Eval_ReturnsCorrectValue(double a, double b, double expected)
        {
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(a));
            testStack.Push(new Num(b));
            testStack.Push(new MaxFunc());

            double result = testStack.Pop().eval(testStack);

            result.Should().Be(expected);
        }

        [Fact]
        public void MaxFunc_ToString_ReturnString()
        {
            MaxFunc maxFunc = new MaxFunc();

            string result = maxFunc.ToString();

            result.Should().Be("Max");

        }

    }
}
