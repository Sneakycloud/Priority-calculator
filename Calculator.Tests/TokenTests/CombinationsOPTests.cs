using Calculator.Tokens;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.TokenTests
{
    public class CombinationsOPTests
    {
        [Theory]
        [InlineData(3, 2, 3)]
        [InlineData(5, 2, 10)]

        public void CombinationsOP_Eval_ReturnDouble(double n, double k, double expected)
        {
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(n));
            testStack.Push(new Num(k));
            testStack.Push(new Num(expected));

            double result = testStack.Pop().eval(testStack);

            result.Should().Be(expected);
        }

        [Fact]
        public void CombinationsOP_Eval_ThrowsException_WhenPickingMoreThanAvailable()
        {
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(2));
            testStack.Push(new Num(3));
            testStack.Push(new CombinationsOP());

            Assert.Throws<Exception>(() => testStack.Pop().eval(testStack));

        }

        [Fact]
        public void CombinationsOP_Eval_ThrowsException_WhenTotalItemsAreNegative()
        {
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(-2));
            testStack.Push(new Num(3));
            testStack.Push(new CombinationsOP());

            Assert.Throws<Exception>(() => testStack.Pop().eval(testStack));

        }

        [Fact]
        public void CombinationsOP_Eval_ThrowsException_WhenItemsBeingPickedAreNegative()
        {
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(2));
            testStack.Push(new Num(-3));
            testStack.Push(new CombinationsOP());

            Assert.Throws<Exception>(() => testStack.Pop().eval(testStack));

        }

        [Fact]
        public void CombinationsOP_Eval_Returns1_WhenPicking0OutOfN()
        {
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(5));
            testStack.Push(new Num(0));
            testStack.Push(new CombinationsOP());

            double result = testStack.Pop().eval(testStack);

            result.Should().Be(1);
        }

        [Fact]
        public void CombinationsOP_Eval_Returns1_WhenPickingAllItemsOutOfN()
        {
            Stack<Token> testStack = new Stack<Token>();
            testStack.Push(new Num(5));
            testStack.Push(new Num(5));
            testStack.Push(new CombinationsOP());

            double result = testStack.Pop().eval(testStack);

            result.Should().Be(1);
        }

        [Fact]
        public void CombinationsOP_ToString_ReturnString()
        {
            
            CombinationsOP Test = new CombinationsOP();

            string result = Test.ToString();

            result.Should().Be("C");
        }

    }
}
