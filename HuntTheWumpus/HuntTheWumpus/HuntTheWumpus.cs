using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    class HuntTheWumpus
    {
        private View _view;
        private bool _continue = true;
        private ControllerGame _controllerGame;
        public HuntTheWumpus()
        {
            View.ShowStartInformation();
            Map map = new Map(6,6);
            UnitController unitController = new UnitController(1, 2, 1, 2, map);
            
            _view = new View(map, unitController.Units);
            _controllerGame = new ControllerGame(_view, unitController);
            

            View.PrintLine("Press anykey to show instruction for play the game..");
            Console.ReadLine();
            View.instruction();
            View.PrintLine("Press anykey to start the game..");
            Console.ReadLine();
            StartGame();
        }
        private void StartGame()
        {
            _view.MapReload();

            while (_continue)
            {
                _continue = _controllerGame.ReadKey();
            }
        }
    }
}
