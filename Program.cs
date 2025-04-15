using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", TodoApi.GetTodo);
app.MapPost("/", TodoApi.PostTodo);


app.Run();
