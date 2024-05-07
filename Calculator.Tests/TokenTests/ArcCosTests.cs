using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class ArcCosTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, Math.PI / 2)]
        [InlineData(-1, Math.PI)]
        public void ArcCosFunc_Eval_ReturnsDouble(double input, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new ArcCosFunc());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);

        }

        [Fact]
        public void ArcCosFunc_ToString_ReturnsString()
        {
            //Arrange
            ArcCosFunc Test = new ArcCosFunc();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("ArcCos");

        }

        [Fact]
        public void ArcCosFunc_Eval_ReturnsException()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new ArcCosFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }
    }
}
