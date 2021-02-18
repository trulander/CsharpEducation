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
        private int[] _pointerItems;

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

        public void MapGenerate(DataBase dataBase, int[] pointerItems)
        {
            _pointerItems = pointerItems;
            for (int i = 0; i < dataBase.Shops.Count; i++)
            {
                GenerateShop(dataBase.Shops[i], i);                     
            }

        }

        public void GenerateShop(Shop<Case<Product<int>>> shop, int currentShop)
        {
            ConsoleColor color;
            if (currentShop == _pointerItems[0])
            {
                color = ConsoleColor.Green;
            }else
            {
                color = ConsoleColor.White;
            }
            PrintLine("/-" + 
                      new string('-',((shop.Storage.Capacity * 15) / 2) - 2) + 
                      "Shop" + 
                      new string('-',((shop.Storage.Capacity * 15) / 2) - 2 + ((shop.Storage.Capacity * 15) % 2)) + 
                      "-\\", color);
            
            SaveCursor();
            ConsoleColor caseColor;
            int currentCase;
            for (int i = 0; i < shop.Storage.Capacity; i++)
            {
                if (currentShop == _pointerItems[0] && _pointerItems[1] == i)
                {
                    caseColor = ConsoleColor.Green;
                    currentCase = i;
                }
                else
                {
                    caseColor = ConsoleColor.White;
                    currentCase = -1;
                }
                
                try
                {
                    GenerateCase(shop.Storage[i], currentCase);
                }
                catch
                {
                    SetCursorY();
                   // SetCursorX();
                    PrintLine("/----Empty---\\", caseColor);
                    SetCursorX();
                    PrintLine("|------------|", caseColor);
                    SetCursorX();
                    Print("\\------------/", caseColor);
                    SaveCursorX();
                }
            }
            PrintLine("");
            PrintLine("\\-" + 
                      new string('-',((shop.Storage.Capacity * 15) / 2) - 2) + 
                      "----" + 
                      new string('-',((shop.Storage.Capacity * 15) / 2) - 2 + ((shop.Storage.Capacity * 15) % 2)) + 
                      "-/", color);
        }

        public void GenerateCase(Case<Product<int>> case_, int currentCase)
        {
            ConsoleColor caseColor;
            if (currentCase == _pointerItems[1])
            {
                caseColor = ConsoleColor.Green;
            }
            else
            {
                caseColor = ConsoleColor.White;
            }
            SetCursorY();
            PrintLine("/-" + 
                      new string('-',((case_.Storage.Capacity * 5) / 2) - 2) + 
                      "Case" + 
                      new string('-',((case_.Storage.Capacity * 5) / 2) - 2 + ((case_.Storage.Capacity * 5) % 2)) + 
                      "-\\", caseColor);
            SetCursorX();
            Print("|-", caseColor);
            for (int i = 0; i < case_.Storage.Capacity; i++)
            {
                ConsoleColor color;
                if (currentCase == _pointerItems[1] && _pointerItems[2] == i)
                {
                    color = ConsoleColor.Green;
                }
                else
                {
                    color = ConsoleColor.White;
                }
                try
                {
                    Print("-[" + case_.Storage[i].Marker + "]-", color);
                }
                catch
                {
                    Print("-" + "[ ]" + "-", color);
                }
            }
            PrintLine("-|", caseColor);
            SetCursorX();
            Print("\\-" + new string('-',case_.Storage.Capacity * 5) + "-/", caseColor);
            //
            //Console.WriteLine("");
            SaveCursorX();
            
        }

        public void GenerateProduct(Product<int> product, ConsoleColor color)
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