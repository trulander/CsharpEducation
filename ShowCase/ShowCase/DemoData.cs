using ShowCase.Controllers;
using ShowCase.Models;

namespace ShowCase
{
    public class DemoData
    {
        public DemoData(ModelController modelController, DataBase dataBase)
        {
            modelController.Create(new Shop<Case<Product<int>>>(4));
            modelController.Create(dataBase.Shops[0], new Case<Product<int>>(3));
            modelController.Create(dataBase.Shops[0].Storage[0], new Product<int>(2));
            modelController.Create(dataBase.Shops[0].Storage[0], new Product<int>(2));
            
            modelController.Create(dataBase.Shops[0], new Case<Product<int>>(2));
            modelController.Create(dataBase.Shops[0].Storage[1], new Product<int>(2));
            modelController.Create(dataBase.Shops[0].Storage[1], new Product<int>(2));     
            
            modelController.Create(dataBase.Shops[0], new Case<Product<int>>(2));
            modelController.Create(dataBase.Shops[0].Storage[2], new Product<int>(2));
            modelController.Create(dataBase.Shops[0].Storage[2], new Product<int>(2));     
            
            modelController.Create(dataBase.Shops[0], new Case<Product<int>>(2));
            modelController.Create(dataBase.Shops[0].Storage[3], new Product<int>(2));
            modelController.Create(dataBase.Shops[0].Storage[3], new Product<int>(2)); 
            
            modelController.Create(new Shop<Case<Product<int>>>(5));
            modelController.Create(dataBase.Shops[1], new Case<Product<int>>(3));
            modelController.Create(dataBase.Shops[1].Storage[0], new Product<int>(2));
            modelController.Create(dataBase.Shops[1].Storage[0], new Product<int>(2));
            
            modelController.Create(dataBase.Shops[1], new Case<Product<int>>(2));
            modelController.Create(dataBase.Shops[1].Storage[1], new Product<int>(2));
            modelController.Create(dataBase.Shops[1].Storage[1], new Product<int>(2));     
            
            modelController.Create(dataBase.Shops[1], new Case<Product<int>>(2));
            modelController.Create(dataBase.Shops[1].Storage[2], new Product<int>(2));
            modelController.Create(dataBase.Shops[1].Storage[2], new Product<int>(2));     
            

        }
    }
}