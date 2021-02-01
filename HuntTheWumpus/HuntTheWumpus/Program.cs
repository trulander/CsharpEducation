using System;
using System.Text;

namespace HuntTheWumpus
{
    class Program
    {
        public static bool IsVisibleGameObject { get; set; }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IsVisibleGameObject = true;

            HuntTheWumpus game = new HuntTheWumpus();
        }
    }
}
