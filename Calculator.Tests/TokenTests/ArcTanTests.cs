using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{

    public class ArcTanTests
    {
        const double sqrt3 = 1.73205081;
        const int digits = 8;

        //tests if the values are within 8 decimals of each other
        [Theory]
        [InlineData(1, Math.PI/4)]
        [InlineData(1/sqrt3, Math.PI / 6)]
        public void ArcTanFunc_Eval_ReturnsDouble(double input, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new ArcTanFunc());

            //Act
            double result = Math.Floor((testStack.Pop().eval(testStack) * Math.Pow(10, digits))) / Math.Pow(10, digits);

            //Assert
            result.Should().Be(Math.Floor(expected * Math.Pow(10, digits))/ Math.Pow(10, digits));

        }

        [Fact]
        public void ArcTanFunc_ToString_ReturnsString()
        {
            //Arrange
            ArcTanFunc Test = new ArcTanFunc();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("ArcTan");

        }

        [Fact]
        public void ArcTanFunc_Eval_ReturnsException()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new ArcTanFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        public void ArcTanFunc_Eval_ReturnsInvalidOperationException(double input)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(input));
            testStack.Push(new ArcTanFunc());

            //Act
            Action test = () => { testStack.Pop().eval(testStack); };

            //Assert
            test.Should().Throw<InvalidOperationException>();
        }

    }
}
