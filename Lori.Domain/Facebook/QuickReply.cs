using Newtonsoft.Json;

namespace Lori.Domain.Facebook
{
    public class QuickReply
    {
        [JsonProperty(PropertyName = "payload")]
        public string Payload { get; set; }
    }
}