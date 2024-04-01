using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public abstract class ShuntingYard
    {
        public static Stack<Token> ToRPN(Queue<Token> tokenQueue)
        {
            Stack<Token> operatorStack = new Stack<Token>();
            Stack<Token> RPNstack = new Stack<Token>();
        
            while (tokenQueue.Count > 0)
            {
                if (tokenQueue.Peek().priority == -1) //then this is a number
                {
                    RPNstack.Push(tokenQueue.Dequeue());
                }
                else if (operatorStack.Count == 0) //if operator stack is empty, then put the operator in
                {
                    operatorStack.Push(tokenQueue.Dequeue());
                }
                else if (tokenQueue.Peek().ToString() == "(") //handles left parenthasis
                {
                    operatorStack.Push(tokenQueue.Dequeue());
                }
                else if (tokenQueue.Peek().ToString() == ")") //handles right parenthasis
                {
                    //Pops operators until the "(" is found
                    while(operatorStack.Count > 0 && operatorStack.Peek().ToString() != "(")
                    {
                        RPNstack.Push(operatorStack.Pop());
                    }
                    operatorStack.Pop(); //Gets rid of the "("

                    //Check if the expression was invalid
                    if (operatorStack.Count == 0)
                    {
                        throw new Exception();
                    } 
                }
                else //Handles operators
                {
                    while (operatorStack.Count > 0 && (operatorStack.Peek().priority >= tokenQueue.Peek().priority && operatorStack.Peek().ToString() != "("))
                    {
                        RPNstack.Push(operatorStack.Pop());
                    }
                    operatorStack.Push(tokenQueue.Dequeue());
                }


            }

            //Since tokenQueue is empty then add the remaining tokens in the operatorStack to the RPNstack
            while (operatorStack.Count > 0)
            {
                RPNstack.Push(operatorStack.Pop());
            }

            return RPNstack;
        }
    }
}
