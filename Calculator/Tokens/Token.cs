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
        
    }
}
