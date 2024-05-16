using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class CosFunc : Token
    {
        public CosFunc() : base(0, true, true) { }

        public override double eval(Stack<Token> inputStack)
        {
            //Invalid expression
            if (inputStack.Count == 0) { throw new InvalidOperationException("Cos lacks operand"); }

            double value = inputStack.Pop().eval(inputStack);

            return Math.Cos(value);
        }

        public override string ToString()
        {
            return "Cos";
        }
    }
}
