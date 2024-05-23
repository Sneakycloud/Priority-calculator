using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class LogFunc : Token
    {
        public LogFunc() : base(0, true, true) { }

        public override double eval(Stack<Token> inputStack)
        {
            //Invalid expression
            if (inputStack.Count == 0) { throw new InvalidOperationException("Lacks an operand"); }

            double value = inputStack.Pop().eval(inputStack);

            if (value <= 0) { throw new InvalidOperationException($"Undefined, negative values"); }

            return Math.Log10(value);
        }
        public override string ToString()
        {
            return "Log";
        }
    }
}
