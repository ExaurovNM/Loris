namespace Lori.Domain.Facebook
{
    public class GreetingRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "greeting")]
        public Greeting[] Greeting { get; set; }
    }
}
