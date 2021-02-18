using System;
using ShowCase.Controllers;
using ShowCase.Models;
using ShowCase.Views;

namespace ShowCase
{
    class Program
    {
        private string _nameProgramm = "ShowCase";
        static void Main(string[] args)
        {
            Program test = new Program();
            test.Start();
        }

        private void Start()
        {
            Console.WriteLine(_nameProgramm);
            // Console.WriteLine("test");
            DataBase dataBase = new DataBase();
            ProgramController programController = new ProgramController(dataBase);
            // Shop shop = new Shop(1);
            // //shop.Create(controller);
            // Case case_ = new Case(1);

        }
    }
}
