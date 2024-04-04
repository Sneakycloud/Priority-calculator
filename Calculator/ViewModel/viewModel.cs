using Calculator.Model;
using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModel
{
    public class viewModel
    {
        public string InputExpression { get; set; }
        public string OutputExpression { get; set; } = string.Empty;

        //Uses input expression as input and changes output expression
        public void calculator()
        {

            // split the input expression into token elements and put it in a string queue
            Queue<string> parsedResult = Parser.ParseExpression(InputExpression);

            // convert string queue to token queue.
            Queue<Token> tokenQueue = TokenQueueConverter.createTokenQueue(parsedResult);

            //Test for shuntingYard
            /*
            Queue<Token> tokenQueue = new Queue<Token>();
            tokenQueue.Enqueue(new Num(10));
            tokenQueue.Enqueue(new SubOP());
            tokenQueue.Enqueue(new Num(2));
            tokenQueue.Enqueue(new MultOP());
            tokenQueue.Enqueue(new Num(3));

            Stack<Token> RPNstack = ShuntingYard.ToRPN(tokenQueue);
            Console.WriteLine("The value was " + RPNstack.Pop().eval(RPNstack));
            */

        }

    }
}
