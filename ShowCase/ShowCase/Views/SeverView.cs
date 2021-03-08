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
        
        /// <summary>
        /// temporary method for local test client view 
        /// </summary>
        public void ShowMap()
        {
            foreach (var x in _map)
            {
                foreach (var y in x.Value)
                {
                    ShowPixel(x.Key, y.Key, _map);
                }
            }
        }
        /// <summary>
        /// temporary method for local test client view 
        /// </summary>
        private void ShowPixel(int x, int y, Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>> map)
        {
            Console.SetCursorPosition(x,y);
            Console.ForegroundColor = GetPixel(x, y, map).Value;
            Console.Write(GetPixel(x, y, map).Key);

        }
        /// <summary>
        /// temporary method for local test client view 
        /// </summary>
        private KeyValuePair<char, ConsoleColor> GetPixel(int x, int y, Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>> map)
        {
            if (map.ContainsKey(x))
            {
                if (map[x].ContainsKey(y))
                {
                    return map[x][y].ToImmutableDictionary().First();
                }
            }
            return new KeyValuePair<char, ConsoleColor>(' ', ConsoleColor.White);
        }
        
        
        
        /// <summary>
        /// Save pixel in charmap
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="symbol">symbol for save</param>
        /// <param name="color">color for symbol</param>
        private void SavePixel(int x, int y, char symbol, ConsoleColor color)
        {
            if (!_map.ContainsKey(x))
            {
                _map.Add(x, new Dictionary<int, Dictionary<char, ConsoleColor>>());
            }
            if (!_map[x].ContainsKey(y))
            {
                _map[x].Add(y, new Dictionary<char, ConsoleColor>());
            }
            if (_map[x][y].Count == 0)
            {
                _map[x][y].Add(symbol, color);
            }
            else
            {
                _map[x][y].Clear();
                _map[x][y].Add(symbol, color);
            }
        }
        
        /// <summary>
        /// Clear charmap
        /// </summary>
        public override void Clear()
        {
            _map = new Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>>();
        }

        /// <summary>
        /// method for getting text from client? imitation console.readline
        /// </summary>
        /// <returns>text that got from client</returns>
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
        
        /// <summary>
        /// method for getting key from client? imitation console.readkey
        /// </summary>
        /// <returns>key that got from client</returns>
        public override int[] ReadKey()
        {
            lastMethodRequired = "ReadKey";
            if (ConsoleKey == null)
            {
                waitHandle[0].Reset();
                waitHandle[1].Set();
                waitHandle[0].WaitOne();
                lastMethodRequired = "ReadKey";
            }

            int[] result = new int[]
            {
                ConsoleKey ?? 0,
                ConsoleKeyModifiers ?? 0
            };
                
            ConsoleKey = null;
            return result;
        }

        /// <summary>
        /// Save position virtual cursor to storage
        /// </summary>
        protected override void SaveCurrentCursor()
        {
            _savedCursorX = _curentCursorX;
            _savedCursorY = _curentCursorY;
        }


        /// <summary>
        /// Save position virtual cursor for coordinate x to storage
        /// </summary>
        protected override void SaveCurrentCursorX()
        {
            _savedCursorX = _curentCursorX;
        }

        /// <summary>
        /// set virtual cursor to position for x
        /// </summary>
        /// <param name="x">input coordinate x</param>
        protected override void SetCursorX(int x)
        {
            _curentCursorX = x;
        }

        /// <summary>
        /// set virtual cursor to position for y
        /// </summary>
        /// <param name="y">input coordinate y</param>
        protected override void SetCursorY(int y)
        {
            _curentCursorY = y;
        }    
        
        /// <summary>
        /// Save position virtual cursor for coordinate y to storage
        /// </summary>
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
            _curentCursorX = 0;
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