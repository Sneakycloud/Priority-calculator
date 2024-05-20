using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class SqrtFunc : Token
    {

        public SqrtFunc() : base(0, true, true) { }

        public override double eval(Stack<Token> inputStack)
        {
            if (inputStack.Count == 0) { throw new InvalidOperationException(); }
            
            double value = inputStack.Pop().eval(inputStack);

            if(value < 0) { throw new InvalidOperationException($"Not Real"); }
            
            return Math.Sqrt(value);
        }

        public override string ToString()
        {
            return "√";
        }

    }
}
