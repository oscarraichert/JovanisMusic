using Newtonsoft.Json;

namespace JovanisMusic.Domain
{
    public class Id
    {
        [JsonProperty("videoId")]
        public string VideoId { get; set; }
    }
}