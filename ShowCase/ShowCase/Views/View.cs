using System;
using System.Collections.Generic;
using System.Linq;
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
        
        private DataBase _dataBase = DataBase.GetInstance();
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

        private void SetCursorX()
        {
            Console.SetCursorPosition(_coordinateCursorX, Console.CursorTop);
        }
        private void SetCursorY()
        {
            Console.SetCursorPosition(Console.CursorLeft, _coordinateCursorY);
        }        
    
        /*Main generation view*/
        public void MapGenerate(int[] pointerItems, Dictionary<int, string> menu)
        {
            Console.SetCursorPosition(0, 0);
            _pointerItems = pointerItems;
            for (int i = 0; i < _dataBase.shops.Capacity; i++)
            {
                if (_dataBase.shops.Count > i)
                {                
                    GenerateShop(_dataBase.shops[i], i);
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

            int sizeHeadshop = -4;

            for (int i = 0; i < shop.storage.Capacity; i++)
            {
                if (shop.storage.Count > i)
                {
                    sizeHeadshop += (shop.storage[i].storage.Capacity * 5) + 4;
                }
                else
                {
                    sizeHeadshop += 14;
                }
            }

 
            PrintLine("/-" + 
                      new string('-',(sizeHeadshop / 2) - 2) + 
                      "Shop" + 
                      new string('-',(sizeHeadshop / 2) - 2 + (sizeHeadshop % 2)) + 
                      "-\\", color);
            
            SaveCursor();
            ConsoleColor caseColor;
            int currentCase;
            for (int i = 0; i < shop.storage.Capacity; i++)
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

                if (shop.storage.Count > i)
                {
                    GenerateCase(shop.storage[i], currentCase);
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
            Print("\\-" + new string('-',sizeHeadshop) +"-/", color);
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
                      new string('-',((case_.storage.Capacity * 5) / 2) - 2) + 
                      "Case" + 
                      new string('-',((case_.storage.Capacity * 5) / 2) - 2 + ((case_.storage.Capacity * 5) % 2)) + 
                      "-\\", caseColor);
            SetCursorX();
            Print("|-", caseColor);
            for (int i = 0; i < case_.storage.Capacity; i++)
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

                if (case_.storage.Count > i)
                {
                    Print("-[" + case_.storage[i].Marker + "]-", color);
                }
                else
                {
                    Print("-" + "[ ]" + "-", color);
                }
            }
            PrintLine("-|", caseColor);
            SetCursorX();
            Print("\\-" + new string('-',case_.storage.Capacity * 5) + "-/", caseColor);
            SaveCursorX();
        }
        
        /*Generating menu*/
        public void GenerateMenu(Dictionary<int, string> menu)
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

            /*if i'm on empty shop, i don't have to show information about shop*/
            if (_dataBase.shops.Count > _pointerItems[0])
            {
                SetCursorX();
                sizeMenuX = PrintLine("  id : " + _dataBase.shops[_pointerItems[0]].id.ToString().Substring(0,13));
                SetCursorX();
                sizeMenuX = PrintLine("  data create : " + _dataBase.shops[_pointerItems[0]].whenCreate.ToString().Substring(0,10));
                SetCursorX();
                sizeMenuX = PrintLine("  time create : " + _dataBase.shops[_pointerItems[0]].whenCreate.ToString().Substring(11));
                SetCursorX();
                sizeMenuX = PrintLine("  name : " + _dataBase.shops[_pointerItems[0]].name);
                SetCursorX();
                sizeMenuX = PrintLine("Current case : " + (_pointerItems[1] + 1));
                /*if i'm on empty case, i don't have to show information about case*/
                if (_dataBase.shops[_pointerItems[0]].storage.Count > _pointerItems[1])
                {   
                    SetCursorX();
                    sizeMenuX = PrintLine("  id : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].id.ToString().Substring(0,13));
                    SetCursorX();
                    sizeMenuX = PrintLine("  data create : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].whenCreate.ToString().Substring(0,10));
                    SetCursorX();
                    sizeMenuX = PrintLine("  time create : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].whenCreate.ToString().Substring(11));
                    SetCursorX();
                    sizeMenuX = PrintLine("  name : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].name);
                    /*if i'm on empty field for product, i don't have to show information about products*/
                    if (_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage.Count > _pointerItems[2])
                    {
                        SetCursorX();
                        sizeMenuX = PrintLine("Current product : " + (_pointerItems[2] + 1));
                        SetCursorX();
                        sizeMenuX = PrintLine("  id : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]].id.ToString().Substring(0,13));                    
                        SetCursorX();
                        sizeMenuX = PrintLine("  data create : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]].whenCreate.ToString().Substring(0,10));
                        SetCursorX();
                        sizeMenuX = PrintLine("  time create : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]].whenCreate.ToString().Substring(11));
                        SetCursorX();
                        sizeMenuX = PrintLine("  name : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]].name);
                        SetCursorX();
                        sizeMenuX = PrintLine("  cost : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]].cost);
                    }
                   
                                   
                }
            }
           

            SetCursorX();
            sizeMenuX = PrintLine("-------Menu-------");
            ConsoleColor color = ConsoleColor.White;
            foreach (KeyValuePair<int, string> item in menu)
            {
                if (_pointerItems[3] == 0)
                {
                    if (item.Key == menu.Keys.First())
                    {
                        color = ConsoleColor.Green;
                    }
                    else
                    {
                        color = ConsoleColor.White;    
                    }
                }
                else
                {
                    if (menu.Keys.ElementAt(_pointerItems[3]) == item.Key)
                    {
                        color = ConsoleColor.Green;
                    }
                    else
                    {
                        color = ConsoleColor.White;                        
                    }
                }
                SetCursorX();
                sizeMenuX = PrintLine(item.Value, color);
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
        public int PrintLine(string value, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(value);
            Console.ResetColor();

            return value.Length;
        }

        /* custom method print width color */
        public int Print(string value, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;

            Console.Write(value);
            Console.ResetColor();

            return value.Length;
        }

        public void Instruction()
        {
            PrintLine("The buttons what you can to use:");
            PrintLine("Up Down Left Right Enter Escape");
            PrintLine("And the same buttons + 'shift'");
            PrintLine("");
            PrintLine("Navigation via shops you have to use buttons Up and Down");
            PrintLine("Navigation via case you have to use buttons Right and Left");
            PrintLine("Navigation via products you have to use buttons together Shift + Left and Shift + Right");
            PrintLine("Navigation via menu you have to use buttons together Shift + Up and Shift + Down");
            PrintLine("For apply point of menu you have to use button Enter");
            PrintLine("For exit from the program you have to use button Enter");
            Console.ReadKey();
            Console.Clear();
        }
    }
}