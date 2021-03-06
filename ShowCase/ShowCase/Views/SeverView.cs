using System;
using System.Collections.Generic;
using System.Threading;
using ShowCase.Interfases;
using ShowCase.Models;

namespace ShowCase.Views
{
    public class SeverView : IView
    {
        public string lastMethodRequired { get; set; }
        public EventWaitHandle[] waitHandle { get; set; }
        public int ConsoleKey { get; set; }
        public string ConsoleText { get; set; }

        public string Buffer { get; }

        public void MapGenerate(int[] pointerItems, Dictionary<int, string> menu)
        {
            throw new NotImplementedException();
        }

        public void GenerateShop(Shop<Case<Product<int>>> obj, int currentShop)
        {
            throw new NotImplementedException();
        }

        public void GenerateCase(Case<Product<int>> obj, int currentShop)
        {
            throw new NotImplementedException();
        }

        public void GenerateMenu(Dictionary<int, string> menu)
        {
            throw new NotImplementedException();
        }

        public void CountPointerForMenu()
        {
            throw new NotImplementedException();
        }

        public int PrintLine(string value, ConsoleColor color = ConsoleColor.White)
        {
            throw new NotImplementedException();
        }

        public int Print(string value, ConsoleColor color = ConsoleColor.White)
        {
            throw new NotImplementedException();
        }

        public void Instruction()
        {
            throw new NotImplementedException();
        }
    }
}