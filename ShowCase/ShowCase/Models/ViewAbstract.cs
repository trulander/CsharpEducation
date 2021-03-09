using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading;


namespace ShowCase.Models
{
    public abstract class ViewAbstract
    {
        public EventWaitHandle[] waitHandle { get; set; }
        public string lastMethodRequired { get; set; }
        public int? ConsoleKey { get; set; }
        public int? ConsoleKeyModifiers { get; set; }
        public string? ConsoleText { get; set; }
        
        protected Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>> _map = new Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>>();
        protected int _savedCursorX = 0;
        protected int _savedCursorY = 0;
        protected int _curentCursorX = 0;
        protected int _curentCursorY = 0;
        protected int _maxCoordinatX = 0;
        protected int _maxCoordinatY = 0;
        protected int _sizeMenuX = 0;
        protected int _sizeMenuY = 0;

        protected DataBase _dataBase = DataBase.GetInstance();
        protected int[] _pointerItems;

        public string Buffer
        {
            get
            {
                if (_map.Count == 0)
                {
                    return JsonConvert.SerializeObject(new String("123"));
                }
                return JsonConvert.SerializeObject(_map, Formatting.Indented);
            }
        }
        protected int SizeMenuX
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
        protected int SizeMenuY
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
        
        /*Main generation view*/
        public void MapGenerate(int[] pointerItems, Dictionary<int, string> menu)
        {
            SetCursorX(0);
            SetCursorY(0);
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
            
            SaveCurrentCursor();
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
                    SetCursorY(_savedCursorY);
                   // SetCursorX();
                    PrintLine("/----Empty---\\", caseColor);
                    SetCursorX(_savedCursorX);
                    PrintLine("|------------|", caseColor);
                    SetCursorX(_savedCursorX);
                    Print("\\------------/", caseColor);
                    SaveCurrentCursorX();
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
            SetCursorY(_savedCursorY);
            PrintLine("/-" + 
                      new string('-',((case_.storage.Capacity * 5) / 2) - 2) + 
                      "Case" + 
                      new string('-',((case_.storage.Capacity * 5) / 2) - 2 + ((case_.storage.Capacity * 5) % 2)) + 
                      "-\\", caseColor);
            SetCursorX(_savedCursorX);
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
            SetCursorX(_savedCursorX);
            Print("\\-" + new string('-',case_.storage.Capacity * 5) + "-/", caseColor);
            SaveCurrentCursorX();
        }
        
        /*Generating menu*/
        public void GenerateMenu(Dictionary<int, string> menu)
        {
            SetCursorX(_maxCoordinatX+5);
            SetCursorY(0);
            SaveCurrentCursor();
            /* clearing place for menu*/
            for (int i = 0; i < SizeMenuY; i++)
            {
                PrintLine(new string(' ', SizeMenuX));
                SetCursorX(_savedCursorX);
            } 

            SetCursorX(_maxCoordinatX+5);
            SetCursorY(0);

            SizeMenuX = PrintLine("Shop information");
            SetCursorX(_savedCursorX);
            SizeMenuX = PrintLine("Current shop : " + (_pointerItems[0] + 1));

            /*if i'm on empty shop, i don't have to show information about shop*/
            if (_dataBase.shops.Count > _pointerItems[0])
            {
                SetCursorX(_savedCursorX);
                SizeMenuX = PrintLine("  id : " + _dataBase.shops[_pointerItems[0]].id.ToString().Substring(0,13));
                SetCursorX(_savedCursorX);
                SizeMenuX = PrintLine("  data create : " + _dataBase.shops[_pointerItems[0]].whenCreate.ToString().Substring(0,10));
                SetCursorX(_savedCursorX);
                SizeMenuX = PrintLine("  time create : " + _dataBase.shops[_pointerItems[0]].whenCreate.ToString().Substring(11));
                SetCursorX(_savedCursorX);
                SizeMenuX = PrintLine("  name : " + _dataBase.shops[_pointerItems[0]].name);
                SetCursorX(_savedCursorX);
                SizeMenuX = PrintLine("Current case : " + (_pointerItems[1] + 1));
                /*if i'm on empty case, i don't have to show information about case*/
                if (_dataBase.shops[_pointerItems[0]].storage.Count > _pointerItems[1])
                {   
                    SetCursorX(_savedCursorX);
                    SizeMenuX = PrintLine("  id : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].id.ToString().Substring(0,13));
                    SetCursorX(_savedCursorX);
                    SizeMenuX = PrintLine("  data create : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].whenCreate.ToString().Substring(0,10));
                    SetCursorX(_savedCursorX);
                    SizeMenuX = PrintLine("  time create : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].whenCreate.ToString().Substring(11));
                    SetCursorX(_savedCursorX);
                    SizeMenuX = PrintLine("  name : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].name);
                    /*if i'm on empty field for product, i don't have to show information about products*/
                    if (_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage.Count > _pointerItems[2])
                    {
                        SetCursorX(_savedCursorX);
                        SizeMenuX = PrintLine("Current product : " + (_pointerItems[2] + 1));
                        SetCursorX(_savedCursorX);
                        SizeMenuX = PrintLine("  id : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]].id.ToString().Substring(0,13));                    
                        SetCursorX(_savedCursorX);
                        SizeMenuX = PrintLine("  data create : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]].whenCreate.ToString().Substring(0,10));
                        SetCursorX(_savedCursorX);
                        SizeMenuX = PrintLine("  time create : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]].whenCreate.ToString().Substring(11));
                        SetCursorX(_savedCursorX);
                        SizeMenuX = PrintLine("  name : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]].name);
                        SetCursorX(_savedCursorX);
                        SizeMenuX = PrintLine("  cost : " + _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]].cost);
                    }
                   
                                   
                }
            }
           

            SetCursorX(_savedCursorX);
            SizeMenuX = PrintLine("-------Menu-------");
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
                SetCursorX(_savedCursorX);
                SizeMenuX = PrintLine(item.Value, color);
            }
            SizeMenuY = GetCurrentCursorY();
            SetCursorX(0);
            SetCursorY(_maxCoordinatY+1);
        }
        /*save maximum coordinate for generate menu to the right of main place*/
        public void CountPointerForMenu()
        {
            if (_maxCoordinatX < GetCurrentCursorX())
            {
                _maxCoordinatX = GetCurrentCursorX();
            }

            if (_maxCoordinatY < GetCurrentCursorY())
            {
                _maxCoordinatY = GetCurrentCursorY();
            }
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
            ReadKey();
            Clear();
        }
        
        protected abstract void SetCursorY(int y);
        protected abstract void SetCursorX(int x);
        protected abstract int GetCurrentCursorY();
        protected abstract int GetCurrentCursorX();
        protected abstract void SaveCurrentCursorX();
        protected abstract void SaveCurrentCursor();
        public abstract int PrintLine(string value, ConsoleColor color = ConsoleColor.White);
        public abstract int Print(string value, ConsoleColor color = ConsoleColor.White);
        public abstract void Clear();
        public abstract string ReadLine();
        public abstract int[] ReadKey();
    }
}