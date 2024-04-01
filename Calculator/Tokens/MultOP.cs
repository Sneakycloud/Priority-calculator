using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class MultOP : Token
    {
        public MultOP() : base(1) { }

        public override double eval(Stack<Token> inputStack)
        {
            double eval1 = inputStack.Pop().eval(inputStack);
            double eval2 = inputStack.Pop().eval(inputStack);
            return eval2 * eval1;
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
