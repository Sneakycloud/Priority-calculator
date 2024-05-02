using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class FactorialOP : Token
    {
        public FactorialOP() : base(3, true, false) { }

        public override double eval(Stack<Token> inputStack)
        {
            //Invalid expression
            if (inputStack.Count == 0) { throw new InvalidOperationException(); }

            double value = inputStack.Pop().eval(inputStack);
            return Factorial.Process(value);
        }

        public override string ToString()
        {
            return "!";
        }
    }
}
