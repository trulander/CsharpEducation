using System;
using System.Collections.Generic;
using ShowCase.Interfases;
using ShowCase.Models;

namespace ShowCase.Views
{
    public class View : IView
    {
        private int _coordinateCursorX = 0;
        private int _coordinateCursorY = 0;

        private void SaveCursor()
        {
            _coordinateCursorX = Console.CursorLeft;
            _coordinateCursorY = Console.CursorTop;
        }
        private void SaveCursorX()
        {
            _coordinateCursorX = Console.CursorLeft;
        }
        private void SaveCursorY()
        {
            _coordinateCursorY = Console.CursorTop;
        }        

        private void SetCursorX()
        {
            Console.SetCursorPosition(_coordinateCursorX, Console.CursorTop);
        }
        private void SetCursorY()
        {
            Console.SetCursorPosition(Console.CursorLeft, _coordinateCursorY);
        }        
        private void SetCursor()
        {
            Console.SetCursorPosition(_coordinateCursorX, _coordinateCursorY);
        }        

        public void MapGenerate(DataBase dataBase)
        {
            for (int i = 0; i < dataBase.Shops.Count; i++)
            {
                GenerateShop(dataBase.Shops[i]);
            }

        }

        public void GenerateShop(Shop<Case<Product<int>>> shop)
        {
            
            PrintLine("/-" + 
                      new string('-',((shop.Storage.Capacity * 15) / 2) - 2) + 
                      "Shop" + 
                      new string('-',((shop.Storage.Capacity * 15) / 2) - 2 + ((shop.Storage.Capacity * 15) % 2)) + 
                      "-\\");
            
            SaveCursor();
            for (int i = 0; i < shop.Storage.Capacity; i++)
            {
                try
                {
                    GenerateCase(shop.Storage[i]);
                }
                catch
                {
                    SetCursorY();
                   // SetCursorX();
                    PrintLine("/----Empty---\\");
                    SetCursorX();
                    PrintLine("|------------|");
                    SetCursorX();
                    Print("\\------------/");
                    SaveCursorX();
                }
            }
            PrintLine("");
            PrintLine("\\-" + 
                      new string('-',((shop.Storage.Capacity * 15) / 2) - 2) + 
                      "----" + 
                      new string('-',((shop.Storage.Capacity * 15) / 2) - 2 + ((shop.Storage.Capacity * 15) % 2)) + 
                      "-/");
        }

        public void GenerateCase(Case<Product<int>> case_)
        {
            SetCursorY();
            PrintLine("/-" + 
                      new string('-',((case_.Storage.Capacity * 5) / 2) - 2) + 
                      "Case" + 
                      new string('-',((case_.Storage.Capacity * 5) / 2) - 2 + ((case_.Storage.Capacity * 5) % 2)) + 
                      "-\\");
            SetCursorX();
            Print("|-");
            for (int i = 0; i < case_.Storage.Capacity; i++)
            {
                try
                {
                    Print("-[" + case_.Storage[i].Marker + "]-");
                }
                catch
                {
                    Print("-" + "[ ]" + "-");
                }
            }
            PrintLine("-|");
            SetCursorX();
            Print("\\-" + new string('-',case_.Storage.Capacity * 5) + "-/");
            //
            //Console.WriteLine("");
            SaveCursorX();
            
        }

        public void GenerateProduct(Product<int> product)
        {
            Print(product.Marker);
        }

        public void GenerateMenu()
        {
            PrintLine("-Product list-");
            PrintLine("Name product - *");
            PrintLine("Name product2 - $");
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
        
        /* custom method printline width color*/
        public static void PrintLine(string value, ConsoleColor color = ConsoleColor.White)
        {
            if (color != null)
            {
                Console.ForegroundColor = color;
            }
            Console.WriteLine(value);
            if (color != null)
            {
                Console.ResetColor();
            }
        }

        /* custom method printline */
        public static void PrintLine()
        {
            Console.WriteLine();
        }        
        /* custom method print width color */
        public static void Print(string value, ConsoleColor color = ConsoleColor.White)
        {
            if (color != null)
            {
                Console.ForegroundColor = color;
            }
            Console.Write(value);
            if (color != null)
            {
                Console.ResetColor();
            }
        }

    }
}