namespace TodoApi.Models;

public record TodoItem(
    int Id,
    string Title,
    bool IsComplete,
    DateTimeOffset CreatedAt
);
