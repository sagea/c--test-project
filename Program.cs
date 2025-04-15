using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


Func<HttpContext, Task<string>> greet = async context =>
{
    var res = await JsonSerializer.DeserializeAsync<TodoRequestBody>(context.Request.Body);
    if (res == null)
    {
        context.Response.Headers.Append("Content-Type", "application/json");
        context.Response.StatusCode = 500;
        return "{\"message\": \"Body Parse Error\"}";
    }
    Console.Write(res);

    var todo = new Todo
    {
        Id = Guid.NewGuid().ToString(),
        Message = res.Message
    };
    context.Response.Headers.Append("Content-Type", "application/json");
    context.Response.StatusCode = 200;
    return JsonSerializer.Serialize(todo);
};

app.MapGet("/", greet);
app.MapPost("/", greet);


app.Run();
