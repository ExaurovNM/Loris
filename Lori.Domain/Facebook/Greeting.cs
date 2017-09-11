namespace Lori.Domain.Facebook
{
    public class Greeting
    {
        public const string En_Us = "en_US";
        public const string Ru_Ru = "ru_RU";
        public const string Default = "default";

        [Newtonsoft.Json.JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
