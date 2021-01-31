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

        public void ToGo(int action, bool shoot)
        {
            if (shoot)
            {
                ToShoot(action);
            }
            else
            {
                base.ToGo(action);
            }
            
        }
        public void ToShoot(int action)
        {

        }
    }
}
