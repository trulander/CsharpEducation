using System;
using ShowCase.Controllers;
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
            ProgramController programController = new ProgramController();
        }
    }
}
