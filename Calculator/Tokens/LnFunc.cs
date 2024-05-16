using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class LnFunc : Token
    {
        public LnFunc() : base(0, true, true) { }

        public override double eval(Stack<Token> inputStack)
        {
            //Invalid expression
            if (inputStack.Count == 0) { throw new InvalidOperationException("Ln lacks an operand"); }

            double value = inputStack.Pop().eval(inputStack);

            if (value <= 0) { throw new InvalidOperationException($"Ln is undefined for negative values such as {value}"); }

            return Math.Log(value);
        }
        public override string ToString()
        {
            return "Ln";
        }
    }
}
