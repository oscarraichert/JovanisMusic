using Newtonsoft.Json;

namespace JovanisMusic.Domain
{
    public class Video
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }
    }
}