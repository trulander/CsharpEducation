﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ShowCase.Models;
using ShowCase.Views;

namespace ShowCase.Controllers
{
    public class ProgramController
    {
        private DataBase _dataBase;
        private ModelController _modelController;
        private View _view;
        private Dictionary<int, string> _menu;

        private int[] _pointerItems = new int[4];
        public ProgramController()
        {
            /* 0 Pointer on a shop*/
            _pointerItems[0] = 0;
            /* 1 Pointer on a case*/
            _pointerItems[1] = 0;
            /* 2 Pointer on a product*/
            _pointerItems[2] = 0;
            /* 3 Pointer on a point of menu*/
            _pointerItems[3] = 0;

            _dataBase = new DataBase();
            _view = new View();
            
            _modelController = new ModelController(_dataBase);
            /*filling out of demo data*/
            DemoData demoData = new DemoData(_modelController,_dataBase);
            
            Console.TreatControlCAsInput = true;/* drop default action when we're using modification key (ctrl, shift,alt) */
            Console.CursorVisible = false;/* hide cursor */
            _menu = MakeMenu();
            _view.MapGenerate(_dataBase, _pointerItems, _menu);
            Loop();
        }

        /*Main loop the programm*/
        private void Loop()
        {
            bool continue_ = true;
            while (continue_)
            {
                continue_ = ReadKey();
                _menu = MakeMenu();
                _view.MapGenerate(_dataBase, _pointerItems, _menu);
            }
        }
        /*Button handing*/
        private bool ReadKey()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            /*If i have hold "shift" button, i can to change position cursor inside a case and in menu*/
            if ((key.Modifiers & ConsoleModifiers.Shift) != 0)
            {
                switch ((int)key.Key)
                {
                    case (int)DataBase.KeyData.UP:
                        ChangePositionMenu(-1);
                        break;
                    case (int)DataBase.KeyData.DOWN:
                        ChangePositionMenu(1);
                        break;
                    case (int)DataBase.KeyData.RIGHT:
                        ChangePositionProduct(1);
                        break;
                    case (int)DataBase.KeyData.LEFT:
                        ChangePositionProduct(-1);
                        break;
                    default:
                        return true;
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
                    case (int)DataBase.KeyData.APPLY:
                        MenuActions();
                        break;
                    case (int) DataBase.KeyData.EXIT:
                        Console.WriteLine("Exit");
                        return false;
                    default:
                        return true;
                }
            }
            return true;
        }

