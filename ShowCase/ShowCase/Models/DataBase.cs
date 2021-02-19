using System;
using System.Collections;
using System.Collections.Generic;
using ShowCase.Interfases;

namespace ShowCase.Models
{
    public class DataBase : IDataBase
    {
        public List<Shop<Case<Product<int>>>> shops { get; set; }
        //public ArrayList[][] Root { get; set; }

        /*binding button*/
        public enum KeyData
        {
            UP = ConsoleKey.UpArrow,
            DOWN = ConsoleKey.DownArrow,
            RIGHT = ConsoleKey.RightArrow,
            LEFT = ConsoleKey.LeftArrow,
            APPLY = ConsoleKey.Enter,
            EXIT = ConsoleKey.Escape,
            ENTERMODIFIER = ConsoleModifiers.Control
            
        }
        public enum Actions
        {
            EditSizeShop = 0,
            EditSizeCase = 1,
            EditNameProduct = 2,
            RemoveShop = 3,
            RemoveCase = 4,
            RemoveProduct = 5,
            AddShop = 6,
            AddCase = 7,
            AddProduct = 8
        }
        public DataBase()
        {
            shops = new List<Shop<Case<Product<int>>>>();
        }
    }
}