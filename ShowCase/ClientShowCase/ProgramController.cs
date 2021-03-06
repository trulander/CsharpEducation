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
            _response = _httpController.Request(37);
            MainLoop();
        }

        private void MainLoop()
        {
            do
            {
                _view.Clear();
                _view.WriteLine(_response.text);
                switch (_response.action)
                {
                    case "ReadLine":
                        _response = _httpController.Request(0,Console.ReadLine());
                        break;
                    case "ReadKey":
                        _response = _httpController.Request((int)Console.ReadKey(true).Key);
                        break;
                    default:
                        _response = _httpController.Request(37);
                        break;
                }
            }
            while (true);
        }
    }
}