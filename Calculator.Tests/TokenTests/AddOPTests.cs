using Calculator.Tokens;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class AddOPTests
    {
        //Tests normal adding
        [Theory]
        [InlineData(2,4,6)]
        [InlineData(8,-4,4)]
        public void AddOP_Eval_ReturnDouble(double a, double b, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(a));
            testStack.Push(new Num(b));
            testStack.Push(new AddOP());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void AddOP_ToString_ReturnString()
        {
            //Arrange
            AddOP Test = new AddOP();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("+");
        }
    }
}
