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
            string[] neighborAround;
            string[] warning;
            int counter = 0;
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

            if(_unitController.Players[0].ToGo(action, shoot))
            {
                return false;
            }

            if (_unitController.Wumpuses[0].AutoGo())
            {
                return false;
            }

            neighborAround = _unitController.Players[0].WhoIsAround();
            for (int i = 0; i < neighborAround.Length; i++)
            {
                if (neighborAround[i] != "")
                {
                    counter++;
                }
            }
            warning = new string[counter];
            counter = 0;
            for (int i = 0; i < neighborAround.Length; i++)
            {
                if (neighborAround[i] != "")
                {
                    if (_unitController.Bats[0].Marker == neighborAround[i])
                    {
                        warning[counter] = Bat.TEXTWARNING;
                    }
                    if (_unitController.Holes[0].Marker == neighborAround[i])
                    {
                        warning[counter] = Hole.TEXTWARNING;
                    }
                    if (_unitController.Wumpuses[0].Marker == neighborAround[i])
                    {
                        warning[counter] = Wumpus.TEXTWARNING;
                    }
                    counter++;
                }
                //neighborAround
            }

            _view.ShowWarning(warning);
            _view.ShowKeyPressed(textAction);
            _view.MapReload();
            
            return true;
        }

        public void CheckNighbor()
        {

        }
    }
}
