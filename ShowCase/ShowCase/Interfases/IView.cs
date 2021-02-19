using System;
using System.Collections.Generic;
using ShowCase.Models;
using ShowCase.Views;

namespace ShowCase.Interfases
{
    public interface IView
    {
        public void MapGenerate(DataBase dataBase, int[] pointerItems, Dictionary<int, string> menu);
        public void GenerateShop(Shop<Case<Product<int>>> obj, int currentShop);
        public void GenerateCase(Case<Product<int>> obj, int currentShop);
        public void GenerateProduct(Product<int> obj, ConsoleColor color);
        public void GenerateMenu(Dictionary<int, string> menu);
        public void CountPointerForMenu();
    }
}