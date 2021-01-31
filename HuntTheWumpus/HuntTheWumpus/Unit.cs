using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    public class Unit
    {
        public Map _map;
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Marker { get; set; }
        public bool Went { get; set; }
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
            int x = randomX.Next(0, _map.SizeX);
            int y = randomY.Next(0, _map.SizeY);
            _map.Busy[x, y] = Marker;
            _map.BusyColor[x, y] = Color;
            PositionX = x;
            PositionY = y;
        }

        public const int UP = 0;
        public const int DOWN = 1;
        public const int RIGHT = 2;
        public const int LEFT = 3;

        public void AutoGo()
        {
            Random toGo = new Random();
            bool complete = false;

            do
            {
                complete = ToGo(toGo.Next(0, 4));
            } while (!complete);
        }
        public bool ToGo(int key) 
        {
            switch (key)
            {
                case UP:
                    if (PositionX - 1 >= 0 && _map.Busy[PositionX - 1, PositionY] == null)
                    {
                        _map.Busy[PositionX - 1, PositionY] = Marker;
                        _map.BusyColor[PositionX - 1, PositionY] = Color;
                        _map.Busy[PositionX, PositionY] = null;
                        _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                        PositionX = PositionX - 1;
                        return true;
                    }

                    break;
                case DOWN:
                    if (PositionX + 1 < _map.SizeX && _map.Busy[PositionX + 1, PositionY] == null)
                    {
                        _map.Busy[PositionX + 1, PositionY] = Marker;
                        _map.BusyColor[PositionX + 1, PositionY] = Color;
                        _map.Busy[PositionX, PositionY] = null;
                        _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                        PositionX = PositionX + 1;
                        return true;
                    }
                    break;
                case RIGHT:
                    if (PositionY + 1 < _map.SizeY && _map.Busy[PositionX, PositionY + 1] == null)
                    {
                        _map.Busy[PositionX, PositionY + 1] = Marker;
                        _map.BusyColor[PositionX, PositionY + 1] = Color;
                        _map.Busy[PositionX, PositionY] = null;
                        _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                        PositionY = PositionY + 1;
                        return true;
                    }
                    break;
                case LEFT:
                    if (PositionY - 1 >= 0 && _map.Busy[PositionX, PositionY - 1] == null)
                    {
                        _map.Busy[PositionX, PositionY - 1] = Marker;
                        _map.BusyColor[PositionX, PositionY - 1] = Color;
                        _map.Busy[PositionX, PositionY] = null;
                        _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                        PositionY = PositionY - 1;
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
