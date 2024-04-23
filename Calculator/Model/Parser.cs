using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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



            //Define a pattern of operators

            string pattern = @"([\+\-\*\/\(\)\^\%])";



            //split the inputExpression string using the pattern
            string[] input = Regex.Split(inputExpression, pattern);


            // enqueue the tokens into the parsedResult queue, skip empty strings
            foreach (string token in input)
            {
                if(!string.IsNullOrWhiteSpace(token))
                {
                    parsedResult.Enqueue(token);
                }
            }


            // return the parsedResult string queue
            return parsedResult;
        }
    }
}
