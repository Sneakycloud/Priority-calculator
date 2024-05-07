using Calculator.Tokens;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class PermutationOPTests
    { 
        //Tests normal adding
        [Theory]
        [InlineData(5, 3, 60)]
        [InlineData(6, 2, 30)]
        [InlineData(10, 5, 30240)]
        public void PermutationOP_Eval_ReturnDouble(double n, double k, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(n));
            testStack.Push(new Num(k));
            testStack.Push(new PermutationOP());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void PermutationOP_Eval_ThrowsExceptionWhenItemsPickedMoreThanAvalible()
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(3));
            testStack.Push(new Num(5));
            testStack.Push(new PermutationOP());

            Assert.Throws<Exception>(() => testStack.Pop().eval(testStack));
        }

        [Fact]
        public void PermutationOP_ToString_ReturnString()
        {
            PermutationOP Test = new PermutationOP();
            string result = Test.ToString();
            result.Should().Be("P");
        }
    }
}
