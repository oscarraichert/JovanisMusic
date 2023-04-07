using Jovani_sMusic.Application;
using JovanisMusic.Domain;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace JovanisMusic.API
{
    public class SearchServices
    {
        public const string ApiKey = "AIzaSyCT1pHxyi5cFWQ1XoFVGLKQZ1BiqdXvkfc";

        public static async Task<ResultList> SearchQuery(string query)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"https://youtube.googleapis.com/youtube/v3/search?q={query}&key={ApiKey}").Result.Content.ReadAsStringAsync();

            ResultList results = JsonConvert.DeserializeObject<ResultList>(response);

            return results;
        }

        public static Task<string> GetFirstResult(string query)
        {
            var results = SearchQuery(query).Result;
            DownloadServices.DownloadFromLink(results.Videos[0].Id.VideoId);

            return Task.FromResult("completed!!");
        }
    }
}
