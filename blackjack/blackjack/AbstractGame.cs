using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack
{
    public abstract class AbstractGame
    {
        /* Custom method for show to the screen logs the game */
        public void ShowLog(string value)
        {
            Console.WriteLine(value);
        }
        protected abstract void Start();
        protected abstract int GetCard();
        protected abstract void ToGo(User user);
        protected abstract void Finish();
    }
}
