using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public abstract class Token
    {
        public Token(int inputPriority, bool assosiative, bool isFunctionInput)
        {
            priority = inputPriority;
            leftAssosiative = assosiative;
            isFunction = isFunctionInput;
        }

        public readonly int priority;
        public readonly bool leftAssosiative;
        public readonly bool isFunction;
        //Returns the value contained or the calculates it's value based on the operator.
        public abstract double eval(Stack<Token> inputStack);
        public abstract override string ToString();
        
        protected static (double,double) getValues(Stack<Token> inputStack)
        {
            (double, double) values;
            if(inputStack.Count > 0)
            {
                values.Item1 = inputStack.Pop().eval(inputStack);
            }
            else
            {
                //Handles an incorrect expression
                throw new Exception();
            }

            if (inputStack.Count > 0)
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

        //Used by unit tests to see if different tokens are equal
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;
            return true;
        }

    }
}
