using System;
using ShowCase.Models;
using ShowCase.Views;

namespace ShowCase.Controllers
{
    public class ProgramController
    {
        private DataBase _dataBase;
        private ModelController _modelController;
        private View _view;
        public ProgramController(DataBase dataBase)
        {
            _dataBase = dataBase;
            _view = new View();
            _modelController = new ModelController(_dataBase);
            DemoData demoData = new DemoData(_modelController,_dataBase);
            _view.MapGenerate(_dataBase);
            start();
        }

        private void start()
        {
            
        }
    }
}