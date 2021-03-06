using System;
using System.Collections.Generic;
using System.Linq;
using ShowCase.Controllers;
using ShowCase.Interfases;
using ShowCase.Models;
using ShowCase.Views;

namespace ShowCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {
            IView view = new View();
            view.Instruction();
            ProgramController programController = new ProgramController(view);
        }
    }
}
