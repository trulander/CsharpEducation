﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HuntTheWumpus
{
    /* class for generate view as layout */
    public class View
    {
        private Map _map;
        public View(Map map)
        {
            _map = map;
            PrintLine("View initialised");
        }

        /*methor for reload the map*/
        public void MapReload(string marker = "")
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < _map.SizeX; i++)
            {
                for (int j = 0; j < _map.SizeY; j++)
                {
                    if (_map.Busy[i,j] != null)
                    {
                        Print("[");
                        if (marker == "")
                        {
                            Print(_map.Busy[i, j], _map.BusyColor[i, j]);
                        }
                        else if (marker == _map.Busy[i, j])
                        {
                            Print(_map.Busy[i, j], _map.BusyColor[i, j]); 
                        }
                        else
                        {
                            Print(" ");
                        }
                        
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

        /* method for show what action player did on a previous step */
        public void ShowKeyPressed(string value)
        {
            Console.SetCursorPosition(0, _map.SizeX);
            Print("               ");
            Console.SetCursorPosition(0, _map.SizeX);
            PrintLine(value, ConsoleColor.Red);
        }

        /* method for show message about objects that around */
        public void ShowWarning(string[] value)
        {
            
            for (int i = 0; i < value.Length; i++)
            {
                Console.SetCursorPosition(_map.SizeY * 3, i);
                Print("                    ");
            }
            for (int i = 0; i < value.Length; i++)
            {
                Console.SetCursorPosition(_map.SizeY * 3, i);
                PrintLine(value[i], ConsoleColor.Red);
            }
            Console.SetCursorPosition(_map.SizeY * 3, _map.SizeX);
        }

        /* for show in the finale who is winner */
        public void ResultOfGame(string value)
        {
            Console.SetCursorPosition(0, _map.SizeX + 5);
            Print("The winner is " + value, ConsoleColor.Green);
            Console.SetCursorPosition(0, _map.SizeX + 10);
        }

        /* for show different debug debug informations */
        public static void DebugView(string value)
        {
            Console.SetCursorPosition(0, 20);
            PrintLine(value, ConsoleColor.Red);
        }

        /* for information on the start */
        public static void ShowStartInformation()
        {
            PrintLine("HuntTheWumpus", ConsoleColor.Red);
            Print("Starting game...", ConsoleColor.Red);
            PrintLine();
        }

        /* instruction how play the game */
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

        /* custom method printline width color*/
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

        /* custom method printline */
        public static void PrintLine()
        {
            Console.WriteLine();
        }

        /* custom method print width color */
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

        /* custom method clear console */
        public static void Clear()
        {
            Console.Clear();
        }
    }
}
