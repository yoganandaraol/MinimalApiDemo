using Northwind.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Application;

public interface IToDoService
{
    Task<IList<ToDoItem>> GetToDoItems();
    Task<ToDoItem> GetToDoItem(int id);
    Task<ToDoItem> SetToDoItem(string todoItemName, string? todoItemDescription, DateTime? plannedFinishDate);
}
public class ToDoService : IToDoService
{
    public static List<ToDoItem> ToDoItems = new()
    {
        new ToDoItem{ Id = 1, ToDoItemName="Practice C# Concepts" },
        new ToDoItem{ Id = 2, ToDoItemName="Learn Minimal Api" },
        new ToDoItem{ Id = 3, ToDoItemName="Develop a portal for business" }
    };

    public async Task<ToDoItem> GetToDoItem(int id)
    {
        return await Task.FromResult(ToDoItems.First(t => t.Id == id));
    }

    public async Task<IList<ToDoItem>> GetToDoItems()
    {
        return await Task.FromResult(ToDoItems);
    }

    public async Task<ToDoItem> SetToDoItem(string todoItemName, string? todoItemDescription, DateTime? plannedFinishDate)
    {
        var todoItem = new ToDoItem
        {
            Id = ToDoItems.Max(t => t.Id) + 1,
            ToDoItemName = todoItemName,
            ToDoItemDescription = todoItemDescription,
            PlannedFinishDateTime= plannedFinishDate
        };

        ToDoItems.Add(todoItem);

        return await Task.FromResult(todoItem);

    }
}