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
        public string Marker { get; set; }
        public bool Alive { get; set; }
        public string Type { get; set; }
        public ConsoleColor Color { get; set; }
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

        }

        public string[] WhoIsAround()
        {
            return _map.WhoIsAround(PositionX, PositionY);
        }
        public bool ToGo(int key) 
        {
            switch (key)
            {
                case UP:
                    if (_map.IsCursorCorrect(PositionX - 1, PositionY))
                    {
                        if (_map.IsCursorFree(PositionX - 1, PositionY))
                        {
                            _map.Busy[PositionX - 1, PositionY] = Marker;
                            _map.BusyColor[PositionX - 1, PositionY] = Color;
                            _map.Busy[PositionX, PositionY] = null;
                            _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                            PositionX = PositionX - 1;
                            return true;
                        }
                    }

                    break;
                case DOWN:
                    if (_map.IsCursorCorrect(PositionX + 1, PositionY))
                    {
                        if (_map.IsCursorFree(PositionX + 1, PositionY))
                        {
                            _map.Busy[PositionX + 1, PositionY] = Marker;
                            _map.BusyColor[PositionX + 1, PositionY] = Color;
                            _map.Busy[PositionX, PositionY] = null;
                            _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                            PositionX = PositionX + 1;
                            return true;
                        }
                    }
                    break;
                case RIGHT:
                    if (_map.IsCursorCorrect(PositionX, PositionY + 1))
                    {
                        if (_map.IsCursorFree(PositionX, PositionY + 1))
                        {
                            _map.Busy[PositionX, PositionY + 1] = Marker;
                            _map.BusyColor[PositionX, PositionY + 1] = Color;
                            _map.Busy[PositionX, PositionY] = null;
                            _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                            PositionY = PositionY + 1;
                            return true;
                        }
                    }
                    break;
                case LEFT:
                    if (_map.IsCursorCorrect(PositionX, PositionY - 1))
                    {
                        if (_map.IsCursorFree(PositionX, PositionY - 1))
                        {
                            _map.Busy[PositionX, PositionY - 1] = Marker;
                            _map.BusyColor[PositionX, PositionY - 1] = Color;
                            _map.Busy[PositionX, PositionY] = null;
                            _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                            PositionY = PositionY - 1;
                            return true;
                        }
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
