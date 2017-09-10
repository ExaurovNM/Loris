using Newtonsoft.Json;

namespace Lori.Domain.Facebook
{
    public class Messaging
    {
        [JsonProperty(PropertyName = "sender")]
        public Sender Sender { get; set; }

        [JsonProperty(PropertyName = "recipient")]
        public Recepient Recepient { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty(PropertyName = "message")]
        public Message Message { get; set; }
    }
}
