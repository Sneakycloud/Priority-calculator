using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    abstract public class Factorial
    {
        //Round to closest number then does the factorial calculation !
        public static double Process(double value)
        {
            int input = (int)Math.Round(value);
            int output = 1;
            
            for (int i = input; 0 < i; i--)
            {
                output *= i;
            }

            return output;
        }
    }
}
