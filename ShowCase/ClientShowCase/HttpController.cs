using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ClientShowCase
{
    public class HttpController
    {
        public const string urlServerHost = "Http://localhost:8080/";
        private View _view = new View();

        public Result Request(int? consoleKey = null, int? consoleModifiers = null, string? text = null)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 3);
            Result result;
            var postData = new StringContent("console_key=" + consoleKey + "&console_modifiers=" + consoleModifiers + "&text=" + text, Encoding.UTF8, "application/json");
            
            try
            {
                var response = httpClient.PostAsync(urlServerHost, postData).Result;
                result = new Result
                (
                    response.Headers.Contains("lastMethodRequired") ? response.Headers.GetValues("lastMethodRequired").Single() : "empty",
                    JsonConvert.DeserializeObject<Dictionary<int, Dictionary<int, Dictionary<char, ConsoleColor>>>>(response.Content.ReadAsStringAsync().Result)
                );
            }
            catch
            {
                _view.WriteLine("Server not found");
                result = new Result(null, null);
            }
            return result;
        } 
    }
}