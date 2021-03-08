using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

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

        public void GenerateMap(Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>> map)
        {
            foreach (var x in map)
            {
                foreach (var y in x.Value)
                {
                    ShowPixel(x.Key, y.Key, map);
                }
            }
        }

        private void ShowPixel(int x, int y, Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>> map)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = GetPixel(x, y, map).Value;
            Console.Write(GetPixel(x, y, map).Key);

        }

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

        public void Clear()
        {
            Console.Clear();
        }
    }
}