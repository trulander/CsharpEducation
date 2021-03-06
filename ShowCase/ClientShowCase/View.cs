using System;

namespace ClientShowCase
{
    public class View
    {
        public void Write(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public void WriteLine(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Write(text, color);
            Console.WriteLine();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}