using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;
using System;
using Lori.Domain.DataAccess;

namespace Lori.AzureFunctionsApp
{
    public static class FacebookWebHookFunction
    {
        [FunctionName("FacebookWebHookFunction")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage request, TraceWriter log)
        {
            var query = request.GetQueryNameValuePairs();

            var challenge = query.FirstOrDefault(pairs => pairs.Key == "hub.challenge");

            if(challenge.Equals(default(KeyValuePair<string, string>)))
            {
                log.Warning("No challenge parameter");
            }

            await LogRequest(request);
        }

        private static async Task LogRequest(HttpRequestMessage request)
        {
            using (var context = new DataBaseContext())
            {
                var content = await request.Content.ReadAsStringAsync();

                var logEntry = new RequestLog
                {
                    Body = content,
                    Method = request.Method.ToString(),
                    Time = DateTime.UtcNow,
                    Url = request.RequestUri.ToString()
                };

                context.RequestLogs.Add(logEntry);

                await context.SaveChangesAsync();
            }
        }
    }
}
