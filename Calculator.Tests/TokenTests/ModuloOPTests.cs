using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class ModuloOPTests
    {
        [Theory]
        [InlineData(4, 3, 1)]
        [InlineData(20, 6, 2)]
        public void ModuloOP_Eval_ReturnsDouble(double a, double b, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(a));
            testStack.Push(new Num(b));
            testStack.Push(new ModuloOP());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ModuloOP_ToString_ReturnsString()
        {
            //Arrange
            ModuloOP Test = new ModuloOP();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("%");
        }
    }
}
