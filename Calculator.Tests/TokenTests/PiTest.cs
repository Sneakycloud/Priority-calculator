using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class PiTests
    {
        [Fact]
        public void Pi_test()
        {
            //Arrange
            var piToken = new Pi();
            var inputStack = new Stack<Token>();


            //Act
            var result = piToken.eval(inputStack);

            //Assert
            Assert.Equal(System.Math.PI, result);
        }

        [Fact]
        public void PermutationOP_ToString_ReturnString()
        {
            Pi Test = new Pi();
            string result = Test.ToString();
            result.Should().Be("π");
        }

    }
}
