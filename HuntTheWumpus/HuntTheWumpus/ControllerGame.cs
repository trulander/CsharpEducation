using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    /* Class for game logic*/
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

        /* method for return object wumpus by coordinate x y*/
        private Wumpus GetWumpusObject(int x, int y)
        {
            for (int i = 0; i < _unitController.Wumpuses.Length; i++)
            {
                if (_unitController.Wumpuses[i].PositionX == x && _unitController.Wumpuses[i].PositionY == y)
                {
                    return _unitController.Wumpuses[i];
                }
            }
            return null;
        }

        /* method for return object bat by coordinate x y*/
        private Bat GetBatObject(int x, int y)
        {
            for (int i = 0; i < _unitController.Bats.Length; i++)
            {
                if (_unitController.Bats[i].PositionX == x && _unitController.Bats[i].PositionY == y)
                {
                    return _unitController.Bats[i];
                }
            }
            return null;
        }

        /* method for return type of object by marker on the map */
        private Unit WhoIsItByMarker(string marker)
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

        /* Main method for reading the buttons what was pushed user and base logic what we have to do every step */
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

            /* player or players(futute maybe multiplayer mode) is/are going*/
            if(!_unitController.Players[0].ToGo(action, shoot))
            {
                if (shoot && WhoIsItByMarker(_unitController.Players[0].FireTo) is Wumpus)
                {
                    GetWumpusObject(_unitController.Players[0].TargetPositionX, _unitController.Players[0].TargetPositionY).Destroy();
                    {
                        bool finish = true;
                        for (int i = 0; i < _unitController.Wumpuses.Length; i++)
                        {
                            if (_unitController.Wumpuses[i].Alive)
                            {
                                finish = false;
                                break;
                            }
                        }
                        if (finish)
                        {
                            return false;
                        }
                    }
                }

                /* if player meet the wumpus or hole on the previous step, player have to be die */
                if (WhoIsItByMarker(_unitController.Players[0].Meet) is Wumpus || WhoIsItByMarker(_unitController.Players[0].Meet) is Hole)
                {
                    _unitController.Players[0].Destroy();
                    return false;
                }

                /* if player meet the bat on the previous step, he has to be teleportate together the bat */
                if (WhoIsItByMarker(_unitController.Players[0].Meet) is Bat)
                {
                    GetBatObject(_unitController.Players[0].TargetPositionX, _unitController.Players[0].TargetPositionY).ToGo(_unitController.Players[0]);
                }
            }

            {/* wumpuses are going*/
                for (int i = 0; i < _unitController.Wumpuses.Length; i++)
                {
                    if (_unitController.Wumpuses[i].Alive)
                    {
                        Random toGo = new Random();
                        bool complete = true;
                        do
                        {
                            if (complete = !_unitController.Wumpuses[i].ToGo(toGo.Next(0, 4)) && WhoIsItByMarker(_unitController.Wumpuses[i].Meet) is Player)
                            {
                                _unitController.Players[0].Alive = false;
                                return false;
                            }
                        } while (complete);
                    }
                }
            }

            _view.ShowKeyPressed(textAction);
            _view.MapReload(!Program.IsVisibleGameObject ? _unitController.Players[0].Marker : "");
            ChechWarning();
            return true;
        }

        /* make result of the end game and show it on the screen*/
        public void MakeResultOfGame()
        {
            bool woompusAlive = false;
            for (int i = 0; i < _unitController.Wumpuses.Length; i++)
            {
                if (_unitController.Wumpuses[i].Alive)
                {
                    woompusAlive = true;
                }
            }

            if (_unitController.Players[0].Alive && woompusAlive)
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
            View.PrintLine("Press any key to close the window.");
            Console.ReadLine();
        }

        /* chech who around me */
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
