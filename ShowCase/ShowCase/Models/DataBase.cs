using System;
using System.Collections;
using System.Collections.Generic;
using ShowCase.Interfases;

namespace ShowCase.Models
{
    public class DataBase : IDataBase
    {
        public List<Shop<Case<Product<int>>>> Shops { get; set; }
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
        public DataBase()
        {
            Shops = new List<Shop<Case<Product<int>>>>();
        }
    }
}