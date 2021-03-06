using System.Linq;
using System.Net.Http;
using System.Text;

namespace ClientShowCase
{
    public class HttpController
    {
        public const string urlServerHost = "Http://localhost:8080/";
        private View _view = new View();

        public Result Request(int key, string text = "")
        {
            HttpClient httpClient = new HttpClient();
            Result result;
            var postData = new StringContent("key=" + key + "&text=" + text, Encoding.UTF8);
            
            try
            {
                var response = httpClient.PostAsync(urlServerHost, postData).Result;
                result = new Result
                (
                    response.Headers.Contains("lastMethodRequired") ? response.Headers.GetValues("lastMethodRequired").Single() : "empty",
                    response.Content.ReadAsStringAsync().Result
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