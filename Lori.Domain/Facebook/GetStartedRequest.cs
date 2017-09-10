namespace Lori.Domain.Facebook
{
    public class GetStartedRequest
    {
        public const string GetStartdedPayload = "get_startded_payload";

        [Newtonsoft.Json.JsonProperty(PropertyName = "get_started")]
        public QuickReply GetStartded  =>
                new QuickReply
                {
                    Payload = GetStartdedPayload
                };             
    }
}
