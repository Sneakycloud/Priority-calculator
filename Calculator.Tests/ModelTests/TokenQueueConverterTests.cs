using Calculator.Model;
using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.ModelTests
{
    public class TokenQueueConverterTests
    {

        [Fact]
        public void tokenQueueConverterTest_returnsTokenQueue()
        {
            //Arrange
            //Tests: 2 (3 + 4) / 2
            //the string queue that the test will be run on
            Queue<string> stringQueue = new Queue<string>();
            stringQueue.Enqueue("2");
            stringQueue.Enqueue("(");
            stringQueue.Enqueue("3");
            stringQueue.Enqueue("+");
            stringQueue.Enqueue("4");
            stringQueue.Enqueue(")");
            stringQueue.Enqueue("/");
            stringQueue.Enqueue("2");

            //manually creates a correct token queue to compare with
            Queue<Token> tokenQueue = new Queue<Token>();
            tokenQueue.Enqueue(new Num(2));
            tokenQueue.Enqueue(new LeftParentheses());
            tokenQueue.Enqueue(new Num(3));
            tokenQueue.Enqueue(new AddOP());
            tokenQueue.Enqueue(new Num(4));
            tokenQueue.Enqueue(new RightParentheses());
            tokenQueue.Enqueue(new DivOP());
            tokenQueue.Enqueue(new Num(2));


            //Act
            //call the TokenQueueConverter to perform the convertion
            Queue<Token> convertedQueue = TokenQueueConverter.createTokenQueue(stringQueue);


            //Assert
            //compare the correct token queue with the converted queue
            convertedQueue.Should().Equal(tokenQueue);
        }
    }
}

