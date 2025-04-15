using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading.Tasks;

class TodoApi
{
    public static async Task GetTodo(HttpContext context)
    {
        var todo = new Todo
        {
            Id = Guid.NewGuid().ToString(),
            Message = "Temporary default message"
        };
        context.Response.Headers.Append("Content-Type", "application/json");
        context.Response.StatusCode = 200;
        await context.Response.WriteAsJsonAsync(todo);
    }

    public static async Task PostTodo(HttpContext context)
    {
        var res = await JsonSerializer.DeserializeAsync<TodoRequestBody>(context.Request.Body);
        if (res == null)
        {
            context.Response.Headers.Append("Content-Type", "application/json");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                message = "Body Parse Error"
            });
            return;
        }
        Console.Write(res);

        var todo = new Todo
        {
            Id = Guid.NewGuid().ToString(),
            Message = res.Message
        };
        context.Response.Headers.Append("Content-Type", "application/json");
        context.Response.StatusCode = 200;
        await context.Response.WriteAsJsonAsync(todo);
    }
}
