using Jovani_sMusic.Application;
using YoutubeExplode;

namespace JovanisMusic.API
{
    public class SearchServices
    {
        public const string ApiKey = "AIzaSyCT1pHxyi5cFWQ1XoFVGLKQZ1BiqdXvkfc";
        public YoutubeClient YoutubeClient;
        public DownloadServices DownloadServices;

        public SearchServices(YoutubeClient youtubeClient, DownloadServices downloadServices)
        {
            YoutubeClient = youtubeClient;
            DownloadServices = downloadServices;
        }

        public async Task GetSongs(List<string> songs)
        {
            foreach (var song in songs)
            {
                var video = await ReturnFirstVideo(song);
                await DownloadServices.DownloadFromLink(video.url, video.title);
            }
        }

        public async Task<(string url, string title)> ReturnFirstVideo(string query)
        {
            await foreach (var video in YoutubeClient.Search.GetResultsAsync(query))
            {
                return (video.Url, video.Title);
            };

            throw new Exception("ESSE VIDEO NAO EXISTE MAN!!");
        }
    }
}
