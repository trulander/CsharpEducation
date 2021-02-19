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
        private int _maxCoordinatX = 0;
        private int _maxCoordinatY = 0;
        
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
            Console.SetCursorPosition(0, 0);
            _pointerItems = pointerItems;
            for (int i = 0; i < dataBase.Shops.Count; i++)
            {
                GenerateShop(dataBase.Shops[i], i);                     
            }
            GenerateMenu();
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
            CountPointerForMenu();
            PrintLine("");
            Print("\\-" + 
                      new string('-',((shop.Storage.Capacity * 15) / 2) - 2) + 
                      "----" + 
                      new string('-',((shop.Storage.Capacity * 15) / 2) - 2 + ((shop.Storage.Capacity * 15) % 2)) + 
                      "-/", color);
            CountPointerForMenu();
            PrintLine("");
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
            SaveCursorX();
        }

        public void GenerateProduct(Product<int> product, ConsoleColor color)
        {
            Print(product.Marker);
        }

        public void GenerateMenu()
        {
            Console.SetCursorPosition(_maxCoordinatX+5,0);
            SaveCursor();
            PrintLine("Shop information");
            SetCursorX();
            PrintLine("Current shop : " + (_pointerItems[0] + 1));
            SetCursorX();
            PrintLine("Current case : " + (_pointerItems[1] + 1));
            SetCursorX();
            PrintLine("Current product : " + (_pointerItems[2] + 1));
            SetCursorX();
            PrintLine("----Menu----");
            SetCursorX();
            PrintLine("Name product - *");
            SetCursorX();
            PrintLine("Name product2 - $");
            Console.SetCursorPosition(0,_maxCoordinatY+1);
        }

        public void CountPointerForMenu()
        {
            if (_maxCoordinatX < Console.CursorLeft)
            {
                _maxCoordinatX = Console.CursorLeft;
            }

            if (_maxCoordinatY < Console.CursorTop)
            {
                _maxCoordinatY = Console.CursorTop;
            }
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