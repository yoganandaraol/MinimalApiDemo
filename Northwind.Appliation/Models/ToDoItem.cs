namespace Northwind.Application.Models;

public class ToDoItem
{
    public int Id { get; set; }
    public string ToDoItemName { get; set; } = string.Empty;
    public string? ToDoItemDescription { get; set; }
    public DateTime? PlannedFinishDateTime { get; set; }
    public DateTime? ActualFinishDateTime { get; set; }
}
