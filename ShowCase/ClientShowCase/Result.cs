using System;
using System.Collections.Generic;

namespace ClientShowCase
{
    public class Result
    {
        public string action { get; }
        public Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>> text { get; }
        public Result(string actionInput, Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>> textInput)
        {
            action = actionInput;
            text = textInput;
        } 
    }
}