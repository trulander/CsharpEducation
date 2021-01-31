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
        //public void ToGo() 
        //{ 
        
        //}
    }
}
