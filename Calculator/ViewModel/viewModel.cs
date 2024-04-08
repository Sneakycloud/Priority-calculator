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

        //Uses input expression as input and changes output expression, works as a relay
        public void calculator()
        {
            OutputExpression = $"{evaluateExpression(InputExpression)}";
        }

        private double evaluateExpression(string input)
        {
            // split the input expression into token elements and put it in a string queue
            Queue<string> parsedResult = Parser.ParseExpression(input);

            // convert string queue to token queue.
            Queue<Token> tokenQueue = TokenQueueConverter.createTokenQueue(parsedResult);

            // Converts the expression from infix to RPN
            Stack<Token> RPNstack = ShuntingYard.ToRPN(tokenQueue);

            // Starts a pop on th RPNstack which results in a chain reaction that returns the correct double value of the input
            double result = RPNstack.Pop().eval(RPNstack);

            //Check if the expression was completely evaluated
            if (RPNstack.Count == 1 ) { throw new Exception(); }

            return result;
        }

    }
}
