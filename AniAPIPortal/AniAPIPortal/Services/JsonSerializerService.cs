using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AniAPIPortal.Services
{
    public class JsonSerializerService
    {
        public string SerializeObject<T> (T payload)
        {
            return JsonSerializer.Serialize(payload);
        }

        public T Deserialize<T>(string payload)
        {
            return JsonSerializer.Deserialize<T>(payload);
        }
    }
}
