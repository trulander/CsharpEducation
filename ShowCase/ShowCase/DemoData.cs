using ShowCase.Controllers;
using ShowCase.Models;

namespace ShowCase
{
    public class DemoData
    {
        public DemoData(ModelController modelController, DataBase dataBase)
        {
            //modelController.Create(4);
            dataBase.Shops.Add(new Shop<Case<Product<int>>>(4));
            //modelController.Create(dataBase.Shops[0], 3);
            dataBase.Shops[0].Create(new Case<Product<int>>(3));
            dataBase.Shops[0].Storage[0].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[0].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[0].Storage[0].Name = "test";
            dataBase.Shops[0].Storage[0].Storage[1].Name = "test";  
            
            //modelController.Create(dataBase.Shops[0], 2);
            dataBase.Shops[0].Create(new Case<Product<int>>(2));
            dataBase.Shops[0].Storage[1].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[1].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[1].Storage[0].Name = "test";
            dataBase.Shops[0].Storage[1].Storage[1].Name = "test";
            
            //modelController.Create(dataBase.Shops[0], 2);
            dataBase.Shops[0].Create(new Case<Product<int>>(2));
            dataBase.Shops[0].Storage[2].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[2].Create(new Product<int>(0)); 
            dataBase.Shops[0].Storage[2].Storage[0].Name = "test";
            dataBase.Shops[0].Storage[2].Storage[1].Name = "test";
            
            //modelController.Create(dataBase.Shops[0], 2);
            dataBase.Shops[0].Create(new Case<Product<int>>(2));
            dataBase.Shops[0].Storage[3].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[3].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[3].Storage[0].Name = "test";
            dataBase.Shops[0].Storage[3].Storage[1].Name = "test";
            
            //modelController.Create(5);
            dataBase.Shops.Add(new Shop<Case<Product<int>>>(5));
            //modelController.Create(dataBase.Shops[1], 3);
            dataBase.Shops[1].Create(new Case<Product<int>>(3));
            dataBase.Shops[1].Storage[0].Create(new Product<int>(0));
            dataBase.Shops[1].Storage[0].Create(new Product<int>(0));
            dataBase.Shops[1].Storage[0].Storage[0].Name = "test";
            dataBase.Shops[1].Storage[0].Storage[1].Name = "test";
            
            //modelController.Create(dataBase.Shops[1], 2);
            dataBase.Shops[1].Create(new Case<Product<int>>(2));
            
            //modelController.Create(5);
            dataBase.Shops.Add(new Shop<Case<Product<int>>>(5));
 
        }
    }
}