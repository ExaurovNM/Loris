using Newtonsoft.Json;

namespace Lori.Domain.Facebook
{
    public class Message
    {
        [JsonProperty(PropertyName = "mid")]
        public string Mid { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "quick_reply")]
        public QuickReply QuickReply{get; set;}
    }
}
