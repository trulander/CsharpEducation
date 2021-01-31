using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    class Hole : Unit
    {
        public Hole(Map map) : base(map)
        {
            _map = map;
            Marker = "O";
            Color = ConsoleColor.Magenta;
            Spawn();
            View.PrintLine("One hole created.", Color);
        }

        public void ToGo()
        {
            throw new NotImplementedException();
        }
    }
}
