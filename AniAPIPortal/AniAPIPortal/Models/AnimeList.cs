using Newtonsoft.Json;

namespace AniAPIPortal.Models
{
    public class AnimeList
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
