using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class SinFunc : Token
    {
        public SinFunc() : base(0, true, true) { }

        public override double eval(Stack<Token> inputStack)
        {
            //Invalid expression
            if (inputStack.Count == 0) { throw new InvalidOperationException("Lacks operand"); }

            double value = inputStack.Pop().eval(inputStack);

            return Math.Sin(value);
        }

        public override string ToString()
        {
            return "Sin";
        }
    }
}
