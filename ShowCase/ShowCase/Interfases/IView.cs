using System.Collections.Generic;
using ShowCase.Models;

namespace ShowCase.Interfases
{
    public interface IView
    {
        public void MapGenerate(DataBase dataBase);
        public void GenerateShop(Shop<Case<Product<int>>> obj);
        public void GenerateCase(Case<Product<int>> obj);
        public void GenerateProduct(Product<int> obj);
        public void GenerateMenu();
    }
}