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

        public bool ToGo(int action, bool shoot)
        {
            if (shoot)
            {
                ToShoot(action);
            }
            else
            {
                return base.ToGo(action);
                //if (base.ToGo(action))
                //{
                //    View.DebugView("could to go");
                //}
                //else
                //{
                //    View.DebugView("could'n to go");
                //}
                // _map.WhoIsAround(PositionX, PositionY);
            }
            return false;
        }
        public bool ToShoot(int action)
        {
            return true;
        }
    }
}
