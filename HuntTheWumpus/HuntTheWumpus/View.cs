using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HuntTheWumpus
{
    class View
    {
        private Map _map;
        public View(Map map)
        {
            _map = map;
            PrintLine("View initialised");
        }
        public void MapReload()
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < _map.SizeX; i++)
            {
                for (int j = 0; j < _map.SizeY; j++)
                {
                    if (_map.Busy[i,j] != null)
                    {
                        Print("[");
                        Print(_map.Busy[i, j], _map.BusyColor[i, j]);
                        Print("]");
                    }
                    else
                    {
                        Print("[ ]");
                    }
                }
                PrintLine();
            }
            
        }

        public void ShowKeyPressed(string value)
        {
            Console.SetCursorPosition(0, _map.SizeY);
            Print("                                                                    ");
            Console.SetCursorPosition(0, _map.SizeY);
            PrintLine(value, ConsoleColor.Red);
        }

        public void ShowWarning(string[] value)
        {
            Console.SetCursorPosition(_map.SizeX * 3, 0);
            for (int i = 0; i < value.Length; i++)
            {
                Print("                                                                    ");
            }
            Console.SetCursorPosition(_map.SizeX * 3, 0);
            for (int i = 0; i < value.Length; i++)
            {
                PrintLine(value[i], ConsoleColor.Red);
            }
        }


        public static void ShowStartInformation()
        {
            PrintLine("HuntTheWumpus", ConsoleColor.Red);
            Print("Starting game...", ConsoleColor.Red);
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.SetCursorPosition(17, 1);
            //    Thread.Sleep(300);
            //    switch (i % 4)
            //    {
            //        case 1:
            //            Print("/", ConsoleColor.Green);
            //            break;
            //        case 2:
            //            Print("-", ConsoleColor.Green);
            //            break;
            //        case 3:
            //            Print("\\", ConsoleColor.Green);
            //            break;
            //        default:
            //            Print("|", ConsoleColor.Green);
            //            break;
            //    }

            //}
            Console.SetCursorPosition(16, 1);
            Print("100%", ConsoleColor.Green);
            PrintLine();
        }
        public static void instruction()
        {
            Clear();
            PrintLine("Using the button for play game: ", ConsoleColor.Red);
            PrintLine("Up - for move player to up", ConsoleColor.Green);
            PrintLine("Down - for move player to down", ConsoleColor.Green);
            PrintLine("Right - for move player to right", ConsoleColor.Green);
            PrintLine("Left - for move player to left", ConsoleColor.Green);
            PrintLine();
            PrintLine("ESC - for left the game", ConsoleColor.Green);
            PrintLine();
            PrintLine("Using the buttons together for play game: ", ConsoleColor.Red);
            PrintLine("CTRL + Up - for shoot to up", ConsoleColor.Green);
            PrintLine("CTRL + Down - for shoot to down", ConsoleColor.Green);
            PrintLine("CTRL + Right - for shoot to right", ConsoleColor.Green);
            PrintLine("CTRL + Left - for shoot to left", ConsoleColor.Green);
        }





        public static void PrintLine(string value, ConsoleColor color = ConsoleColor.White)
        {
            if (color != null)
            {
                Console.ForegroundColor = color;
            }
            Console.WriteLine(value);
            if (color != null)
            {
                Console.ResetColor();
            }
        }
        public static void PrintLine()
        {
            Console.WriteLine();
        }
        public static void Print(string value, ConsoleColor color = ConsoleColor.White)
        {
            if (color != null)
            {
                Console.ForegroundColor = color;
            }
            Console.Write(value);
            if (color != null)
            {
                Console.ResetColor();
            }
        }
        public static void Clear()
        {
            Console.Clear();
        }
    }
}
