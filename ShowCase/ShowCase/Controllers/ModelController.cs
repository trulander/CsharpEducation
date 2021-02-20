﻿using System;
using ShowCase.Interfases;
using ShowCase.Models;
using ShowCase.Views;

namespace ShowCase.Controllers
{
    public class ModelController
    {
        private DataBase _dataBase;

        public ModelController(DataBase dataBase)
        {
            _dataBase = dataBase;
        }
        
        /*create shop*/
        public void Create (int size = 5)
        {
            Shop<Case<Product<int>>> shop = new Shop<Case<Product<int>>>(size);
            EditSize(shop);
            Rename(shop);
            _dataBase.shops.Add(shop);
        }
        
        /*create case*/
        public void Create (Shop<Case<Product<int>>> shop, int size = 3)
        {
            Case<Product<int>> case_ = new Case<Product<int>>(size);
            EditSize(case_);
            Rename(case_);
            shop.Create(case_);
        }
        /*create product*/
        public void Create (Case<Product<int>> case_)
        {
            Product<int> product = new Product<int>(0);
            Rename(product);
            case_.Create(product);
        }        
        /*Edit size shop*/
        public void EditSize(Shop<Case<Product<int>>> shop)
        {
            View.PrintLine("Please write new size (number)");
            bool complete;
            int size;
            string error;
            do
            {
                complete = int.TryParse(Console.ReadLine(), out size);
                if (complete)
                {
                    complete = shop.ChangeSize(size, out error);
                    View.PrintLine(error);
                }
                else
                {
                    View.PrintLine("Please write new size (number)");
                }
            } while (!complete);
        }
        /*Edit size case*/
        public void EditSize(Case<Product<int>> case_)
        {
            View.PrintLine("Please write new size (number)");
            bool complete = false;
            int size = 0;
            string error;
            do
            {
                complete = int.TryParse(Console.ReadLine(), out size);
                if (complete)
                {
                    complete = case_.ChangeSize(size, out error);
                    View.PrintLine(error);
                }
                else
                {
                    View.PrintLine("Please write new size (number)");
                }
            } while (!complete);
        }
        /*Rename product*/
        public void Rename(Product<int> product)
        {
            View.PrintLine("Please write new name");
            bool complete;
            string error;
            do
            {
                complete = product.ReName(Console.ReadLine(),out error);
                View.PrintLine(error);
            } while (!complete);
        }
        /*Rename case*/
        public void Rename(Case<Product<int>> case_)
        {
            View.PrintLine("Please write new name");
            bool complete;
            string error;
            do
            {
                complete = case_.ReName(Console.ReadLine(),out error);
                View.PrintLine(error);
            } while (!complete);
        }
        /*Rename shop*/
        public void Rename(Shop<Case<Product<int>>> shop)
        {
            View.PrintLine("Please write new name");
            bool complete;
            string error;
            do
            {
                complete = shop.ReName(Console.ReadLine(),out error);
                View.PrintLine(error);
            } while (!complete);
        }

        /*Remove shop*/
        public void Remove(Shop<Case<Product<int>>> shop)
        {
            _dataBase.shops.Remove(shop);
        }
        /*Remove case*/
        public void Remove(Shop<Case<Product<int>>> shop, Case<Product<int>> case_)
        {
            shop.Remove(case_);
        }
        /*Remove product*/
        public void Remove(Case<Product<int>> case_, Product<int> product)
        {
            case_.Remove(product);
        }        
    }
}