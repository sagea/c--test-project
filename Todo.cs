
public class Todo
{
    required public string Id { get; set; }
    required public string Message { get; set; }
}

public class TodoRequestBody
{
    required public string Message { get; set; }
}
