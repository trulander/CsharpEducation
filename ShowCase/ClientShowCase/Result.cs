namespace ClientShowCase
{
    public class Result
    {
        public string action { get; }
        public string text { get; }
        public Result(string actionInput,string textInput)
        {
            action = actionInput;
            text = textInput;
        } 
    }
}