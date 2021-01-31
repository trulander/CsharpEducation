using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    class Player : Unit
    {
        public Player(Map map) : base(map)
        {
            _map = map;
            Marker = "+";
            Color = ConsoleColor.Green;
            Type = "Player";
            Spawn();
            View.PrintLine("One player created.", Color);
        }

        public void ToGo(ConsoleKeyInfo key)
        {
            string textAction = "";
            if (key.Modifiers == ConsoleModifiers.Control)
            {
                textAction = "Shooting ";
            }
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (PositionX - 1 >= 0 && _map.Busy[PositionX - 1, PositionY] == null)
                    {
                        _map.Busy[PositionX - 1, PositionY] = Marker;
                        _map.BusyColor[PositionX - 1, PositionY] = Color;
                        _map.Busy[PositionX, PositionY] = null;
                        _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                        PositionX = PositionX - 1;
                    }
                    
                    break;
                case ConsoleKey.DownArrow:
                    if (PositionX + 1 < _map.SizeX && _map.Busy[PositionX + 1, PositionY] == null)
                    {
                        _map.Busy[PositionX + 1, PositionY] = Marker;
                        _map.BusyColor[PositionX + 1, PositionY] = Color;
                        _map.Busy[PositionX, PositionY] = null;
                        _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                        PositionX = PositionX + 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (PositionY + 1 < _map.SizeY && _map.Busy[PositionX, PositionY + 1] == null)
                    {
                        _map.Busy[PositionX, PositionY + 1] = Marker;
                        _map.BusyColor[PositionX, PositionY + 1] = Color;
                        _map.Busy[PositionX, PositionY] = null;
                        _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                        PositionY = PositionY + 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (PositionY - 1 >= 0 && _map.Busy[PositionX, PositionY - 1] == null)
                    {
                        _map.Busy[PositionX, PositionY - 1] = Marker;
                        _map.BusyColor[PositionX, PositionY - 1] = Color;
                        _map.Busy[PositionX, PositionY] = null;
                        _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
                        PositionY = PositionY - 1;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
