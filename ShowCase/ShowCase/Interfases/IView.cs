using System.Collections.Generic;
using ShowCase.Models;

namespace ShowCase.Interfases
{
    public interface IView
    {
        public int[] GetCursorInCase();
        public int[] GetCursorInShop();
        public int[] GetCursorInRoot();
        public void MapGenerate();
        public void GenerateShop(Shop<Case<Product<int>>> obj);
        public void GenerateCase(Case<Product<int>> obj);
        public void GenerateProduct(Product<int> obj);
        public void GenerateMenu();
    }
}