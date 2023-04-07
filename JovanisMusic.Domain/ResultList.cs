using Newtonsoft.Json;

namespace JovanisMusic.Domain
{
    public class ResultList
    {
        [JsonProperty("items")]
        public List<Video> Videos { get; set; }
    }
}