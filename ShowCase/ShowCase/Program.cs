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

            ServerController serverController = new ServerController(new SeverView());
            IView view = new ConsoleView();
            view.Instruction();
            ProgramController programController = new ProgramController(view);
            programController.StartProgram();
        }
    }
}
