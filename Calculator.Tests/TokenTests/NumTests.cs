using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class NumTests
    {
        [Theory]
        [InlineData(2,2)]
        [InlineData(1,1)]
        public void Num_Eval_ReturnsDouble(double a, double expected)
        {
            //Arrange
            Num Test = new Num(a);

            //Act
            double result = Test.eval(new Stack<Token>());

            //Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(2,2)]
        [InlineData(1,1)]
        public void MultOP_ToString_ReturnsStringDivisor(double a,double expected)
        {
            //Arrange
            Num Test = new Num(a);

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be(expected.ToString());
        }
    }
}
