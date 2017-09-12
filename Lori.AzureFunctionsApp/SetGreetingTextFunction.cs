using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Lori.Domain.Facebook;
using System.Collections.Generic;

namespace Lori.AzureFunctionsApp
{
    public static class SetGreetingTextFunction
    {
        [FunctionName("SetGreetingTextFunction")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            var greetings = new List<Greeting>
            {
                 new Greeting
                {
                    Locale = Locales.Default,
                    Text = "Hello, I'm Pygmy Slow Loris and I may notify you when new film with good rating appears on IMDB"
                },
                new Greeting
                {
                    Locale = Locales.En_Us,
                    Text = "Hello, I'm Pygmy Slow Loris and I may notify you when new film with good rating appears on IMDB"
                },
                new Greeting
                {
                    Locale = Locales.Ru_Ru,
                    Text = "Привет, я Малый Толстый лори и я могу сообщить о выходе нового фильма с хорошим рейтингом"
                }
            };

            var client = new FacebookClient();
            var result = await client.SetStartedText(greetings);

            return result ? req.CreateResponse() : req.CreateErrorResponse(HttpStatusCode.InternalServerError, "Fail to send request");
        }
    }
}
