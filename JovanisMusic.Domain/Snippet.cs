using Newtonsoft.Json;

namespace JovanisMusic.Domain
{
    public class Snippet
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}