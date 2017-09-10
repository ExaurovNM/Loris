using Newtonsoft.Json;

namespace Lori.Domain.Facebook
{
    public class MessageCallback
    {
        [JsonProperty(PropertyName = "object")]
        public string Object { get; set; }

        [JsonProperty(PropertyName = "entry")]
        public MessageEntry[] Entry { get; set; }
    }
}
