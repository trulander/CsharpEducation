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
        private UnitController _unitController;
        
        public HuntTheWumpus()
        {
            View.ShowStartInformation();
            Map map = new Map(Program.SizeX, Program.SizeY);
            _unitController = new UnitController(1, Program.BatCount, Program.WumpusCount, Program.HoleCount, map);
            
            _view = new View(map);
            _controllerGame = new ControllerGame(_view, _unitController);
            

            View.PrintLine("Press anykey to show instruction for play the game..");
            Console.ReadLine();
            View.instruction();
            View.PrintLine("Press anykey to start the game..");
            Console.ReadLine();
            StartGame();
        }
        private void StartGame()
        {
            View.Clear();
            _view.MapReload(!Program.IsVisibleGameObject ? _unitController.Players[0].Marker : "");
            _controllerGame.ChechWarning();

            while (_continue)
            {
                _continue = _controllerGame.ReadKey();
            }
            _view.MapReload();
            _controllerGame.MakeResultOfGame();
        }
    }
}
