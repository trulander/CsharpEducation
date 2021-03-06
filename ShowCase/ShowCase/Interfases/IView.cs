using System;
using System.Collections.Generic;
using System.Threading;
using ShowCase.Models;

namespace ShowCase.Interfases
{
    public interface IView
    {
        public string lastMethodRequired{ get; set; }
        public EventWaitHandle[] waitHandle { get; set; }
        public int ConsoleKey { get; set; }
        public string ConsoleText { get; set; }
        public string Buffer { get; }
        public void MapGenerate(int[] pointerItems, Dictionary<int, string> menu);
        public void GenerateShop(Shop<Case<Product<int>>> obj, int currentShop);
        public void GenerateCase(Case<Product<int>> obj, int currentShop);
        public void GenerateMenu(Dictionary<int, string> menu);
        public void CountPointerForMenu();
        public int PrintLine(string value, ConsoleColor color = ConsoleColor.White);
        public int Print(string value, ConsoleColor color = ConsoleColor.White);
        public void Instruction();
    }
}