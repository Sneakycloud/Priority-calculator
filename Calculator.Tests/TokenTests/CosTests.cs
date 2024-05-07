using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class CosTests
    {
        const int digits = 8;

        [Theory]
        [InlineData(0, 1)]
        [InlineData(Math.PI / 2, 0)]
        [InlineData(Math.PI, -1)]
        public void CosFunc_Eval_ReturnsDouble(double input, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new CosFunc());

            //Act, This nestes function rounds the result to 8 decimals (this is needed due to floating point errors)
            double result = Math.Floor((testStack.Pop().eval(testStack) * Math.Pow(10, digits))) / Math.Pow(10, digits);

            //Assert
            result.Should().Be(Math.Floor(expected * Math.Pow(10, digits)) / Math.Pow(10, digits));

        }

        [Fact]
        public void CosFunc_ToString_ReturnsString()
        {
            //Arrange
            CosFunc Test = new CosFunc();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("Cos");

        }

        [Fact]
        public void CosFunc_Eval_ReturnsException()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new CosFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }
    }
}
