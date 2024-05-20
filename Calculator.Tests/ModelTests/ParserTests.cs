using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.ModelTests
{
    public class ParserTests
    {
        [Fact]

        public void ParserTest_ReturnsExpectedStringQueue()
        {
            //Arrange
            //Tests: 2 (3 * 4) / (15 - 13) + 3^2
            //The test will be run on the inputExp test queue
            string inputExp = "22*(3*4)/(15-13)+3^2";

            //Correctly split queue to compare the inputExp test queue with
            Queue<string> expectedStringQueue = new Queue<string>();
            expectedStringQueue.Enqueue("22");
            expectedStringQueue.Enqueue("*");
            expectedStringQueue.Enqueue("(");
            expectedStringQueue.Enqueue("3");
            expectedStringQueue.Enqueue("*");
            expectedStringQueue.Enqueue("4");
            expectedStringQueue.Enqueue(")");
            expectedStringQueue.Enqueue("/");
            expectedStringQueue.Enqueue("(");
            expectedStringQueue.Enqueue("15");
            expectedStringQueue.Enqueue("-");
            expectedStringQueue.Enqueue("13");
            expectedStringQueue.Enqueue(")");
            expectedStringQueue.Enqueue("+");
            expectedStringQueue.Enqueue("3");
            expectedStringQueue.Enqueue("^");
            expectedStringQueue.Enqueue("2");


            //Act
            Queue<string> result = Parser.ParseExpression(inputExp);


            //Assert
            //Check so that both queues contain the same number of elements
            Assert.Equal(expectedStringQueue.Count, result.Count);


            // check that both queues contain the same elements in the same order.
            while(expectedStringQueue.Count > 0)
            {
                Assert.Equal(expectedStringQueue.Dequeue(), result.Dequeue());
            }

        }


    }
}
