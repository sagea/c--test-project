using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () =>
{
    var todo = new Todo
    {
        Id = Guid.NewGuid().ToString(),
        Message = "woah"
    };

    return JsonSerializer.Serialize(todo);
});

app.Run();
