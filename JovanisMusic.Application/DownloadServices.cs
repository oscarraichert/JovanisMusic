using FFmpeg.NET;
using System.Text;
using VideoLibrary;

namespace Jovani_sMusic.Application
{
    public class DownloadServices
    {
        public const string Directory = @"C:\YoutubeVideos\";
        public const string YoutubeUrl = "https://youtube.com/watch?v=";

        public static void DownloadFromLink(string videoId)
        {
            var youtube = YouTube.Default;
            var video = youtube.GetVideo(YoutubeUrl + videoId);
            File.WriteAllBytes(Directory + video.FullName, video.GetBytes());

            ConvertToAudio(video);
        }

        public static void ConvertToAudio(YouTubeVideo video)
        {
            var inputFile = new InputFile(Directory + video.FullName);
            var outputFile = new OutputFile($"{Directory + video.FullName.Replace(".mp4", "")}.mp3");

            var engine = new Engine("C:\\ProgramData\\chocolatey\\bin\\ffmpeg.exe");

            engine.ConvertAsync(inputFile, outputFile, default).Wait();
            File.Delete(inputFile.Name);
        }
    }
}
