using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus
{
    /* Main class the game*/
    internal class HuntTheWumpus
    {
        private View _view;
        private bool _continue = true;
        private GameController _gameController;
        private UnitController _unitController;
        
        public HuntTheWumpus()
        {
            View.ShowStartInformation();
            Map map = new Map(Program.SizeX, Program.SizeY);
            _unitController = new UnitController(1, Program.BatCount, Program.WumpusCount, Program.HoleCount, map);
            
            _view = new View(map);
            _gameController = new GameController(_view, _unitController);
            

            View.PrintLine("Press anykey to show instruction for play the game..");
            Console.ReadLine();
            View.instruction();
            View.PrintLine("Press anykey to start the game..");
            Console.ReadLine();
            StartGame();
        }
        private void StartGame()
        {
            /* clear console and show game map*/
            View.Clear();
            _view.MapReload(!Program.IsVisibleGameObject ? _unitController.Players[0].Marker : "");
            _gameController.ChechWarning();

            /* main cycle the game*/
            while (_continue)
            {
                _continue = _gameController.ReadKey();
            }

            /* finaly reload the map together all game objects*/
            _view.MapReload();
            _gameController.MakeResultOfGame();
        }
    }
}
