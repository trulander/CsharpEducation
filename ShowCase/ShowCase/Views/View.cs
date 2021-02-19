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
        private int _maxCoordinatX = 0;
        private int _maxCoordinatY = 0;
        private int _sizeMenuX = 0;
        private int _sizeMenuY = 0;
        
        private DataBase _dataBase;
        private int[] _pointerItems;
        
        private int sizeMenuX
        {
            get { return _sizeMenuX;}
            set
            {
                if (value > _sizeMenuX)
                {
                    _sizeMenuX = value;
                }
            }
        }
        private int sizeMenuY
        {
            get { return _sizeMenuY;}
            set
            {
                if (value > _sizeMenuY)
                {
                    _sizeMenuY = value;
                }
            }
        }
        
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
        /*Main generation view*/
        public void MapGenerate(DataBase dataBase, int[] pointerItems, List<string> menu)
        {
            Console.SetCursorPosition(0, 0);
            _pointerItems = pointerItems;
            _dataBase = dataBase;
            for (int i = 0; i < dataBase.Shops.Capacity; i++)
            {
                if (_dataBase.Shops.Count > i)
                {                
                    GenerateShop(dataBase.Shops[i], i);
                }
                else
                {
                    ConsoleColor color = ConsoleColor.White;
                    if (_pointerItems[0] == i)
                    {
                        color = ConsoleColor.Green;
                    }
                    PrintLine("/----Empty shop---\\", color);
                    PrintLine("|-----------------|", color);
                    Print("\\-----------------/", color);
                    CountPointerForMenu();
                    PrintLine("");
                }
            }
            GenerateMenu(menu);
        }
        /*Generating one of shops*/
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

                if (shop.Storage.Count > i)
                {
                    GenerateCase(shop.Storage[i], currentCase);
                }
                else
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
        /*Generating one of cases*/
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

                if (case_.Storage.Count > i)
                {
                    Print("-[" + case_.Storage[i].Marker + "]-", color);
                }
                else
                {
                    Print("-" + "[ ]" + "-", color);
                }
            }
            PrintLine("-|", caseColor);
            SetCursorX();
            Print("\\-" + new string('-',case_.Storage.Capacity * 5) + "-/", caseColor);
            SaveCursorX();
        }
        
        /*Generating one of products*/
        public void GenerateProduct(Product<int> product, ConsoleColor color)
        {
            Print(product.Marker);
        }

        /*Generating menu*/
        public void GenerateMenu(List<string> menu)
        {
            Console.SetCursorPosition(_maxCoordinatX+5,0);
            SaveCursor();
            /* clearing place for menu*/
            for (int i = 0; i < _sizeMenuY; i++)
            {
                Console.WriteLine(new string(' ', _sizeMenuX));
                SetCursorX();
            } 

            Console.SetCursorPosition(_maxCoordinatX+5,0);

            sizeMenuX = PrintLine("Shop information");
            SetCursorX();
            sizeMenuX = PrintLine("Current shop : " + (_pointerItems[0] + 1));

            /*if i'm on empty shop, i don't have to show information about case*/
            if (_dataBase.Shops.Count > _pointerItems[0])
            {
                SetCursorX();
                sizeMenuX = PrintLine("Current case : " + (_pointerItems[1] + 1));
                /*if i/m on empty case, i don't have to show information about products*/
                if (_dataBase.Shops[_pointerItems[0]].Storage.Count > _pointerItems[1] && _dataBase.Shops[_pointerItems[0]].Storage[_pointerItems[1]].Storage.Count > _pointerItems[2])
                {
                
                    if (_dataBase.Shops[_pointerItems[0]].Storage[_pointerItems[1]].Storage[_pointerItems[2]].Name != default)
                    {
                        SetCursorX();
                        sizeMenuX = PrintLine("Current product : " + (_pointerItems[2] + 1));
                        SetCursorX();
                        sizeMenuX = PrintLine("Product name : " + _dataBase.Shops[_pointerItems[0]].Storage[_pointerItems[1]].Storage[_pointerItems[2]].Name);                    
                    }
                    else
                    {
                        SetCursorX();
                        sizeMenuX = PrintLine("Current product : " + (_pointerItems[2] + 1));
                    }                    
                }
            }
           

            SetCursorX();
            sizeMenuX = PrintLine("----Menu----");

            foreach (string line in menu)
            {
                SetCursorX();
                sizeMenuX = PrintLine(line);
            }
            sizeMenuY = Console.CursorTop;
            Console.SetCursorPosition(0,_maxCoordinatY+1);
        }
        /*save maximum coordinate for generate menu to the right of main place*/
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
        public static int PrintLine(string value, ConsoleColor color = ConsoleColor.White)
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

            return value.Length;
        }

        /* custom method printline */
        public static void PrintLine()
        {
            Console.WriteLine();
        }        
        /* custom method print width color */
        public static int Print(string value, ConsoleColor color = ConsoleColor.White)
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

            return value.Length;
        }

    }
}