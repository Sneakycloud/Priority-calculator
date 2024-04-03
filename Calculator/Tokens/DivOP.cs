using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class DivOP : Token
    {
        // the constructor DivOP with priority order 1
        public DivOP() : base(1) { }

        public override double eval(Stack<Token> inputStack)
        {
            // pop the first and second tokens from the inputStack and evaluate them recursively
            double eval1 = inputStack.Pop().eval(inputStack);
            double eval2 = inputStack.Pop().eval(inputStack);

            // return the quota of the two evaluated tokens
            return eval1 / eval2;
        }


        // override to return a string representation of the div token
        public override string ToString()
        {
            return "/";
        }
    }
}
