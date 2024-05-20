using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

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
            else if (stringPart == "(")
            {
                return new LeftParentheses();
            }
            else if (stringPart == ")")
            {
                return new RightParentheses();
            }
            else if (stringPart == "!")
            {
                return new FactorialOP();
            }
            else if (stringPart == "π") //Pi
            {
                return new Pi();
            }
            else if (stringPart == "e")
            {
                return new e();
            }
            else if (stringPart == "npr")
            {
                return new PermutationOP();
            }
            else if (stringPart == "ncr")
            {
                return new CombinationsOP();
            }
            else if (stringPart == "sin")
            {
                return new SinFunc();
            }
            else if (stringPart == "cos")
            {
                return new CosFunc();
            }
            else if (stringPart == "tan")
            {
                return new TanFunc();
            }
            else if (stringPart == "arcsin")
            {
                return new ArcSinFunc();
            }
            else if (stringPart == "arccos")
            {
                return new ArcCosFunc();
            }
            else if (stringPart == "arctan")
            {
                return new ArcTanFunc();
            }
            else if(stringPart == "max")
            {
                return new MaxFunc();
            }
            else if(stringPart == "min")
            {
                return new MinFunc();
            }
            else if (stringPart == "log")
            {
                return new LogFunc();
            }
            else if (stringPart == "ln")
            {
                return new LnFunc();
            }
            else if (stringPart == "√")
            {
                return new SqrtFunc();
            }
            else
            {
                throw new Exception($"Invalid input");
            }
        }
    }
}
