using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using TodoApi.Models;

namespace TodoApi.Tests;

public class TodoApiTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetTodos_ReturnsOkWithItems()
    {
        var response = await _client.GetAsync("/todos");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var items = await response.Content.ReadFromJsonAsync<List<TodoItem>>();
        Assert.NotNull(items);
        Assert.NotEmpty(items);
    }

    [Fact]
    public async Task GetTodoById_ExistingId_ReturnsItem()
    {
        var response = await _client.GetAsync("/todos/1");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var item = await response.Content.ReadFromJsonAsync<TodoItem>();
        Assert.NotNull(item);
        Assert.Equal(1, item.Id);
    }

    [Fact]
    public async Task GetTodoById_MissingId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/todos/9999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CreateTodo_ReturnsCreated()
    {
        var newItem = new TodoItem(0, "Test task", false, DateTimeOffset.UtcNow);
        var response = await _client.PostAsJsonAsync("/todos", newItem);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var created = await response.Content.ReadFromJsonAsync<TodoItem>();
        Assert.NotNull(created);
        Assert.Equal("Test task", created.Title);
        Assert.True(created.Id > 0);
    }

    [Fact]
    public async Task DeleteTodo_ExistingId_ReturnsNoContent()
    {
        var response = await _client.DeleteAsync("/todos/2");
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}
