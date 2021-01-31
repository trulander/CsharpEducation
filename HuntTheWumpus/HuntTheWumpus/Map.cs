using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    public class Map
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public string[,] Busy;
        public ConsoleColor[,] BusyColor;
        public Map(int x, int y)
        {
            SizeX = x;
            SizeY = y;
            Busy = new string[SizeX, SizeY];
            BusyColor = new ConsoleColor[SizeX, SizeY];
            View.PrintLine("Map initialised: " + SizeX + " x " + SizeY + " size.");
        }
    }
}
