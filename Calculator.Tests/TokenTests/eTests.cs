using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class eTests
    {
        [Fact]
        public void e_test()
        {
            //Arrange
            var eToken = new e();
            var inputStack = new Stack<Token>();

            //Act
            var result = eToken.eval(inputStack);

            //Assert
            Assert.Equal(System.Math.E, result);
        }

        [Fact]
        public void PermutationOP_ToString_ReturnString()
        {
            e Test = new e();
            string result = Test.ToString();
            result.Should().Be("e");
        }

    }
}
