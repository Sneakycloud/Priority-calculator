﻿using Calculator.Model;
using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.ModelTests
{
    public class ShuntingYardTests
    {
        [Fact]
        public void shuntingYard_ToRPN_returnsTokenStack()
        {
            //Arrange
            //Tests:  3 + 4 × 2 ÷ ( 1 − 5 ) ^ 2 ^ 3
            Queue<Token> tokenQueue = new Queue<Token>();
            tokenQueue.Enqueue(new Num(3));
            tokenQueue.Enqueue(new AddOP());
            tokenQueue.Enqueue(new Num(4));
            tokenQueue.Enqueue(new MultOP());
            tokenQueue.Enqueue(new Num(2));
            tokenQueue.Enqueue(new DivOP());
            tokenQueue.Enqueue(new LeftParentheses());
            tokenQueue.Enqueue(new Num(1));
            tokenQueue.Enqueue(new SubOP());
            tokenQueue.Enqueue(new Num(5));
            tokenQueue.Enqueue(new RightParentheses());
            tokenQueue.Enqueue(new ExpOP());
            tokenQueue.Enqueue(new Num(2));
            tokenQueue.Enqueue(new ExpOP());
            tokenQueue.Enqueue(new Num(3));

            //same as queue but for assertion of stack
            Stack<Token> expectedStack = new Stack<Token>();
            expectedStack.Push(new Num(3));
            expectedStack.Push(new Num(4));
            expectedStack.Push(new Num(2));
            expectedStack.Push(new MultOP());
            expectedStack.Push(new Num(1));
            expectedStack.Push(new Num(5));
            expectedStack.Push(new SubOP());
            expectedStack.Push(new Num(2));
            expectedStack.Push(new Num(3));
            expectedStack.Push(new ExpOP());
            expectedStack.Push(new ExpOP());
            expectedStack.Push(new DivOP());
            expectedStack.Push(new AddOP());


            //Act
            Stack<Token> RPNstack = ShuntingYard.ToRPN(tokenQueue);

            //Assert
            RPNstack.Should().Equal(expectedStack);

        }
    }
}
