using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Lori.Domain.Facebook;

namespace Lori.AzureFunctionsApp
{
    public static class UpdateGetStartedMenuFunction
    {
        [FunctionName("UpdateGetStartedMenuFunction")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            var facebookClient = new FacebookClient();

            var result = await facebookClient.SetGetStartedButton();

            return result 
                ? req.CreateResponse() 
                : req.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error while updating start menu");
        }
    }
}
