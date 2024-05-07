using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class MinTests
    {
        [Theory]
        [InlineData(3, 5, 3)]
        [InlineData(-3, -5, -5)]
        [InlineData(-3, 5, -3)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 5, 0)]
        [InlineData(-4, 1, -4)]
        [InlineData(double.PositiveInfinity, 5, 5)]
        [InlineData(double.NegativeInfinity, 5, double.NegativeInfinity)]

        public void MinFunc_Eval_ReturnsCorrectValue(double a, double b, double expected)
        {
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(a));
            testStack.Push(new Num(b));
            testStack.Push(new MinFunc());

            double result = testStack.Pop().eval(testStack);

            result.Should().Be(expected);
        }

        [Fact]
        public void MinFunc_ToString_ReturnString()
        {
            MinFunc maxFunc = new MinFunc();

            string result = maxFunc.ToString();

            result.Should().Be("Min");

        }
    }
}
