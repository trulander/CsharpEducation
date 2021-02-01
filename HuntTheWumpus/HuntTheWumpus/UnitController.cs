using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    /**/
    class UnitController
    {
        public Player[] Players;
        public Bat[] Bats;
        public Wumpus[] Wumpuses;
        public Hole[] Holes;

        private int _countUnits;
        private Map _map;
        public UnitController(int player,int bat, int wumpus, int hole, Map map)
        {
            _countUnits = player + bat + wumpus + hole;
            _map = map;

            Players = new Player[player];
            Bats = new Bat[bat];
            Wumpuses = new Wumpus[wumpus];
            Holes = new Hole[hole];

            /* Generate game's objects*/
            for (int i = 0; i < player; i++)
            {
                Players[i] = new Player(_map);
            }
            for (int i = 0; i < bat; i++)
            {
                Bats[i] = new Bat(_map);
            }
            for (int i = 0; i < wumpus; i++)
            {
                Wumpuses[i] = new Wumpus(_map);
            }
            for (int i = 0; i < hole; i++)
            {
                Holes[i] = new Hole(_map);
            }

            View.PrintLine("UnitController initialised: " + _countUnits + " units.");
        }
    }
}
