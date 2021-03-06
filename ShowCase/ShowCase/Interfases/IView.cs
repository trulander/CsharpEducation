using System;
using System.Collections.Generic;
using ShowCase.Models;
using ShowCase.Views;

namespace ShowCase.Interfases
{
    public interface IView
    {
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