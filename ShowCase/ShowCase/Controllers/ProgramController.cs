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
            start();
        }

        private void start()
        {
            _modelController.Create(new Shop<Case<Product<int>>>(1));
           // _modelController.Create(_dataBase.Shops[0]);
            
            //_modelController.Create(new Case<Product<int>>(1));
            //_modelController.Create(new Product<int>(1));            
        }
    }
}