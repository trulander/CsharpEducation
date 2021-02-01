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
            Console.TreatControlCAsInput = true;/* drop default action when we're using modification key (ctrl, shift,alt) */
            Console.CursorVisible = false;/* hide cursor */
            ConsoleKeyInfo key = Console.ReadKey(true);
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

            if(!_unitController.Players[0].ToGo(action, shoot))
            {
                if (WhoIsItByMarker(_unitController.Players[0].Meet) is Wumpus)
                {
                    _unitController.Players[0].Alive = false;
                    return false;
                }
            }

            {
                Random toGo = new Random();
                bool complete = true;

                do
                {
                    
                    if (complete = !_unitController.Wumpuses[0].ToGo(toGo.Next(0, 4)) && WhoIsItByMarker(_unitController.Wumpuses[0].Meet) is Player)
                    {
                        _unitController.Players[0].Alive = false;
                        return false;
                    }
                } while (complete);
            }




            _view.ShowKeyPressed(textAction);
            _view.MapReload();
            ChechWarning();
            return true;
        }

        public void MakeResultOfGame()
        {
            if (!_unitController.Players[0].Alive && !_unitController.Wumpuses[0].Alive)
            {
                _view.ResultOfGame("NObody");
            }
            else if (_unitController.Players[0].Alive)
            {
                _view.ResultOfGame("Player");
            }
            else
            {
                _view.ResultOfGame("Wumpus");
            }
            
        }
        public Unit WhoIsItByMarker(string marker)
        {
            if (_unitController.Bats[0].Marker == marker)
            {
                return _unitController.Bats[0];
            }
            if (_unitController.Holes[0].Marker == marker)
            {
                return _unitController.Holes[0];
            }
            if (_unitController.Wumpuses[0].Marker == marker)
            {
                return _unitController.Wumpuses[0];
            }
            if (_unitController.Players[0].Marker == marker)
            {
                return _unitController.Players[0];
            }
            return null;
        }
        public void ChechWarning()
        {
            string[] neighborAround = _unitController.Players[0].WhoIsAround();
            string[] warning = new string[3]; ;

             for (int i = 0; i < neighborAround.Length; i++)
            {
                if (neighborAround[i] != "")
                {
                    if (WhoIsItByMarker(neighborAround[i]) is Bat)
                    {
                        warning[0] = Bat.TEXTWARNING;
                    }
                    if (WhoIsItByMarker(neighborAround[i]) is Hole)
                    {
                        warning[1] = Hole.TEXTWARNING;
                    }
                    if (WhoIsItByMarker(neighborAround[i]) is Wumpus)
                    {
                        warning[2] = Wumpus.TEXTWARNING;
                    }
                }
            }
            Array.Sort(warning);
            Array.Reverse(warning);
            _view.ShowWarning(warning);
        }
    }
}
