using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    class Bat : Unit
    {
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
            throw new NotImplementedException();
        }
    }
}
