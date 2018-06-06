
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace RoutingDemo
{
    public static class GetTask
    {
        [FunctionName("GetTask")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "api/gettask/{project:alpha}/task/{id:int}")]HttpRequest req, string project, int id, TraceWriter log)
        {
            log.Info($"C# HTTP trigger function processed a request. Project: {project}; Task Id: {id}");

            var response = new TaskResponse
            {
                Id = id,
                Title = project
            };

            return new OkObjectResult(response);
        }
    }

    class TaskResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
