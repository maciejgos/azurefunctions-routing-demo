#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static IActionResult Run(HttpRequest req, string project, int id, TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request. Project: {project}; Task Id: {id}");

    var response = new TaskResponse
    {
        Id = id,
        Title = project
    };

    return new OkObjectResult(response);
}

class TaskResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
}
