using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    /* class for player */
    public class Player : Unit
    {
        public string FireTo { get; set; }
        public Player(Map map) : base(map)
        {
            _map = map;
            Marker = "+";
            Color = ConsoleColor.Green;
            Type = "Player";
            Spawn();
            View.PrintLine("One player created.", Color);
        }

        /* method for make the step*/
        public bool ToGo(int action, bool shoot)
        {
            if (shoot)
            {
                return ToShoot(action);
            }
            else
            {
                return base.ToGo(action);
            }
            return false;
        }

        /* method for make a shoot*/
        public bool ToShoot(int action)
        {
            switch (action)
            {
                case UP:
                    TargetPositionX = PositionX - 1;
                    TargetPositionY = PositionY;
                    if (_map.IsCursorCorrect(TargetPositionX, PositionY))
                    {
                        FireTo = _map.WhoIsIt(TargetPositionX, PositionY);
                        return false;
                    }
                    break;
                case DOWN:
                    TargetPositionX = PositionX + 1;
                    TargetPositionY = PositionY;
                    if (_map.IsCursorCorrect(TargetPositionX, PositionY))
                    {
                        FireTo = _map.WhoIsIt(TargetPositionX, PositionY);
                        return false;
                    }
                    break;
                case RIGHT:
                    TargetPositionY = PositionY + 1;
                    TargetPositionX = PositionX;
                    if (_map.IsCursorCorrect(PositionX, TargetPositionY))
                    {
                        FireTo = _map.WhoIsIt(PositionX, TargetPositionY);
                        return false;
                    }
                    break;
                case LEFT:
                    TargetPositionY = PositionY - 1;
                    TargetPositionX = PositionX;
                    if (_map.IsCursorCorrect(PositionX, TargetPositionY))
                    {
                        FireTo = _map.WhoIsIt(PositionX, TargetPositionY);
                        return false;
                    }
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}
