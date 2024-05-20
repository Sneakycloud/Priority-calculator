using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Calculator.Tokens;

namespace Calculator.Model
{
    public abstract class Parser
    {
        // create a static method that takes a string "inputExpression" from viewModel and converts it to a string queue.
        // Example:
        // Input: ”2+10”
        // Parser.parse(”2+10”) = [”2”,”+”,”10”] = parsedResult    



        public static Queue<string> ParseExpression(string inputExpression)
        {            
            
            // parsedResult is the queue that will store the split string
            Queue<string> parsedResult = new Queue<string>();



            //Define a pattern of operators
            string infixOperators = @"|([\+\-\*\/\^\%])|(ncr)|(npr)";
            string singleOperators = @"|([\!√])"; //only use one side as input
            string constants = @"|([πe])";
            string paranthasis = @"|([\(\)])";
            string trigFunctionPattern = @"|(sin)|(cos)|(tan)|(arcsin)|(arccos)|(arctan)";
            string functionPattern = @"|(max)|(min)|(log)|(ln)";
            string pattern = infixOperators.Remove(0,1) + singleOperators + constants + paranthasis + trigFunctionPattern + functionPattern + @"|\s+";



            //split the inputExpression string using the pattern
            string[] input = Regex.Split(inputExpression.Replace(","," , ").ToLower(), pattern);

            //Cleans whitespace and empty
            List<string> cleanedInput = new List<string>();
            foreach (string inputItem in input)
            {
                if(!string.IsNullOrWhiteSpace(inputItem))
                {
                    cleanedInput.Add(inputItem);
                }
            }

            //Automatically multiplies constants and numbers when adjecent to a function
            //i.e 3Max() = 3*Max() or 3π = 3*π
            Queue<string> multiplied_input = new Queue<string>();
            for(int i = 0; i < cleanedInput.Count() - 1; i++)
            {
                //Tests if the current string is a number or is a constant
                bool current_string = (double.TryParse(cleanedInput[i], out _) | Regex.IsMatch(cleanedInput[i], constants.Remove(0,1)));
                //Tests if the next string is a number, constant or a function
                bool next_string = (double.TryParse(cleanedInput[i + 1], out _) | Regex.IsMatch(cleanedInput[i + 1], constants.Remove(0,1) + trigFunctionPattern + functionPattern));
                //If both are true then assume there is an implicit multiplication
                if (current_string && next_string)
                {
                    multiplied_input.Enqueue(cleanedInput[i]);
                    multiplied_input.Enqueue("*");
                }
                else
                {
                    multiplied_input.Enqueue(cleanedInput[i]);
                }

            }
            //Adds the last item
            multiplied_input.Enqueue(cleanedInput[cleanedInput.Count()-1]);

            //Remove ,
            List<string> cleaned_commas = new List<string>();
            foreach(string item in multiplied_input)
            {
                if(item != ",")
                {
                    cleaned_commas.Add(item);
                }
            }

            //Test if the first two strings form a negative number like -5 +2
            if(cleaned_commas.Count >= 2 && cleaned_commas[0] == "-" && double.TryParse(cleaned_commas[1], out _))
            {
                string new_index0 = $"-{cleaned_commas[1]}";
                cleaned_commas.RemoveRange(0, 2);
                cleaned_commas.Insert(0, new_index0);
            }

            //Allows for negative numbers to inputed. Like 2+-1 or 2*-(π)
            bool addLast = false;
            for (int i = 1;i < cleaned_commas.Count() - 1; i++)
            {
                addLast = false;
                //Check if it should be stored as a negative
                if (cleaned_commas[i] == "-" && Regex.IsMatch(cleaned_commas[i-1],infixOperators.Remove(0,1) + singleOperators))
                {
                    //Based on paranthasis solve the problem
                    if (double.TryParse(cleaned_commas[i+1], out _))
                    {
                        parsedResult.Enqueue($"-{cleaned_commas[i + 1]}");
                        addLast = true;
                        i++;
                    }
                    else if (cleaned_commas[i+1] == "(" || Regex.IsMatch(cleaned_commas[i + 1], constants.Remove(0, 1)))
                    {
                        parsedResult.Enqueue("-1");
                        parsedResult.Enqueue("*");
                    }
                    else
                    {
                        throw new Exception("Invalid subtraction");
                    }

                }
                else
                {
                    if (i == 1) parsedResult.Enqueue(cleaned_commas[0]);
                    parsedResult.Enqueue(cleaned_commas[i]);
                }
            }

            if (!addLast) parsedResult.Enqueue(cleaned_commas[cleaned_commas.Count()-1]);

            // return the parsedResult string queue
            return parsedResult;
        }
    }
}
