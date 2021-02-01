using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    /* class for hole */
    class Hole : Unit
    {
        public const string TEXTWARNING = "You feel the draft";
        public Hole(Map map) : base(map)
        {
            _map = map;
            Marker = "O";
            Color = ConsoleColor.Magenta;
            Spawn();
            View.PrintLine("One hole created.", Color);
        }
    }
}
