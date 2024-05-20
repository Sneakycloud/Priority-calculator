using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class ArcCosFunc : Token
    {
        public ArcCosFunc() : base(0, true, true) { }

        public override double eval(Stack<Token> inputStack)
        {
            //Invalid expression
            if (inputStack.Count == 0) { throw new InvalidOperationException("ArcCos lacks operand"); }

            double value = inputStack.Pop().eval(inputStack);

            return Math.Acos(value);
        }

        public override string ToString()
        {
            return "ArcCos";
        }
    }
}
