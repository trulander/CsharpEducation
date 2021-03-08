using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ShowCase.Interfases;
using ShowCase.Models;

namespace ShowCase.Views
{
    public class ConsoleView : ViewAbstract, IView
    {
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
            return Console.ReadLine();
        }

        public override int[] ReadKey()
        {
            var key = Console.ReadKey(true);
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
    }
}