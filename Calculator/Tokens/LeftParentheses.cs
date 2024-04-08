using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class LeftParentheses : Token
    {
        public LeftParentheses() : base(3, true) { }

        //This is only called if something has gone wrong
        public override double eval(Stack<Token> inputStack)
        {
            throw new Exception();
        }
        public override string ToString()
        {
            return "(";
        }
    }
}
