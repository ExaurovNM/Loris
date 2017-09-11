using System;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace Lori.Domain.Facebook
{
    public class SendMessageRequest
    {
        [JsonProperty(PropertyName = "recipient")]
        public Recepient Recepient { get; set; }

        [JsonProperty(PropertyName = "message")]
        public MessageForSend Message { get; set; }

        internal static SendMessageRequest Create(string text, string recipientId, string[] quickReplies = null)
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

            if(quickReplies != null && quickReplies.Any())
            {
                request.Message.QuickReplies = quickReplies.Select(x => new QuickReply
                {
                    Payload = x,
                    ContentType = "text",
                    Title = x
                });
            }

            return request;
        }
    }

    public class MessageForSend
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "quick_replies")]
        public IEnumerable<QuickReply> QuickReplies { get; internal set; }
    }
}
