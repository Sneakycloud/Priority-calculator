using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public abstract class Token
    {
        public Token(int inputPriority)
        {
            priority = inputPriority;
        }

        public readonly int priority;
        public abstract double eval(Stack<Token> inputStack);
        public abstract string ToString();
        
        protected static (double,double) getValues(Stack<Token> inputStack)
        {
            (double, double) values;
            if(inputStack.Count == 0)
            {
                values.Item1 = inputStack.Pop().eval(inputStack);
            }
            else
            {
                //Handles an incorrect expression
                throw new Exception();
            }

            if (inputStack.Count == 0)
            {
                values.Item2 = inputStack.Pop().eval(inputStack);
            }
            else
            {
                //Handles an incorrect expression
                throw new Exception();
            }

            return (values.Item1,values.Item2);
        }
        
    }
}
