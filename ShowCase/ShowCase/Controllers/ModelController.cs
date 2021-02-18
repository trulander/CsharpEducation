using System;
using ShowCase.Interfases;
using ShowCase.Models;

namespace ShowCase.Controllers
{
    public class ModelController
    {
        private DataBase _dataBase;

        public ModelController(DataBase dataBase)
        {
            _dataBase = dataBase;
        }
        
        public void Create (Case<Product<int>> obj)
        {
            Console.WriteLine("case");
        }
        public void Create (Shop<Case<Product<int>>> obj)
        {
            Console.WriteLine("shop");
            _dataBase.Shops.Add(obj);
            
        }

        public void Create (Product<int> obj)
        {
            Console.WriteLine("product");
        }        
        public void Edit<T>(T instance)
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T instance)
        {
            throw new System.NotImplementedException();
        }
    }
}