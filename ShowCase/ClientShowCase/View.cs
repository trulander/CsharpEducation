using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ClientShowCase
{
    public class View
    {
        public View()
        {
            Console.TreatControlCAsInput = true;
        }

        /// <summary>
        /// Generating layout from client data
        /// </summary>
        /// <param name="map">char map</param>
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
        /// <summary>
        /// write one symbol in console
        /// </summary>
        /// <param name="x">coordinate x</param>
        /// <param name="y">coordinate y</param>
        /// <param name="map">char map</param>
        private void ShowPixel(int x, int y, Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>> map)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = GetPixel(x, y, map).Value;
            Console.Write(GetPixel(x, y, map).Key);

        }

        /// <summary>
        /// For getting associative KeyValuePair <char, color>
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="map">char map</param>
        /// <returns>KeyValuePair <char, color></returns>
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
        public string ReadLine()
        {
            Console.CursorVisible = true;
            Console.TreatControlCAsInput = false;
            var result = Console.ReadLine();
            Console.CursorVisible = false;
            Console.TreatControlCAsInput = true;
            return result;

        }

        public int[] ReadKey()
        {
            var key = Console.ReadKey(true);
            return new[]
            {
                (int) key.Key,
                (int) key.Modifiers
            };
        }
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
    }
}