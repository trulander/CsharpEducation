using System;
using System.Text;

namespace HuntTheWumpus
{
    class Program
    {
        public static bool IsVisibleGameObject { get; set; }
        public static int SizeX { get; set; }
        public static int SizeY { get; set; }
        public static int WumpusCount { get; set; }
        public static int BatCount { get; set; }
        public static int HoleCount { get; set; }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IsVisibleGameObject = false;
            SizeX = 6;
            SizeY = 6;
            WumpusCount = 1;
            BatCount = 2;
            HoleCount = 2;

            string consoleKey;
            bool next = false;
            Int32 consoleKeyNumber;

            View.Print("Do you want to ");
            View.Print("change", ConsoleColor.Green);
            View.PrintLine(" default setup? (Y/N)");
            consoleKey = Console.ReadLine();
            if (consoleKey == "Y" || consoleKey == "y")
            {
                View.Clear();
                View.Print("Do you want to ");
                View.Print("see", ConsoleColor.Green);
                View.PrintLine(" game's object? (Y/N)");
                consoleKey = Console.ReadLine();
                if (consoleKey == "Y" || consoleKey == "y")
                {
                    IsVisibleGameObject = true;
                }

                do
                {
                    View.Clear();
                    View.Print("How much size field ");
                    View.Print("WIDTH", ConsoleColor.Green);
                    View.PrintLine(" do you want? (number from 6 up to 20)");
                    consoleKey = Console.ReadLine();
                    next = false;

                    if (int.TryParse(consoleKey, out consoleKeyNumber) && consoleKeyNumber >= 6 && consoleKeyNumber <= 20)
                    {
                        next = true;
                        SizeY = consoleKeyNumber;

                    }
                } while (!next);

                do
                {
                    View.Clear();
                    View.Print("How many size field ");
                    View.Print("HEIGHT", ConsoleColor.Green);
                    View.PrintLine(" do you want? (number from 6 up to 20)");
                    consoleKey = Console.ReadLine();
                    next = false;

                    if (int.TryParse(consoleKey, out consoleKeyNumber) && consoleKeyNumber >= 6 && consoleKeyNumber <= 20)
                    {
                        next = true;
                        SizeX = consoleKeyNumber;

                    }
                } while (!next);

                do
                {
                    View.Clear();
                    View.Print("How many wumpus ");
                    View.Print("COUNT", ConsoleColor.Green);
                    View.PrintLine(" do you want? (number from 1 up to 6)");
                    consoleKey = Console.ReadLine();
                    next = false;

                    if (int.TryParse(consoleKey, out consoleKeyNumber) && consoleKeyNumber >= 1 && consoleKeyNumber <= 6)
                    {
                        next = true;
                        WumpusCount = consoleKeyNumber;

                    }
                } while (!next);

                do
                {
                    View.Clear();
                    View.Print("How many bat ");
                    View.Print("COUNT", ConsoleColor.Green);
                    View.PrintLine(" do you want? (number from 1 up to 6)");
                    consoleKey = Console.ReadLine();
                    next = false;

                    if (int.TryParse(consoleKey, out consoleKeyNumber) && consoleKeyNumber >= 1 && consoleKeyNumber <= 6)
                    {
                        next = true;
                        BatCount = consoleKeyNumber;

                    }
                } while (!next);

                do
                {
                    View.Clear();
                    View.Print("How many hole ");
                    View.Print("COUNT", ConsoleColor.Green);
                    View.PrintLine(" do you want? (number from 1 up to 6)");
                    consoleKey = Console.ReadLine();
                    next = false;

                    if (int.TryParse(consoleKey, out consoleKeyNumber) && consoleKeyNumber >= 1 && consoleKeyNumber <= 6)
                    {
                        next = true;
                        HoleCount = consoleKeyNumber;

                    }
                } while (!next);
            }
            View.Clear();
            HuntTheWumpus game = new HuntTheWumpus();
        }
    }
}
