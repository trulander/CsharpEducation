using System;
using System.Collections.Generic;
using ShowCase.Interfases;
using ShowCase.Models;

namespace ShowCase.Views
{
    public class View : IView
    {
        public void MapGenerate()
        {
            Console.WriteLine("----------");
            Console.WriteLine("0000000000");
            Console.WriteLine("----------");
            
        }

        public void GenerateShop(Shop<Case<Product<int>>> obj)
        {
            Console.WriteLine("(-------------------------------------------)");
            Console.WriteLine("(-------------------------------------------)");
            Console.WriteLine("(-------------------------------------------)");
        }

        public void GenerateCase(Case<Product<int>> obj)
        {
            Console.WriteLine("(----------)");
            Console.WriteLine("(----------)");
            Console.WriteLine("(----------)");
        }

        public void GenerateProduct(Product<int> obj)
        {
            Console.Write("*");
        }

        public void GenerateMenu()
        {
            Console.WriteLine("-Product list-");
            Console.WriteLine("Name product - *");
            Console.WriteLine("Name product2 - $");
        }

        public int[] GetCursorInCase()
        {
            throw new NotImplementedException();
        }

        public int[] GetCursorInShop()
        {
            throw new NotImplementedException();
        }

        public int[] GetCursorInRoot()
        {
            throw new NotImplementedException();
        }


    }
}