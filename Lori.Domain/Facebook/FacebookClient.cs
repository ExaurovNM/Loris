using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lori.Domain.Facebook
{
    public class FacebookClient
    {
        private readonly string SendMessageEndpoint;
        private readonly string ProfileEndpoint;

        public FacebookClient()
        {
            SendMessageEndpoint = "https://graph.facebook.com/v2.6/me/messages?access_token=" + Environment.GetEnvironmentVariable("FacebookToken");
            ProfileEndpoint = "https://graph.facebook.com/v2.6/me/messenger_profile?access_token=" + Environment.GetEnvironmentVariable("FacebookToken");
        }

        public async Task<bool> SendMessage(string text, string recipient)
        {
            var messageRequest = SendMessageRequest.Create(text, recipient);

            var result = await SendPostRequest(SendMessageEndpoint, messageRequest);

            return result;
        }

        public async Task<bool> SetGetStartedButton()
        {
            var getStartedRequest = new GetStartedRequest();

            var result = await SendPostRequest(ProfileEndpoint, getStartedRequest);

            return result;
        }

        private async Task<bool> SendPostRequest<T>(string url, T dataToSend)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(dataToSend);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                return response.IsSuccessStatusCode;
            }
        }
    }
}
