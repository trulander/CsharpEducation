using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    public class Unit
    {
        public const int UP = 0;
        public const int DOWN = 1;
        public const int RIGHT = 2;
        public const int LEFT = 3;
        public const string TEXTWARNING = "";

        public Map _map;
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

        }

        public string[] WhoIsAround()
        {
            return _map.WhoIsAround(PositionX, PositionY);
        }

        public void Destroy()
        {
            _map.Busy[PositionX, PositionY] = null;
            _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
            Alive = false;
        }

        protected bool SaveNewPosition()
        {
            if (_map.IsCursorCorrect(TargetPositionX, TargetPositionY))
            {
                if (_map.IsCursorFree(TargetPositionX, TargetPositionY))
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
