using Newtonsoft.Json;

namespace Lori.Domain.Facebook
{
    public class Recepient
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
