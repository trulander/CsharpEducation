using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    class Wumpus : Unit
    {
        public Wumpus(Map map) : base(map)
        {
            _map = map;
            Marker = "W";
            Color = ConsoleColor.Red;
            Spawn();
            View.PrintLine("One wumpus created.", Color);
        }

        //public void ToGo()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
