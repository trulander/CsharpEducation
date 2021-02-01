using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    class Bat : Unit
    {
        public const string TEXTWARNING = "you hear the rustle";
        public Bat(Map map) : base(map)
        {
            _map = map;
            Marker = "V";
            Color = ConsoleColor.Yellow;
            Spawn();
            View.PrintLine("One bat created.", Color);
        }

        public void ToGo()
        {
            _map.Busy[PositionX, PositionY] = null;
            _map.BusyColor[PositionX, PositionY] = ConsoleColor.White;
            Spawn();
        }
    }
}
