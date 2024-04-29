using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class FactorialTests
    {
        //Tests normal adding
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(4, 24)] //4! = 4*3*2*1 = 12*2 = 24
        [InlineData(5, 120)]
        [InlineData(6, 720)]
        public void Factorial_Eval_ReturnDouble(double a, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(a));
            testStack.Push(new FactorialOP());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Factorial_Eval_ReturnInvalidOperation()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new FactorialOP());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Factorial_ToString_ReturnString()
        {
            //Arrange
            FactorialOP Test = new FactorialOP();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("!");
        }
    }
}
