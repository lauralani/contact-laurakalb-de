using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace contact
{
    public static class submit
    {
        [FunctionName("submit")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "submit")] HttpRequest req,
            ILogger log)
        {
            //log.LogInformation("C# HTTP trigger function processed a request.");

            Message message;
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            try
            {
                message = JsonConvert.DeserializeObject<Message>(requestBody);
            }
            catch
            {
                return new BadRequestResult();
            }

            log.LogInformation(requestBody);
            log.LogInformation(message.Name);
            log.LogInformation(message.Email);
            log.LogInformation(message.Phone);
            log.LogInformation(message.Body);


            return new OkObjectResult("ok");
        }
    }
}
