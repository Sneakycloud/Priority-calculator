using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class RightParentheses : Token
    {
        public RightParentheses() : base(10, true) { }

        //This is only called if something has gone wrong, i.e the expression is not valid
        public override double eval(Stack<Token> inputStack)
        {
            throw new Exception();
        }
        public override string ToString()
        {
            return ")";
        }
    }
}
