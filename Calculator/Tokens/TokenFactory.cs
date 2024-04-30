using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public abstract class TokenFactory
    {

        // takes a string and returns the correct token subclass
        public static Token createToken(string stringPart)
        {
            if (double.TryParse(stringPart, out var doubleValue))
            {
                return new Num(doubleValue);
            }
            else if (stringPart == "+")
            {
                return new AddOP();
            }
            else if (stringPart == "-")
            {
                return new SubOP();
            }
            else if (stringPart == "*")
            {
                return new MultOP();
            }
            else if (stringPart == "/")
            {
                return new DivOP();
            }
            else if (stringPart == "%")
            {
                return new ModuloOP();
            }
            else if (stringPart == "^")
            {
                return new ExpOP();
            }
            else if (stringPart == "!")
            {
                return new FactorialOP();
            }
            else if (stringPart == "(")
            {
                return new LeftParentheses();
            }
            else if (stringPart == ")")
            {
                return new RightParentheses();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
