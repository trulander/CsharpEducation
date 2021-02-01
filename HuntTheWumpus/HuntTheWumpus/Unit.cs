using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    /* main class for game's objects */
    public class Unit
    {
        public const int UP = 0;
        public const int DOWN = 1;
        public const int RIGHT = 2;
        public const int LEFT = 3;
        public const string TEXTWARNING = "";

        protected Map _map;
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int TargetPositionX { get; set; }
        public int TargetPositionY { get; set; }
        public string Marker { get; set; }
        public bool Alive { get; set; }
        public string Type { get; set; }
        public ConsoleColor Color { get; set; }
        public string Meet { get; set; }
        public Unit(Map map)
        {
            _map = map;
        }
        /* method for auto placement the object on a map of the game */
        public void Spawn() 
        {
            Random randomX = new Random();
            Random randomY = new Random();
            bool complete = false;
            int x, y;
            do
            {
                x = randomX.Next(0, _map.SizeX);
                y = randomY.Next(0, _map.SizeY);
                complete = _map.IsCursorFree(x, y);
            } while (!complete);

            _map.Busy[x, y] = Marker;
            _map.BusyColor[x, y] = Color;
            PositionX = x;
            PositionY = y;
            TargetPositionX = PositionX;
            TargetPositionY = PositionY;
            Alive = true;

        }

        /* method as provider between  map object and current object, i need to use method from map's object */
        public string[] WhoIsAround()
        {
            return _map.WhoIsAround(PositionX, PositionY);
        }

        /* method for deleting the object from the game */
        public void Destroy()
        {
            _map.Busy[PositionX, PositionY] = null;
            _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
            Alive = false;
        }

        /* method for save new position the object on the map*/
        public bool SaveNewPosition(bool important = false)
        {
            if (_map.IsCursorCorrect(TargetPositionX, TargetPositionY))
            {
                if (_map.IsCursorFree(TargetPositionX, TargetPositionY) || important)
                {
                    _map.Busy[TargetPositionX, TargetPositionY] = Marker;
                    _map.BusyColor[TargetPositionX, TargetPositionY] = Color;
                    _map.Busy[PositionX, PositionY] = null;
                    _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                    PositionX = TargetPositionX;
                    PositionY = TargetPositionY;
                    return true;
                }
                else
                {
                    Meet = _map.WhoIsIt(TargetPositionX, TargetPositionY);
                    //TargetPositionX = PositionX;
                    //TargetPositionY = PositionY;
                    return false;
                }
            }
            TargetPositionX = PositionX;
            TargetPositionY = PositionY;
            return false;
        }

        /* method for make the step*/
        public bool ToGo(int key) 
        {
            switch (key)
            {
                case UP:
                    TargetPositionX = PositionX - 1;
                    TargetPositionY = PositionY;
                    return SaveNewPosition();
                    break;
                case DOWN:
                    TargetPositionX = PositionX + 1;
                    TargetPositionY = PositionY;
                    return SaveNewPosition();
                    break;
                case RIGHT:
                    TargetPositionY = PositionY + 1;
                    TargetPositionX = PositionX;
                    return SaveNewPosition();
                    break;
                case LEFT:
                    TargetPositionY = PositionY - 1;
                    TargetPositionX = PositionX;
                    return SaveNewPosition();
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
