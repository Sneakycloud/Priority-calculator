using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.ModelTests
{
    public class FactorialTest
    {
        [Theory]
        [InlineData(0,1)]
        [InlineData(1,1)]
        [InlineData(4,24)] //4! = 4*3*2*1 = 12*2 = 24
        [InlineData(5,120)]
        [InlineData(6,720)]
        public void FactorialTest_Process_ReturnDouble(double input, double expected)
        {
            //Arrange

            //Act
            double result = Factorial.Process(input);

            //Assert
            result.Should().Be(expected);

        }

    }
}
