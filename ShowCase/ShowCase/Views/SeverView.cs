using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using ShowCase.Interfases;
using ShowCase.Models;

namespace ShowCase.Views
{
    public class SeverView : ViewAbstract, IView
    {
        private Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>> map = new Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>>();


        public SeverView()
        {
            Buffer = "123";

            

            SavePixel(0,0,'a',ConsoleColor.Red);
            SavePixel(0,1,'a',ConsoleColor.Blue);
            SavePixel(0,2,'a',ConsoleColor.Green);

            // var enumerable = GetPixel(0, 0).Key;
            ShowPixel(0, 0);
            ShowPixel(1, 0);
            ShowPixel(2, 0);
            ShowPixel(0, 1);
            ShowPixel(0, 2);
            Console.ReadKey();
        }
        private void ShowPixel(int x, int y)
        {
            Console.ForegroundColor = GetPixel(x, y).Value;
            Console.Write(GetPixel(x, y).Key);

        }
        private void SavePixel(int x, int y, char symbol, ConsoleColor color)
        {
            if (!map.ContainsKey(x))
            {
                map.Add(x, new Dictionary<int, Dictionary<char, ConsoleColor>>());
            }
            if (!map[x].ContainsKey(y))
            {
                map[x].Add(y, new Dictionary<char, ConsoleColor>());
            }
            if (!map[x][y].ContainsKey(symbol))
            {
                map[x][y].Add(symbol, color);
            }
            else
            {
                map[x][y][symbol] = color;
            }
        }

        private KeyValuePair<char, ConsoleColor> GetPixel(int x, int y)
        {
            if (map.ContainsKey(x))
            {
                if (map[x].ContainsKey(y))
                {
                    return map[x][y].ToImmutableDictionary().Single();
                }
                
            }

            return new KeyValuePair<char, ConsoleColor>(' ',ConsoleColor.White);

        }
        public override void Clear()
        {
            Buffer = "";
        }

        public override string ReadLine()
        {
            lastMethodRequired = "ReadLine";
            if (ConsoleText == "")
            {
                waitHandle[0].Reset();
                waitHandle[1].Set();
                waitHandle[0].WaitOne();
                lastMethodRequired = "ReadKey";
            }
            var result = ConsoleText;
            ConsoleText = "";
            return result;
        }

        public override int ReadKey()
        {
            lastMethodRequired = "ReadKey";
            if (ConsoleKey == 0)
            {
                waitHandle[0].Reset();
                waitHandle[1].Set();
                waitHandle[0].WaitOne();
                lastMethodRequired = "ReadKey";
            }
            var result = ConsoleKey;
            ConsoleKey = 0;
            return result;
        }

        protected override void SaveCurrentCursor()
        {
            _savedCursorX = _curentCursorX;
            _savedCursorY = _curentCursorY;
        }



        protected override void SaveCurrentCursorX()
        {
            _savedCursorX = _curentCursorX;
        }

        protected override void SetCursorX(int x)
        {
            _curentCursorX = x;
        }

        protected override void SetCursorY(int y)
        {
            _curentCursorY = y;
        }    
        protected override int GetCurrentCursorY()
        {
            return _curentCursorY;
        }
        protected override int GetCurrentCursorX()
        {
            return _curentCursorX;
        }
        
        /* custom method printline width color*/
        public override int PrintLine(string value, ConsoleColor color = ConsoleColor.White)
        {
            Print(value, color);
            _curentCursorY++;
            return value.Length;
        }

        /* custom method print width color */
        public override int Print(string value, ConsoleColor color = ConsoleColor.White)
        {
            foreach (var symbol in value)
            {
                SavePixel(_curentCursorX,_curentCursorY,symbol, color);
                _curentCursorX++;
            }
            return value.Length;
        }
    }
}