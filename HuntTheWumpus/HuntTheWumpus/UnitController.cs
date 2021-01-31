using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    class UnitController
    {
        public Unit[] Units;
        private int _countUnits;
        private Map _map;
        public UnitController(int player,int bat, int wumpus, int hole, Map map)
        {
            _countUnits = player + bat + wumpus + hole;
            Units = new Unit[player + bat + wumpus + hole];
            _map = map;

            int pointerOfUnits = 0;
            for (int i = 0; i < player; i++)
            {
                Units[pointerOfUnits] = new Player(_map);
                pointerOfUnits++;
            }
            for (int i = 0; i < bat; i++)
            {
                Units[pointerOfUnits] = new Bat(_map);
                pointerOfUnits++;
            }
            for (int i = 0; i < wumpus; i++)
            {
                Units[pointerOfUnits] = new Wumpus(_map);
                pointerOfUnits++;
            }
            for (int i = 0; i < hole; i++)
            {
                Units[pointerOfUnits] = new Hole(_map);
                pointerOfUnits++;
            }

            View.PrintLine("UnitController initialised: " + _countUnits + " units.");
        }
    }
}
