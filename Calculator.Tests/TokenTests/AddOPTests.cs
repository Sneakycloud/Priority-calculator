using Calculator.Tokens;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class AddOPTests
    {
        //Tests normal adding
        [Theory]
        [InlineData(2,4,6)]
        [InlineData(8,-4,4)]
        public void AddOP_Eval_ReturnDouble(double a, double b, double expected)
        {
            //Arrange
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(a));
            testStack.Push(new Num(b));
            testStack.Push(new AddOP());

            //Act
            double result = testStack.Pop().eval(testStack);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void AddOP_ToString_ReturnString()
        {
            //Arrange
            AddOP Test = new AddOP();

            //Act
            string result = Test.ToString();

            //Assert
            result.Should().Be("+");
        }




        // Property Test
        // Tests if the Add operation is commutative, 2+3 should be the same as 3+2
        [Theory]
        [InlineData(2, 3)]
        [InlineData(8, 4)]
        public void CheckIf_AddOP_IsCommutative(double x, double y)
        {
            var addOP = new AddOP();    
            var inputStack = new Stack<Token>();

            inputStack.Push(new Num(x));
            inputStack.Push(new Num(y));

            var result_1 = addOP.eval(new Stack<Token>(inputStack));
            var result_2 = addOP.eval(new Stack<Token>(inputStack.Reverse()));

            //the result should be the same when the inputStack is reversed and when it's normal.
            result_1.Should().Be(result_2);
        }

    }
}
