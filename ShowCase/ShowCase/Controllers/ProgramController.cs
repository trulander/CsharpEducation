using System;
using System.Collections.Generic;
using System.Linq;
using ShowCase.Interfases;
using ShowCase.Models;

namespace ShowCase.Controllers
{
    public delegate void DelegateNotification(string message);
    public class ProgramController
    {
        private DelegateNotification _notifier = message => { };
        private DataBase _dataBase = DataBase.GetInstance();
        private ModelController _modelController;
        private IView _view;
        private Dictionary<int, string> _menu;
        private int[] _pointerItems = new int[4];
        public ProgramController(IView view)
        {
            /* 0 Pointer on a shop*/
            _pointerItems[0] = 0;
            /* 1 Pointer on a case*/
            _pointerItems[1] = 0;
            /* 2 Pointer on a product*/
            _pointerItems[2] = 0;
            /* 3 Pointer on a point of menu*/
            _pointerItems[3] = 0;

            _view = view;
            
            _modelController = new ModelController(_view);

            /*
             * Setup delegate chain.
             * The chain include database - programcontroller.
             * It needs for connecting local part of the program and server part.
             * Database in the program has singleton realization and has all data for both parts of the program.
             */
            _notifier += NotificationUpdate;
            _notifier += _view.NotifiedMessage;
            _notifier += _dataBase.SetNotifier(_notifier);
        }
        
        /// <summary>
        /// Method for delegate notification
        /// </summary>
        /// <param name="message"></param>
        private void NotificationUpdate(string message)
        {
            _view.Clear();
            _menu = MakeMenu();
            _view.MapGenerate(_pointerItems, _menu);
        }
        public void StartProgram()
        {
            _menu = MakeMenu();
            _view.MapGenerate(_pointerItems, _menu);
            Loop();
        }
        
        /// <summary>
        /// Main loop the programm
        /// </summary>
        private void Loop()
        {
            bool continue_ = true;
            while (continue_)
            {
                continue_ = Step();
            }
        }
        /// <summary>
        /// One step program of main loop
        /// </summary>
        /// <returns>if false it mean user wanted to exit from the program</returns>
        public bool Step()
        {
            var result = ReadKey();
            _menu = MakeMenu();
            _view.MapGenerate(_pointerItems, _menu);
            return result;
        }
        /// <summary>
        /// Button handing
        /// </summary>
        /// <returns>if true we have to continue, if false we have to close the program</returns>
        private bool ReadKey()
        {
            var key = _view.ReadKey();
            /*If i have hold "shift" button, i can to change position cursor inside a case and in menu*/
            if (key[0] != 0 && key[1] != 0)
            {
                switch (key[0])
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
                switch (key[0])
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
                        _view.PrintLine("Exit");
                        return false;
                    default:
                        return true;
                }
            }
            return true;
        }

        /// <summary>
        /// Router actions for menu
        /// </summary>
        private void MenuActions()
        {
            string resultText = null;
            switch (_menu.Keys.ElementAt(_pointerItems[3]))
            {
                case (int)DataBase.Actions.EditSizeShop:
                    _modelController.EditSize(_dataBase.shops[_pointerItems[0]]);
                    resultText = "Shop was resized";
                    break;
                case (int)DataBase.Actions.EditSizeCase:
                    _modelController.EditSize(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]]);
                    resultText = "Case was resized";
                    break;
                case (int)DataBase.Actions.RemoveShop:
                    _modelController.Remove(_dataBase.shops[_pointerItems[0]]);
                    resultText = "Shop was removed";
                    break;
                case (int)DataBase.Actions.RemoveCase:
                    _modelController.Remove(_dataBase.shops[_pointerItems[0]], _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]]);
                    resultText = "Case was removed";
                    break;
                case (int)DataBase.Actions.RemoveProduct:
                    _modelController.Remove(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]], _dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]]);
                    resultText = "Product was removed";
                    break;
                case (int)DataBase.Actions.AddShop:
                    _modelController.Create();
                    resultText = "Shop was created";
                    break;
                case (int)DataBase.Actions.AddCase:
                    _modelController.Create(_dataBase.shops[_pointerItems[0]]);
                    resultText = "Case was created";
                    break;
                case (int)DataBase.Actions.AddProduct:
                    _modelController.Create(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]]);
                    resultText = "Product was created";
                    break;
                case (int)DataBase.Actions.EditNameProduct:
                    _modelController.Rename(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]]);
                    resultText = "Product was renamed";
                    break;

                case (int)DataBase.Actions.EditNameShop:
                    _modelController.Rename(_dataBase.shops[_pointerItems[0]]);
                    resultText = "Shop was renamed";
                    break;
                case (int)DataBase.Actions.EditNameCase:
                    _modelController.Rename(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]]);
                    resultText = "Case was renamed";
                    break;
                case (int)DataBase.Actions.EditCostProduct:
                    _modelController.ChangeCost(_dataBase.shops[_pointerItems[0]].storage[_pointerItems[1]].storage[_pointerItems[2]]);
                    resultText = "Product's cost was changed";
                    break;
            }
            _pointerItems[3] = 0;
            _dataBase.MakeNotification(resultText);
            //_view.Clear();
        }
        /// <summary>
        /// Generator menu
        /// </summary>
        /// <returns>Dictionary<action,text for action></returns>
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
        
        /// <summary>
        /// Change position for virtual pointer for chose Shop.
        /// That can see on the view
        /// </summary>
        /// <param name="goTo">+/-1</param>
        private void ChangePositionShop(int goTo)
        {
            if ((_pointerItems[0] + goTo) >= 0 && (goTo + _pointerItems[0]) <= _dataBase.shops.Capacity-1)
            {
                _pointerItems[0] = _pointerItems[0] + goTo;
                ChangePositionCase(0);
            }
        }
        
        /// <summary>
        /// Change position for virtual pointer for chose Case.
        /// That can see on the view
        /// </summary>
        /// <param name="goTo">+/-1</param>
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
        /// <summary>
        /// Change position for virtual pointer inside Case for chose product or empty place.
        /// That can see on the view
        /// </summary>
        /// <param name="goTo">+/-1</param>
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

        /// <summary>
        /// Change position for virtual pointer inside menu.
        /// That can see on the view
        /// </summary>
        /// <param name="goTo">+/-1</param>
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