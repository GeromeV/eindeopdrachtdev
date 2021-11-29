using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos;

namespace ParkingGent
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);

            CosmosClientOptions cosmosClientOptions = new CosmosClientOptions();
            cosmosClientOptions.ConnectionMode = Microsoft.Azure.Cosmos.ConnectionMode.Gateway;
            CosmosClient cosmosClient = new CosmosClient(Environment.GetEnvironmentVariable("Cosmosconnectionstring"), cosmosClientOptions);

            string reqbody = await new StreamReader(req.Body).ReadToEndAsync();
            var parklog = JsonConvert.DeserializeObject<Parking>(reqbody);

            Database database = cosmosClient.GetDatabase("parkinggent");
            Container container = database.GetContainer("parking");
        }
         
    }
}
