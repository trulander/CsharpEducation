using System;
using Newtonsoft.Json;

namespace ClientShowCase
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramController programController = new ProgramController();
            programController.StartProgram();
        }
    }
}