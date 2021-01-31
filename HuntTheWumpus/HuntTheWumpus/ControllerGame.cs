using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    class ControllerGame
    {
        private View _view;
        private UnitController _unitController;
        private ConsoleModifiers _shoot = ConsoleModifiers.Control;
        public ControllerGame(View view, UnitController unitController)
        {
            _view = view;
            _unitController = unitController;
            View.PrintLine("ControllerGame initialised");
        }

        public bool ReadKey()
        {
            Console.TreatControlCAsInput = true;/* drop default action when we're using modification key (ctrl, shift,alt)*/
            ConsoleKeyInfo key = Console.ReadKey();
            string textAction = "";
            int action;
            bool shoot = false;
            if (key.Modifiers == _shoot)
            {
                textAction = "Shooting ";
                shoot = true;
            }
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    textAction += "up";
                    action = Unit.UP;
                    break;
                case ConsoleKey.DownArrow:
                    textAction += "down";
                    action = Unit.DOWN;
                    break;
                case ConsoleKey.RightArrow:
                    textAction += "right";
                    action = Unit.RIGHT;
                    break;
                case ConsoleKey.LeftArrow:
                    textAction += "left";
                    action = Unit.LEFT;
                    break;
                case ConsoleKey.Escape:
                    return false;
                    break;
                default:
                    return true;
                    break;
            }
            _unitController.Players[0].ToGo(action, shoot);
            _unitController.Wumpuses[0].AutoGo();
            _view.ShowKeyPressed(textAction);
            _view.MapReload();
            return true;
        }

        public void CheckNighbor()
        {

        }
    }
}
