using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    /* class for map the game */
    public class Map
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public string[,] Busy { get; set; }
        public ConsoleColor[,] BusyColor { get; set; }
        public Map(int x, int y)
        {
            SizeX = x;
            SizeY = y;
            Busy = new string[SizeX, SizeY];
            BusyColor = new ConsoleColor[SizeX, SizeY];
            View.PrintLine("Map initialised: " + SizeX + " x " + SizeY + " size.");
        }

        /* method for check free fields of the map by coordinate x y */
        public bool IsCursorFree(int x, int y)
        {
            if (Busy[x, y] == null)
            {
                return true;
            }
            return false;
        }

        /* method for check correct coordinate x y or not */
        public bool IsCursorCorrect(int x, int y)
        {
            if (x >= 0 && x <= SizeX - 1 && y >= 0 && y <= SizeY - 1)
            {
                return true;
            }
            return false;
        }

        /* method for show who stand on the map by coordinate x y */
        public string WhoIsIt(int x, int y)
        {
            if (Busy[x, y] != null)
            {
                return Busy[x, y];
            }
            return "";
        }

        /* method for show who stand around me */
        public string[] WhoIsAround(int x, int y)
        {
            string[] result = new string[9];
            int count = 0;
            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    result[count] = IsCursorCorrect(i, j) ? WhoIsIt(i, j) : "";
                    count++;
                }
            }
            return result;
        }
    }
}
