using System;

namespace ClientShowCase
{
    public class ProgramController
    {
        private HttpController _httpController;
        private Result _response;
        private View _view;
        public ProgramController()
        {
            _view = new View();
            _view.WriteLine("Http client for ShowCase");
            _httpController = new HttpController();
            _response = _httpController.Request();
            MainLoop();
        }

        private void MainLoop()
        {
            do
            {
                Console.WriteLine("111");
                _view.Clear();
                //_view.WriteLine(_response.text);
                if (_response.text != null)
                {
                    _view.GenerateMap(_response.text);
                }
                
                ConsoleKeyInfo key;             
                switch (_response.action)
                {
                    case "ReadLine":
                        _view.WriteLine("ReadLine");
                        _response = _httpController.Request(null,null,Console.ReadLine());
                        break;
                    case "ReadKey":
                        _view.WriteLine("ReadKey");
                        Console.TreatControlCAsInput = true;
                        key = Console.ReadKey(true);
                        Console.TreatControlCAsInput = false;
                        _response = _httpController.Request((int)key.Key, (int)key.Modifiers, null);
                        break;
                    default:
                        _view.WriteLine("default");
                        //_response = _httpController.Request(37);
                        Console.TreatControlCAsInput = true;
                         key = Console.ReadKey(true);
                        Console.TreatControlCAsInput = false;
                        _response = _httpController.Request((int)key.Key, (int)key.Modifiers, null);
                        break;
                }
            }
            while (true);
        }
    }
}