using Newtonsoft.Json;

namespace Lori.Domain.Facebook
{
    public class QuickReply
    {
        [JsonProperty(PropertyName = "payload")]
        public string Payload { get; set; }

        [JsonProperty(PropertyName = "content_type")]
        public string ContentType { get; internal set; }
        
        [JsonProperty(PropertyName = "title")]
        public string Title { get; internal set; }
    }
}