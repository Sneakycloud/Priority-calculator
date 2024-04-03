using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class DivOP : Token
    {
        public DivOP() : base(1) { }

        public override double eval(Stack<Token> inputStack)
        {
            double eval1 = inputStack.Pop().eval(inputStack);
            double eval2 = inputStack.Pop().eval(inputStack);
            return eval1 / eval2;
        }

        public override string ToString()
        {
            return "/";
        }
    }
}
