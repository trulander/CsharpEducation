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
            //first request for get view from server
            _response = _httpController.Request();
        }

        public void StartProgram()
        {
            do
            {
                _view.Clear();
                //_view.WriteLine(_response.text);
                if (_response.text != null)
                {
                    _view.GenerateMap(_response.text);
                }
                
                int[] key;             
                switch (_response.action)
                {
                    case "ReadLine":
                        _view.WriteLine("ReadLine");
                        _response = _httpController.Request(null,null, _view.ReadLine());
                        break;
                    case "ReadKey":
                        _view.WriteLine("ReadKey");
                        key = _view.ReadKey();
                        _response = _httpController.Request(key[0], key[1], null);
                        break;
                    default:
                        _view.WriteLine("Connecting...");
                        _response = _httpController.Request();
                        // key = _view.ReadKey();
                        // _response = _httpController.Request(key[0], key[1], null);
                        break;
                }
            }
            while (true);
        }
    }
}