using System;
using System.IO;
using System.Threading.Tasks;
using AzureFunctions.Contrib.Xyz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace SignalRSample
{
    public static class SampleFunctions
    {
        [FunctionName(nameof(SimpleScenario))]
        public static void SimpleScenario(
                    [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req,
                    [Xyz] out XyzItem item,
                    TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            item = new XyzItem
            {
                Text = "Hello World!"
            };
        }
    }
}
