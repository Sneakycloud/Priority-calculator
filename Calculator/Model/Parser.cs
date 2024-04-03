using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public abstract class Parser
    {
        // create a static method that takes a string "inputExpression" from viewModel and converts it to a string queue.
        // Example:
        // Input: ”2+10”
        // Parser.parse(”2+10”) = [”2”,”+”,”10”] = parsedResult         //where parsedResult is the string queue


        public static Queue<string> ParseExpression(string inputExpression)
        {            
            
            // parsedResult is the queue that will store the split string
            Queue<string> parsedResult = new Queue<string>();


            // split the inputExpression string into individual tokens (words) and add them to the input string.
            string[] input = inputExpression.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            // enqueue the tokens into the parsedResult queue
            foreach (string token in input)
            {
                parsedResult.Enqueue(token);
            }


            // return the parsedResult string queue
            return parsedResult;
        }
    }
}
