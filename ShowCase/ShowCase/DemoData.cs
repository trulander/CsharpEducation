using System;
using ShowCase.Controllers;
using ShowCase.Models;

namespace ShowCase
{
    public class DemoData
    {
        public DemoData(ModelController modelController, DataBase dataBase)
        {
            //modelController.Create(4);
            dataBase.shops.Add(new Shop<Case<Product<int>>>(4));
            dataBase.shops[0].name = "Shop with tests";
            //modelController.Create(dataBase.shops[0], 3);
            dataBase.shops[0].Create(new Case<Product<int>>(4));
            dataBase.shops[0].storage[0].name = "Case with tests";
            dataBase.shops[0].storage[0].Create(new Product<int>(0));
            dataBase.shops[0].storage[0].Create(new Product<int>(0));
            dataBase.shops[0].storage[0].storage[0].name = "test";
            dataBase.shops[0].storage[0].storage[1].name = "test";  
            
            //modelController.Create(dataBase.shops[0], 2);
            dataBase.shops[0].Create(new Case<Product<int>>(2));
            dataBase.shops[0].storage[1].name = "Case with tests";
            dataBase.shops[0].storage[1].Create(new Product<int>(0));
            dataBase.shops[0].storage[1].Create(new Product<int>(0));
            dataBase.shops[0].storage[1].storage[0].name = "test";
            dataBase.shops[0].storage[1].storage[1].name = "test";
            
            //modelController.Create(dataBase.shops[0], 2);
            dataBase.shops[0].Create(new Case<Product<int>>(2));
            dataBase.shops[0].storage[2].name = "Case with tests";
            dataBase.shops[0].storage[2].Create(new Product<int>(0));
            dataBase.shops[0].storage[2].Create(new Product<int>(0)); 
            dataBase.shops[0].storage[2].storage[0].name = "test";
            dataBase.shops[0].storage[2].storage[1].name = "test";
            
            //modelController.Create(dataBase.shops[0], 2);
            dataBase.shops[0].Create(new Case<Product<int>>(2));
            dataBase.shops[0].storage[3].name = "Case with tests";
            dataBase.shops[0].storage[3].Create(new Product<int>(0));
            dataBase.shops[0].storage[3].Create(new Product<int>(0));
            dataBase.shops[0].storage[3].storage[0].name = "test";
            dataBase.shops[0].storage[3].storage[1].name = "test1";
            
            //modelController.Create(5);
            dataBase.shops.Add(new Shop<Case<Product<int>>>(5));
            dataBase.shops[1].name = "Shop width tests";
            //modelController.Create(dataBase.shops[1], 3);
            dataBase.shops[1].Create(new Case<Product<int>>(3));
            dataBase.shops[1].storage[0].name = "Case with tests";
            dataBase.shops[1].storage[0].Create(new Product<int>(0));
            dataBase.shops[1].storage[0].Create(new Product<int>(0));
            dataBase.shops[1].storage[0].storage[0].name = "test";
            dataBase.shops[1].storage[0].storage[1].name = "test";
            
            //modelController.Create(dataBase.shops[1], 2);
            dataBase.shops[1].Create(new Case<Product<int>>(2));
            dataBase.shops[1].storage[1].name = "Case with tests";
            
            //modelController.Create(5);
            dataBase.shops.Add(new Shop<Case<Product<int>>>(4));
            dataBase.shops[2].name = "Shop without tests";
        }
    }
}