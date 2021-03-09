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
        public const string URL_SERVE_RHOST = "Http://localhost:8080/";
        
        public ServerController(IView view)
        {
            _view = view;
            _programController = new ProgramController(_view);
            /*
             * Initialise event handler for treads
             * [0] - for serverThread
             * [1] - for programLoopThread
             */
            _view.waitHandle = new[]
            {
                new ManualResetEvent(initialState: true),
                new ManualResetEvent(initialState: true)
            };
            /*
             * Start main serverTread as background
             */
            Thread serverThread = new Thread(() => StartServer(_view));
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        /// <summary>
        /// method for serverTread
        /// </summary>
        /// <param name="view">Iview instance</param>
        private static void StartServer(IView view)
        {
            /*
             * Start programLoopThread for program logic.
             * we using native programController but it have to be working in the tread
             */
            Thread programLoopThread;
            programLoopThread = new Thread(()=>ProgramLoop(view));
            programLoopThread.IsBackground = true;
            
            /*
             * start http listener for getting request from remote client
             */
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add(URL_SERVE_RHOST);
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
                   
                    /*
                     * we can get from client for 3 parameters
                     * text = can be from Console.ReadLine()
                     * console_modifiers = can be from Console.ReadKey().Modifiers
                     * console_key = can be from Console.ReadKey().Key
                     */
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

                    /*
                     * Synchronisation treads
                     * Reset waiting handler for programLoopThread
                     * Set waiting handler for ServerThread
                     */
                    view.waitHandle[1].Reset();
                    view.waitHandle[0].Set();
                
                    /*
                     * If programLoopThread is dead, i'll start it again.
                     * It could be alive because it can waiting request from user.
                     * for example waiting new name for something or new metrics for size...
                     */
                    if (!programLoopThread.IsAlive)
                    {
                        programLoopThread = new Thread(()=>ProgramLoop(view));
                        programLoopThread.IsBackground = true;
                        programLoopThread.Start();
                    }
                    /*
                     * waiting for programLoopThread
                     * i don't have to continue until programLoopThread is working and don't give allow
                     */
                    view.waitHandle[1].WaitOne();
                    
                }
                else
                {
                    requestContext.Response.StatusCode = 500; //exception
                }
        
               // Console.WriteLine(view.Buffer);
               //Console.Clear();
               // view.ShowMap();
                   
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

        /// <summary>
        /// Main loop for program logic, that will use inside server thread for programloop thread
        /// </summary>
        /// <param name="view">Iview instance</param>
        private static void ProgramLoop(IView view)
        {
            _programController.Step();
            view.waitHandle[1].Set();
        }
        
        /// <summary>
        /// Decoder escape URL value
        /// </summary>
        /// <param name="url">Escape Url or unescape</param>
        /// <returns>unescape url</returns>
        static string DecodeUrl(string url)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(url)) != url)
                url = newUrl;
            return newUrl;
        }

        /// <summary>
        /// Method for getting each value from httplistener as Post or Get request
        /// </summary>
        /// <param name="request"></param>
        /// <returns>dictionary<namefield,valuefield></returns>
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