using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class ArcSinTests
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(1,Math.PI/2)]
        [InlineData(-1,-Math.PI*0.5)]
        public void ArcSinFunc_Eval_ReturnsDouble(double input, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new ArcSinFunc());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);

        }

        [Fact]
        public void ArcSinFunc_ToString_ReturnsString()
        {
            //Arrange
            ArcSinFunc Test = new ArcSinFunc();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("ArcSin");

        }

        [Fact]
        public void ArcSinFunc_Eval_ReturnsException()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new ArcSinFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }

    }
}
