using System;
using System.Collections.Generic;
using ShowCase.Models;
using ShowCase.Views;

namespace ShowCase.Controllers
{
    public class ProgramController
    {
        private DataBase _dataBase;
        private ModelController _modelController;
        private View _view;
        private int PointerProduct = 0;

        private int[] _pointerItems = new int[3];
        public ProgramController()
        {
            /* 0 Pointer on a shop*/
            _pointerItems[0] = 0;
            /* 1 Pointer on a case*/
            _pointerItems[1] = 0;
            /* 2 Pointer on a product*/
            _pointerItems[2] = 0;
            
            _dataBase = new DataBase();
            _view = new View();
            _modelController = new ModelController(_dataBase);
            /*filling out of demo data*/
            DemoData demoData = new DemoData(_modelController,_dataBase);
            
            Console.TreatControlCAsInput = true;/* drop default action when we're using modification key (ctrl, shift,alt) */
            Console.CursorVisible = false;/* hide cursor */
            
            _view.MapGenerate(_dataBase, _pointerItems, MakeMenu());
            Loop();
        }

        /*Main loop the programm*/
        private void Loop()
        {
            bool _continue = true;
            while (_continue)
            {
                _continue = ReadKey();
                _view.MapGenerate(_dataBase, _pointerItems, MakeMenu());
            }
        }
        /*Button handing*/
        private bool ReadKey()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            
            /*If i have hold "shift" button, i have to chacge position cursor inside a case*/
            if ((key.Modifiers & ConsoleModifiers.Shift) != 0)
            {
                switch ((int)key.Key)
                {
                    case (int)DataBase.KeyData.RIGHT:
                        ChangePositionProduct(1);
                        break;
                    case (int)DataBase.KeyData.LEFT:
                        ChangePositionProduct(-1);
                        break;
                    default:
                        return true;
                        break;
                }
            }
            /*Main moving by view*/
            else
            {
                switch ((int) key.Key)
                {
                    case (int) DataBase.KeyData.UP:
                        ChangePositionShop(-1);
                        break;
                    case (int) DataBase.KeyData.DOWN:
                        ChangePositionShop(1);
                        break;
                    case (int) DataBase.KeyData.RIGHT:
                        ChangePositionCase(1);
                        break;
                    case (int) DataBase.KeyData.LEFT:
                        ChangePositionCase(-1);
                        break;
                    case (int) DataBase.KeyData.EXIT:
                        Console.WriteLine("Exit");
                        return false;
                        break;
                    default:
                        return true;
                        break;
                }
            }
            return true;
        }

        private List<string> MakeMenu()
        {
            List<string> result = new List<string>();
            if (_dataBase.Shops.Count > _pointerItems[0])
            {
                result.Add("Edit size the shop");
                if (_dataBase.Shops[_pointerItems[0]].Storage.Count > _pointerItems[1])
                {
                    result.Add("Edit size the case");
                    if (_dataBase.Shops[_pointerItems[0]].Storage[_pointerItems[1]].Storage.Count > _pointerItems[2])
                    {
                        result.Add("Edit name the product");
                        result.Add("Remove the product");
                    }
                    else
                    {
                        result.Add("Add new product");
                    }
                }
                else
                {
                    result.Add("Add new case");
                }
            }
            else
            {
                result.Add("Add new shop");
            }
            
            //result.Add("Remove the shop");
            //result.Add("Remove the case");
            //result.Add("Remove the product");
            
            return result;
        }

        private void ChangePositionShop(int goTo)
        {
            if ((_pointerItems[0] + goTo) >= 0 && (goTo + _pointerItems[0]) <= _dataBase.Shops.Capacity-1)
            {
                _pointerItems[0] = _pointerItems[0] + goTo;
                ChangePositionCase(0);
            }
        }

        private void ChangePositionCase(int goTo)
        {
            /*if i on the empty shop, i have to clear case and product positions*/
            if (_dataBase.Shops.Count > _pointerItems[0])
            {
                /*if possible to go where i want*/
                if ((_pointerItems[1] + goTo) >= 0 && (goTo + _pointerItems[1]) <= _dataBase.Shops[_pointerItems[0]].Storage.Capacity-1)
                {
                    _pointerItems[1] = _pointerItems[1] + goTo;
                    /*if i'm on the empty case? i have to clear product position*/
                    if (_dataBase.Shops[_pointerItems[0]].Storage.Count > _pointerItems[1])
                    {
                        /*if after change case position i'm on impossible product, i have to change product position for possible(for last)*/
                        if (_pointerItems[2] > _dataBase.Shops[_pointerItems[0]].Storage[_pointerItems[1]].Storage.Capacity-1)
                        {
                            _pointerItems[2] = _dataBase.Shops[_pointerItems[0]].Storage[_pointerItems[1]].Storage.Capacity-1;
                        }
                    }
                    else
                    {
                        _pointerItems[2] = 0;
                    } 
                /*if i can't to go where i want*/
                }else if (_pointerItems[1] > _dataBase.Shops[_pointerItems[0]].Storage.Capacity-1)
                {
                    _pointerItems[1] = _dataBase.Shops[_pointerItems[0]].Storage.Capacity - 1;
                    _pointerItems[2] = 0;
                }
            }
            else
            {
                _pointerItems[1] = 0;
                _pointerItems[2] = 0;
            }
           
        }
        private void ChangePositionProduct(int goTo)
        {
            /*if i'm not on the empty shop*/
            if (_dataBase.Shops.Count > _pointerItems[0])
            {
                /*if i'm not on the empty case*/
                if (_dataBase.Shops[_pointerItems[0]].Storage.Count > _pointerItems[1])
                {
                    /*check for possible to move*/
                    if ((_pointerItems[2] + goTo) >= 0 && (goTo + _pointerItems[2]) <= _dataBase.Shops[_pointerItems[0]].Storage[_pointerItems[1]].Storage.Capacity-1)
                    {
                        _pointerItems[2] = _pointerItems[2] + goTo;
                    }                
                }                
            }
        }        
    }
}