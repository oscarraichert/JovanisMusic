using Newtonsoft.Json;

namespace JovanisMusic.Domain
{
    public class Video
    {
        [JsonProperty("id")]
        public Id Id { get; set; }
    }
}