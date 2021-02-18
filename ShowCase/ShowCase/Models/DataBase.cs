using System;
using System.Collections;
using System.Collections.Generic;
using ShowCase.Interfases;

namespace ShowCase.Models
{
    public class DataBase : IDataBase
    {
        public List<Shop<Case<Product<int>>>> Shops { get; set; }
        // public ArrayList[][] Root { get; set; }

        public DataBase()
        {

            Shops = new List<Shop<Case<Product<int>>>>();
            
            // Root = new[] {new[] {new ArrayList()}};
            // _shop[0].Add(new Case(1));
            // _shop[0].Add(new Case(1));
            Console.WriteLine(Shops);
        }

        
    }
}