using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Jovani_sMusic.Application
{
    public class DownloadServices
    {
        public const string Directory = @"C:\YoutubeVideos\";
        public const string YoutubeUrl = "https://youtube.com/watch?v=";
        public YoutubeClient YoutubeClient;

        public DownloadServices(YoutubeClient youtubeClient)
        {
            YoutubeClient = youtubeClient;
        }

        public async Task DownloadFromLink(string url, string title)
        {
            await YoutubeClient.Videos.DownloadAsync(url, $"{Directory + title}.mp3");
        }
    }
}
