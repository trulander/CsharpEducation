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
        
        public void Create (Shop<Case<Product<int>>> shop)
        {
            //Console.WriteLine("shop");
            _dataBase.Shops.Add(shop);
            
        }
        
        public void Create (Shop<Case<Product<int>>> shop, Case<Product<int>> case_)
        {
            //Console.WriteLine("case");
            int pointToShop = _dataBase.Shops.IndexOf(shop);
            _dataBase.Shops[pointToShop].Create(case_);

        }
        
        public void Create (Case<Product<int>> case_, Product<int> product)
        {
           // Console.WriteLine("product");
            case_.Create(product);
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