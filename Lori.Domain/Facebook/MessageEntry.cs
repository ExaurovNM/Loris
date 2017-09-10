using Newtonsoft.Json;

namespace Lori.Domain.Facebook
{
    public class MessageEntry
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        [JsonProperty(PropertyName = "messaging")]
        public Messaging[] Messaging { get; set; }
    }
}
