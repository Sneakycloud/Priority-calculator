using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Tokens;

namespace Calculator.Model
{
    public class TokenQueueConverter
    {
        // get a string queue from Parser and convert it into a token queue called tokenQueue
        //take each string bit from the parsed result and send it to tokenFactory and get it back and put it in a queue.

        public static Queue<Token> createTokenQueue(Queue<string> inputQueue)
        {
            //create a queue variable
            Queue<Token> tokenQueue = new Queue<Token>();


            // while the inputQueue is not empty
            while (inputQueue.Count > 0)
            {
                // dequeue the elements from inputQueue, then send it to tokenFactory and make it a token, then enqueue the token in tokenQueue.
                tokenQueue.Enqueue(TokenFactory.createToken(inputQueue.Dequeue()));
            }

            return tokenQueue;
        }
    }
}