        /*Router actions for menu*/
        private void MenuActions()
        {
            Console.TreatControlCAsInput = false;/* apply default action when we're using modification key (ctrl, shift,alt) */
            Console.CursorVisible = true;/* show cursor */
            switch (_menu.Keys.ElementAt(_pointerItems[3]))
            {
                case (int)DataBase.Actions.EditSizeShop:
                    _modelController.EditSize(_dataBase.shops[_pointerItems[0]]);
                    break;
                case (int)DataBase.Actions.EditSizeCase:
                    _modelController.EditSize(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]]);
                    break;
                case (int)DataBase.Actions.RemoveShop:
                    _modelController.Remove(_dataBase.shops[_pointerItems[0]]);
                    break;
                case (int)DataBase.Actions.RemoveCase:
                    _modelController.Remove(_dataBase.shops[_pointerItems[0]], _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]]);
                    break;
                case (int)DataBase.Actions.RemoveProduct:
                    _modelController.Remove(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]], _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]]);
                    break;
                case (int)DataBase.Actions.AddShop:
                    _modelController.Create();
                    break;
                case (int)DataBase.Actions.AddCase:
                    _modelController.Create(_dataBase.shops[_pointerItems[0]]);
                    break;
                case (int)DataBase.Actions.AddProduct:
                    _modelController.Create(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]]);
                    break;
                case (int)DataBase.Actions.EditNameProduct:
                    _modelController.Rename(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]]);
                    break;

                case (int)DataBase.Actions.EditNameShop:
                    _modelController.Rename(_dataBase.shops[_pointerItems[0]]);
                    break;
                case (int)DataBase.Actions.EditNameCase:
                    _modelController.Rename(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]]);
                    break;
                case (int)DataBase.Actions.EditCostProduct:
                    _modelController.ChacgeCost(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]]);
                    break;
            }
            _pointerItems[3] = 0;
            Console.Clear();
            Console.TreatControlCAsInput = true;/* drop default action when we're using modification key (ctrl, shift,alt) */
            Console.CursorVisible = false;/* hide cursor */
        }
        private Dictionary<int, string> MakeMenu()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            if (_dataBase.shops.Count > _pointerItems[0])
            {
                result.Add((int)DataBase.Actions.EditSizeShop ,"Edit size the shop");
                result.Add((int)DataBase.Actions.EditNameShop ,"Edit name the shop");
                if (_dataBase.shops[_pointerItems[0]].storage.Count > _pointerItems[1])
                {
                    result.Add((int)DataBase.Actions.EditSizeCase, "Edit size the case");
                    result.Add((int)DataBase.Actions.EditNameCase ,"Edit name the case");
                    if (_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage.Count > _pointerItems[2])
                    {
                        result.Add((int)DataBase.Actions.EditNameProduct,"Edit name the product");
                        result.Add((int)DataBase.Actions.EditCostProduct ,"Edit cost the product");
                        result.Add((int)DataBase.Actions.RemoveProduct, "Remove the product");
                    }
                    else
                    {
                        if (_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage.Count == 0)
                        {
                            result.Add((int)DataBase.Actions.RemoveCase, "Remove the case");
                        }
                        result.Add((int)DataBase.Actions.AddProduct, "Add new product");
                    }
                }
                else
                {
                    if (_dataBase.shops[_pointerItems[0]].storage.Count == 0)
                    {
                        result.Add((int)DataBase.Actions.RemoveShop, "Remove the shop");
                    }
                    result.Add((int)DataBase.Actions.AddCase, "Add new case");
                }
            }
            else
            {
                result.Add((int)DataBase.Actions.AddShop,"Add new shop");
            }
           
            return result;
        }

        private void ChangePositionShop(int goTo)
        {
            if ((_pointerItems[0] + goTo) >= 0 && (goTo + _pointerItems[0]) <= _dataBase.shops.Capacity-1)
            {
                _pointerItems[0] = _pointerItems[0] + goTo;
                ChangePositionCase(0);
            }
        }

        private void ChangePositionCase(int goTo)
        {
            /*if i on the empty shop, i have to clear case and product positions*/
            if (_dataBase.shops.Count > _pointerItems[0])
            {
                /*if possible to go where i want*/
                if ((_pointerItems[1] + goTo) >= 0 && (goTo + _pointerItems[1]) <= _dataBase.shops[_pointerItems[0]].storage.Capacity-1)
                {
                    _pointerItems[1] = _pointerItems[1] + goTo;
                    /*if i'm on the empty case? i have to clear product position*/
                    if (_dataBase.shops[_pointerItems[0]].storage.Count > _pointerItems[1])
                    {
                        /*if after change case position i'm on impossible product, i have to change product position for possible(for last)*/
                        if (_pointerItems[2] > _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage.Capacity-1)
                        {
                            _pointerItems[2] = _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage.Capacity-1;
                        }
                    }
                    else
                    {
                        _pointerItems[2] = 0;
                    } 
                /*if i can't to go where i want*/
                }else if (_pointerItems[1] > _dataBase.shops[_pointerItems[0]].storage.Capacity-1)
                {
                    _pointerItems[1] = _dataBase.shops[_pointerItems[0]].storage.Capacity - 1;
                    _pointerItems[2] = 0;
                }
                _pointerItems[3] = 0;
            }
            else
            {
                _pointerItems[1] = 0;
                _pointerItems[2] = 0;
                _pointerItems[3] = 0;
            }
           
        }
        private void ChangePositionProduct(int goTo)
        {
            /*if i'm not on the empty shop*/
            if (_dataBase.shops.Count > _pointerItems[0])
            {
                /*if i'm not on the empty case*/
                if (_dataBase.shops[_pointerItems[0]].storage.Count > _pointerItems[1])
                {
                    /*check for possible to move*/
                    if ((_pointerItems[2] + goTo) >= 0 && (goTo + _pointerItems[2]) <= _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage.Capacity-1)
                    {
                        _pointerItems[2] = _pointerItems[2] + goTo;
                        _pointerItems[3] = 0;
                    }                
                }                
            }
        }

        private void ChangePositionMenu(int goTo)
        {
            _menu = MakeMenu();
            if (goTo + _pointerItems[3] >= 0 && _menu.Count > _pointerItems[3] + goTo)
            {
                _pointerItems[3] = _pointerItems[3] + goTo;
            }
        }
    }
}