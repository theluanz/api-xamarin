using News.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace News.Services
{
    public class GithubService
    {
        public async Task<GithubResponse> GetRepositories()
        {
            string url = "https://api.github.com/users/theluanz/repos";

            var webclient = new WebClient();
            webclient.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            string json = string.Empty;
            
            try
            {
                json = await webclient.DownloadStringTaskAsync(url);
                Console.WriteLine(json);
                List<Root> response = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Root>>(json);
                GithubResponse result = new GithubResponse();
                result.Roots = response;

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;


            //var json = await webclient.DownloadStringTaskAsync(url);
            //return Newtonsoft.Json.JsonConvert.DeserializeObject<NewsResult>(json);
        }
    }
}
