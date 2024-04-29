using Calculator.Model;
using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class DivOPTests
    {
        [Theory]
        [InlineData(10,5,2)]
        [InlineData(18,6,3)]
        public void DivOP_Eval_ReturnsDouble(double a, double b, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(a));
            testStack.Push(new Num(b));
            testStack.Push(new DivOP());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void DivOP_Eval_ReturnsDivideByZeroException()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(5));
            testStack.Push(new Num(0));
            testStack.Push(new DivOP());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<DivideByZeroException>();
        }

        [Fact]
        public void DivOP_ToString_ReturnsStringDivisor()
        {
            //Arrange
            DivOP Test = new DivOP();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("/");
        }
    }
}
