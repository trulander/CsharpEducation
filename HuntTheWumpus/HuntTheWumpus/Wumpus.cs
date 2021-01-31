using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    class Wumpus : Unit
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

        public bool AutoGo()
        {
            Random toGo = new Random();
            bool complete = false;

            do
            {
                complete = ToGo(toGo.Next(0, 4));
            } while (!complete);

            return false;
        }
        //public void ToGo()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
