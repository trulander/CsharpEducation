using System;
using System.Collections.Generic;
using System.Threading;
using ShowCase.Models;

namespace ShowCase.Interfases
{
    public interface IView
    {
        public void ShowMap();
        public string lastMethodRequired{ get; set; }
        public EventWaitHandle[] waitHandle { get; set; }
        public int? ConsoleKey { get; set; }
        public int? ConsoleKeyModifiers { get; set; }
        public string? ConsoleText { get; set; }
        public string Buffer { get; }
        public void Clear();
        public string ReadLine();
        /// <summary>
        /// modified method as Console.ReadKey
        /// </summary>
        /// <returns>int[0] = code key, int[1] = code key modifiers</returns>
        public int[] ReadKey();

        public void MapGenerate(int[] pointerItems, Dictionary<int, string> menu);
        public void GenerateShop(Shop<Case<Product<int>>> obj, int currentShop);
        public void GenerateCase(Case<Product<int>> obj, int currentShop);
        public void GenerateMenu(Dictionary<int, string> menu);
        public void CountPointerForMenu();
        public int PrintLine(string value, ConsoleColor color = ConsoleColor.White);
        public int Print(string value, ConsoleColor color = ConsoleColor.White);
        public void Instruction();

        public void NotifiedMessage(string message);


    }
}