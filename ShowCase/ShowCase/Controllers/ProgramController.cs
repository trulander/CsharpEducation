using System;
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
        public ProgramController(DataBase dataBase)
        {
            /* 0 Pointer on a shop*/
            _pointerItems[0] = 0;
            /* 1 Pointer on a case*/
            _pointerItems[1] = 0;
            /* 2 Pointer on a product*/
            _pointerItems[2] = 0;
            
            _dataBase = dataBase;
            _view = new View();
            _modelController = new ModelController(_dataBase);
            DemoData demoData = new DemoData(_modelController,_dataBase);
            _view.MapGenerate(_dataBase, _pointerItems);
            Loop();
        }

        private void Loop()
        {
            bool _continue = true;
            while (_continue)
            {
                _continue = ReadKey();
            }
        }

        private bool ReadKey()
        {
            Console.TreatControlCAsInput = true;/* drop default action when we're using modification key (ctrl, shift,alt) */
            Console.CursorVisible = false;/* hide cursor */
            ConsoleKeyInfo key = Console.ReadKey(true);
            
            switch ((int)key.Key)
            {
                case (int)DataBase.KeyData.UP:
                    ChangePositionShop(-1);
                    break;
                case (int)DataBase.KeyData.DOWN:
                    ChangePositionShop(1);
                    break;
                case (int)DataBase.KeyData.RIGHT:
                    ChangePositionCase(1);
                    break;
                case (int)DataBase.KeyData.LEFT:
                    ChangePositionCase(-1);
                    break;
                case (int)DataBase.KeyData.EXIT:
                    Console.WriteLine("Exit");
                    return false;
                    break;
                default:
                    return true;
                    break;
            }
            _view.MapGenerate(_dataBase, _pointerItems);
            return true;
        }

        private void ChangePositionShop(int goTo)
        {
            if ((_pointerItems[0] + goTo) >= 0 && (goTo + _pointerItems[0]) <= _dataBase.Shops.Count-1)
            {
                _pointerItems[0] = _pointerItems[0] + goTo;
                if (_pointerItems[1] > _dataBase.Shops[_pointerItems[0]].Storage.Capacity-1)
                {
                    _pointerItems[1] = _dataBase.Shops[_pointerItems[0]].Storage.Capacity - 1;
                }
            }
        }

        private void ChangePositionCase(int goTo)
        {
            if ((_pointerItems[1] + goTo) >= 0 && (goTo + _pointerItems[1]) <= _dataBase.Shops[_pointerItems[0]].Storage.Capacity-1)
            {
                _pointerItems[1] = _pointerItems[1] + goTo;
            }
        }
    }
}