using System;
using ShowCase.Controllers;
using ShowCase.Models;

namespace ShowCase
{
    public class DemoData
    {
        public DemoData()
        {
            var dataBase = DataBase.GetInstance();
            //modelController.Create(4);
            dataBase.Shops.Add(new Shop<Case<Product<int>>>(4));
            dataBase.Shops[0].Name = "Shop with tests";
            //modelController.Create(dataBase.Shops[0], 3);
            dataBase.Shops[0].Create(new Case<Product<int>>(4));
            dataBase.Shops[0].Storage[0].Name = "Case with tests";
            dataBase.Shops[0].Storage[0].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[0].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[0].Storage[0].Name = "test33";
            dataBase.Shops[0].Storage[0].Storage[1].Name = "test346";
            dataBase.Shops[0].Storage[0].Storage[0].Cost = 987;
            dataBase.Shops[0].Storage[0].Storage[1].Cost = 654;
            
            //modelController.Create(dataBase.Shops[0], 2);
            dataBase.Shops[0].Create(new Case<Product<int>>(2));
            dataBase.Shops[0].Storage[1].Name = "Case with tests";
            dataBase.Shops[0].Storage[1].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[1].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[1].Storage[0].Name = "test12221";
            dataBase.Shops[0].Storage[1].Storage[1].Name = "test647g";
            dataBase.Shops[0].Storage[1].Storage[0].Cost = 346;
            dataBase.Shops[0].Storage[1].Storage[1].Cost = 235;
            
            //modelController.Create(dataBase.Shops[0], 2);
            dataBase.Shops[0].Create(new Case<Product<int>>(2));
            dataBase.Shops[0].Storage[2].Name = "Case with tests";
            dataBase.Shops[0].Storage[2].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[2].Create(new Product<int>(0)); 
            dataBase.Shops[0].Storage[2].Storage[0].Name = "test231";
            dataBase.Shops[0].Storage[2].Storage[1].Name = "test097";
            dataBase.Shops[0].Storage[2].Storage[0].Cost = 78457;
            dataBase.Shops[0].Storage[2].Storage[1].Cost = 97456;
            
            //modelController.Create(dataBase.Shops[0], 2);
            dataBase.Shops[0].Create(new Case<Product<int>>(2));
            dataBase.Shops[0].Storage[3].Name = "Case with tests";
            dataBase.Shops[0].Storage[3].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[3].Create(new Product<int>(0));
            dataBase.Shops[0].Storage[3].Storage[0].Name = "test22";
            dataBase.Shops[0].Storage[3].Storage[1].Name = "test15";
            dataBase.Shops[0].Storage[3].Storage[0].Cost = 23476;
            dataBase.Shops[0].Storage[3].Storage[1].Cost = 45757;
            
            //modelController.Create(5);
            dataBase.Shops.Add(new Shop<Case<Product<int>>>(5));
            dataBase.Shops[1].Name = "Shop width tests";
            //modelController.Create(dataBase.Shops[1], 3);
            dataBase.Shops[1].Create(new Case<Product<int>>(3));
            dataBase.Shops[1].Storage[0].Name = "Case with tests";
            dataBase.Shops[1].Storage[0].Create(new Product<int>(0));
            dataBase.Shops[1].Storage[0].Create(new Product<int>(0));
            dataBase.Shops[1].Storage[0].Storage[0].Name = "test5";
            dataBase.Shops[1].Storage[0].Storage[1].Name = "test88";
            dataBase.Shops[1].Storage[0].Storage[0].Cost = 3277;
            dataBase.Shops[1].Storage[0].Storage[1].Cost = 645;
            
            //modelController.Create(dataBase.Shops[1], 2);
            dataBase.Shops[1].Create(new Case<Product<int>>(2));
            dataBase.Shops[1].Storage[1].Name = "Case with tests";
            
            //modelController.Create(5);
            dataBase.Shops.Add(new Shop<Case<Product<int>>>(4));
            dataBase.Shops[2].Name = "Shop without tests";
        }
    }
}