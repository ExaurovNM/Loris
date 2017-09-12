namespace Lori.Domain.Facebook
{
    public class Greeting
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
