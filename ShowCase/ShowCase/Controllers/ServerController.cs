using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using ShowCase.Interfases;

namespace ShowCase.Controllers
{
    public class ServerController
    {
        private static ProgramController _programController;
        private  IView _view;
        public const string urlServerHost = "Http://localhost:8080/";
        
        public ServerController(IView view)
        {
            _view = view;
            _programController = new ProgramController(_view);
            _view.waitHandle = new[]
            {
                new ManualResetEvent(initialState: true),
                new ManualResetEvent(initialState: true)
            };
            
            Thread serverThread = new Thread(() => StartServer(_view));
            serverThread.IsBackground = false;
            serverThread.Start();
        }

        private static void StartServer(IView view)
        {
            Thread programLoopThread;
            programLoopThread = new Thread(()=>ProgramLoop(view));
            programLoopThread.IsBackground = true;
            
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add(urlServerHost);
            httpListener.Start();
            
            while (true)
            {
                var requestContext = httpListener.GetContext();
                var request = requestContext.Request;
                
                if ( request.HttpMethod == "POST" )
                {
                    string consoleText;
                    int consoleKey;
                    
                    requestContext.Response.StatusCode = 200; //OK     
                    var postData = GetNameValues(request);
                    
                   
                    if (postData.TryGetValue("text", out consoleText))
                    {
                        view.ConsoleText = consoleText; 
                    }
                   
                    if (Int32.TryParse(postData?["key"], out consoleKey))
                    {
                        view.ConsoleKey = consoleKey;
                        
                        view.waitHandle[1].Reset();
                        view.waitHandle[0].Set();
                        
                        if (!programLoopThread.IsAlive)
                        {
                            programLoopThread = new Thread(()=>ProgramLoop(view));
                            programLoopThread.IsBackground = false;
                            programLoopThread.Start();
                        }
                        view.waitHandle[1].WaitOne();
                    }
                }
                else
                {
                    requestContext.Response.StatusCode = 500; //exception
                }
        
                Console.WriteLine(view.Buffer);

                requestContext.Response.Headers.Add("lastMethodRequired",view.lastMethodRequired);
                view.lastMethodRequired = "";
                
                var stream = requestContext.Response.OutputStream;
                var bytes = Encoding.UTF8.GetBytes(view.Buffer);
                try
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
                catch
                {
                    Console.WriteLine("Client was disconnected");
                }
                
                requestContext.Response.Close();
            }
            /*
             * todo:   finish current thread, now the code will never use
             */
            httpListener.Stop();
            httpListener.Close();
        }

        private static void ProgramLoop(IView view)
        {
           // _programController.MainLoop();
            view.waitHandle[1].Set();
        }
        
        static string DecodeUrl(string url)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(url)) != url)
                url = newUrl;
            return newUrl;
        }

        static Dictionary<string, string> GetNameValues(HttpListenerRequest request)
        {
            var result = new Dictionary<string, string>();
 
            using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                var requestBody = reader.ReadToEnd();
                string[] nameValues = requestBody.Split('&');
 
                foreach (var nameValue in nameValues.ToList())
                {
                    string[] splitted = nameValue.Split('=');
                    result.Add(DecodeUrl(splitted[0]), DecodeUrl(splitted[1]));
                }
            }
    
            return result;
        }   
    }
}