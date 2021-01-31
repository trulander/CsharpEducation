using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    class ControllerGame
    {
        private View _view;
        private UnitController _unitController;
        private Unit _userObj;
        private ConsoleModifiers _shoot = ConsoleModifiers.Control;
        public ControllerGame(View view, UnitController unitController)
        {
            _view = view;
            _unitController = unitController;
            for (int i = 0; i < _unitController.Units.Length; i++)/* i need to find user object of object array*/
            {
                if (_unitController.Units[i].Type == "Player")
                {
                    _userObj = _unitController.Units[i];
                } 
            }
            View.PrintLine("ControllerGame initialised");
        }

        internal bool ReadKey()
        {
            Console.TreatControlCAsInput = true;/* drop default action when we're using modification key (ctrl, shift,alt)*/
            ConsoleKeyInfo key = Console.ReadKey();
            string textAction = "";
            if (key.Modifiers == _shoot)
            {
                textAction = "Shooting ";
            }
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    textAction += "up";
                    break;
                case ConsoleKey.DownArrow:
                    textAction += "down";
                    break;
                case ConsoleKey.RightArrow:
                    textAction += "right";
                    break;
                case ConsoleKey.LeftArrow:
                    textAction += "left";
                    break;
                case ConsoleKey.Escape:
                    return false;
                    break;
                default:
                    break;
            }
            _view.ShowKeyPressed(textAction);
            return true;
        }
    }
}
