using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class SqrtTests
    {

        [Fact]
        public void SqrtFunc_ReturnsString()
        {
            //Arrange
            SqrtFunc Test = new SqrtFunc();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("√");
        }




        [Fact]
        public void SqrtFunc_ReturnsInvalidException_whenEmpty()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new SqrtFunc());

            //Act
            Action test = () => testStack.Pop().eval(testStack);

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }




        [Theory]
        [InlineData(9, 3)]
        [InlineData(40000, 200)]
        [InlineData(0, 0)]
        public void SqrtFunc_ReturnsDouble(double input, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new SqrtFunc());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);
        }




        [Theory]
        [InlineData(-1)]
        [InlineData(-25)]
        public void SqrtFunc_ReturnsException(double input)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new SqrtFunc());

            //Act
            Action test = () => testStack.Pop().eval(testStack);

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }
    }
}
