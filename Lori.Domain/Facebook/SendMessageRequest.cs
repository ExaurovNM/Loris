using System;
using Newtonsoft.Json;

namespace Lori.Domain.Facebook
{
    public class SendMessageRequest
    {
        [JsonProperty(PropertyName = "recipient")]
        public Recepient Recepient { get; set; }

        [JsonProperty(PropertyName = "message")]
        public MessageForSend Message { get; set; }

        internal static SendMessageRequest Create(string text, string recipientId)
        {
            var request = new SendMessageRequest
            {
                Recepient = new Recepient
                {
                    Id = recipientId
                },
                Message = new MessageForSend
                {
                    Text = text
                }
            };

            return request;
        }
    }

    public class MessageForSend
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
