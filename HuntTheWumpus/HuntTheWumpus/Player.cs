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

        public void ToGo(ConsoleKeyInfo key)
        {
            string textAction = "";
            if (key.Modifiers == ConsoleModifiers.Control)
            {
                textAction = "Shooting ";
            }
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    textAction += "up";
                    break;
                case ConsoleKey.DownArrow:
                    textAction += "down";
                    break;
                case ConsoleKey.RightArrow:
                    textAction += "right";
                    break;
                case ConsoleKey.LeftArrow:
                    textAction += "left";
                    break;
                default:
                    break;
            }
        }
    }
}
