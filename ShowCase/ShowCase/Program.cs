using System;
using System.Collections.Generic;
using System.Linq;
using ShowCase.Controllers;
using ShowCase.Models;
using ShowCase.Views;

namespace ShowCase
{
    class Program
    {
        static void Main(string[] args)
        {

            // Dictionary<string, int> menu = new Dictionary<string, int>();
            // menu["test"] = 2;
            // menu["test2"] = 3;
            // menu["test3"] = 4;
            // Console.WriteLine(menu.Keys.First());
            // Console.WriteLine(menu.Values.First());
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {
            ProgramController programController = new ProgramController();
        }
    }
}
