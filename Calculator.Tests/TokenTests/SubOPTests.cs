using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class SubOPTests
    {
        [Theory]
        [InlineData(10,4,6)]
        [InlineData(1, 7,-6)]
        public void SubOP_Eval_ReturnsDouble(double a, double b, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(a));
            testStack.Push(new Num(b));
            testStack.Push(new SubOP());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void AddOP_ToString_ReturnString()
        {
            //Arrange
            SubOP Test = new SubOP();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("-");
        }
    }
}
