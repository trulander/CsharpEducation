using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    /* class for wumpus */
    public class Wumpus : Unit
    {
        public const string TEXTWARNING = "you feel bad smell";
        public Wumpus(Map map) : base(map)
        {
            _map = map;
            Marker = "W";
            Color = ConsoleColor.Red;
            Spawn();
            View.PrintLine("One wumpus created.", Color);
        }
    }
}
