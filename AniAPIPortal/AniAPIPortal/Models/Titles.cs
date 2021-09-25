using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AniAPIPortal.Models
{
    public class Titles
    {
        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("jp")]
        public string Jp { get; set; }

        [JsonProperty("it")]
        public string It { get; set; }
    }
}
