using APILibrary.Models;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APILibrary
{
    public class JokeProcessor
    {
        public static async Task<OuterContainer> LoadJokes()
        {
            string url = "https://api.jokes.one/jod";
            //string url = "https://xkcd.com/info.0.json";
            using (var response = ApiHelper.ApiClient.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    OuterContainer JsonContent = await response.Content.ReadAsAsync<OuterContainer>();
                    return JsonContent;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
