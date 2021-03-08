using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using Newtonsoft.Json;
using ShowCase.Interfases;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
                    requestContext.Response.StatusCode = 200; //OK 
                    requestContext.Response.ContentType = "application/json";
                    var postData = GetNameValues(request);
                   
                    if (postData.TryGetValue("text", out var text))
                    {
                        view.ConsoleText = text; 
                    }

                    if (postData.TryGetValue("console_modifiers", out var consoleModifiers))
                    {
                        if (consoleModifiers != "null" && Int32.TryParse(consoleModifiers, out var consoleKeyModifiers))
                        {
                            view.ConsoleKeyModifiers = consoleKeyModifiers;
                        }
                    }

                    if (postData.TryGetValue("console_key", out var key))
                    {
                        if (key != "null" && Int32.TryParse(key, out var consoleKey))
                        {
                            view.ConsoleKey = consoleKey;
                        }
                    }

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
                else
                {
                    requestContext.Response.StatusCode = 500; //exception
                }
        
               // Console.WriteLine(view.Buffer);
               Console.Clear();
               view.ShowMap();
                   
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
            _programController.Step();
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