#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using ShowCase.Interfases;

namespace ShowCase.Models
{
    public class DataBase : IDataBase
    {
        private static DataBase? _instanceDatabase = null;
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
            AddProduct = 8,
            EditNameShop = 9,
            EditNameCase = 10,
            EditCostProduct = 11
        }

        protected DataBase() { }
        public static DataBase GetInstance()
        {
            if (_instanceDatabase == null)
            {
                _instanceDatabase = new DataBase();
                _instanceDatabase.shops = new List<Shop<Case<Product<int>>>>();
            }
            return _instanceDatabase;
        }
    }
}