using Newtonsoft.Json;

namespace Lori.Domain.Facebook
{
    public class Sender
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
