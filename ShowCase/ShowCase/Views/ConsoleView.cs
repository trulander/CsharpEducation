using System;
using ShowCase.Interfases;
using ShowCase.Models;

namespace ShowCase.Views
{
    public class ConsoleView : ViewAbstract, IView
    {
        public ConsoleView()
        {
            Console.CursorVisible = false;/* hide cursor */
        }
        public  void ShowMap()
        {
            throw new NotImplementedException();
        }

        public override void Clear()
        {
            Console.Clear();
        }

        public override string ReadLine()
        {
            Console.CursorVisible = true;
            var result = Console.ReadLine();
            Console.CursorVisible = false;
            return result;

        }

        public override int[] ReadKey()
        {
            Console.TreatControlCAsInput = true;
            var key = Console.ReadKey(true);
            Console.TreatControlCAsInput = false;
            return new[]
            {
                (int) key.Key,
                (int) key.Modifiers
            };
        }

        protected override void SaveCurrentCursor()
        {
            _savedCursorX = Console.CursorLeft;
            _savedCursorY = Console.CursorTop;
        }
        protected override void SaveCurrentCursorX()
        {
            _savedCursorX = Console.CursorLeft;
        }
        protected override void SetCursorX(int x)
        {
            Console.SetCursorPosition(x, Console.CursorTop);
        }
        protected override void SetCursorY(int y)
        {
            Console.SetCursorPosition(Console.CursorLeft, y);
        }    
        protected override int GetCurrentCursorX()
        {
            return Console.CursorLeft;
        }
        protected override int GetCurrentCursorY()
        {
            return Console.CursorTop;
        }
        
        /* custom method printline width color*/
        public override int PrintLine(string value, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(value);
            Console.ResetColor();

            return value.Length;
        }

        /* custom method print width color */
        public override int Print(string value, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;

            Console.Write(value);
            Console.ResetColor();

            return value.Length;
        }

        public void NotifiedMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}