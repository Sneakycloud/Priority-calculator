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
        //Made using the shunting yard algoritm, https://en.wikipedia.org/wiki/Shunting_yard_algorithm
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
                else if (tokenQueue.Peek().isFunction == true)
                {
                    operatorStack.Push(tokenQueue.Dequeue());
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

                    //Check if the expression was invalid
                    if (operatorStack.Count == 0)
                    {
                        throw new InvalidOperationException("Missing left paranthasis (") ;
                    }

                    operatorStack.Pop(); //Gets rid of the "("
                    tokenQueue.Dequeue();

                    //Pops a function if it is on the top of the operator stack
                    if(operatorStack.Count > 0 && operatorStack.Peek().isFunction == true)
                    {
                        RPNstack.Push(operatorStack.Pop());
                    }

                    
                }
                else //Handles operators
                {
                    /*
                     there is an operator o2 at the top of the operator stack which is not a left parenthesis, 
                     and (o2 has greater precedence than o1 or (o1 and o2 have the same precedence and o1 is left-associative))
                    https://en.wikipedia.org/wiki/Shunting_yard_algorithm
                     */
                    while (operatorStack.Count > 0 && operatorStack.Peek().ToString() != "(" && (operatorStack.Peek().priority > tokenQueue.Peek().priority || (operatorStack.Peek().priority == tokenQueue.Peek().priority && tokenQueue.Peek().leftAssosiative) ))
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
