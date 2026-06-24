using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

// In-memory store – replace with a real DB in production
var todos = new List<TodoItem>
{
    new(1, "Buy groceries",    false, DateTimeOffset.UtcNow.AddDays(-2)),
    new(2, "Walk the dog",     true,  DateTimeOffset.UtcNow.AddDays(-1)),
    new(3, "Read about .NET 10", false, DateTimeOffset.UtcNow),
};
int nextId = todos.Count + 1;

app.MapGet("/todos", () => todos)
   .WithName("GetTodos")
   .WithSummary("Returns all todo items");

app.MapGet("/todos/{id:int}", (int id) =>
    todos.FirstOrDefault(t => t.Id == id) is { } item
        ? Results.Ok(item)
        : Results.NotFound())
   .WithName("GetTodoById")
   .WithSummary("Returns a single todo item by id");

app.MapPost("/todos", (TodoItem todo) =>
{
    var created = todo with { Id = nextId++ };
    todos.Add(created);
    return Results.Created($"/todos/{created.Id}", created);
})
   .WithName("CreateTodo")
   .WithSummary("Creates a new todo item");

app.MapPut("/todos/{id:int}", (int id, TodoItem updated) =>
{
    var index = todos.FindIndex(t => t.Id == id);
    if (index == -1) return Results.NotFound();
    todos[index] = updated with { Id = id };
    return Results.Ok(todos[index]);
})
   .WithName("UpdateTodo")
   .WithSummary("Updates an existing todo item");

app.MapDelete("/todos/{id:int}", (int id) =>
{
    var item = todos.FirstOrDefault(t => t.Id == id);
    if (item is null) return Results.NotFound();
    todos.Remove(item);
    return Results.NoContent();
})
   .WithName("DeleteTodo")
   .WithSummary("Deletes a todo item");

app.Run();

// Make the implicit Program class visible to the test project
public partial class Program { }
