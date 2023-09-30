using Carter;
using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Dtos;
using Northwind.Application;

namespace Northwind.Api.Endpoints;

public class ToDoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var todosGroup = app.MapGroup("api/v2/todos"); // we can set any ratelimiting policies at group level
        
        todosGroup.MapGet("new", GetToDoItems);

        todosGroup.MapGet("", async (IToDoService todoService) =>
        {
            var result = await todoService.GetToDoItems();
            return Results.Ok(result);
        });

        todosGroup.MapGet("{id}", async (int id, IToDoService todoService) =>
        {
            return await todoService.GetToDoItem(id);
        });

        todosGroup.MapPost("", async ([FromBody] ToDoItem todoItem, IToDoService todoService) =>
        {
            return await todoService.SetToDoItem(todoItem.ToDoItemName,
                todoItem.ToDoItemDescription,
                todoItem.PlannedFinishDateTime);
        });
    }

    //public static void MapToDoEndpoints(this IEndpointRouteBuilder app)
    //{
    //    var todosGroup = app.MapGroup("api/v2/todos"); // we can set any ratelimiting policies at group level
    //    todosGroup.MapGet("new", GetToDoItems);

    //    todosGroup.MapGet("", async (IToDoService todoService) =>
    //    {
    //        var result = await todoService.GetToDoItems();
    //        return Results.Ok(result);
    //    });

    //    todosGroup.MapGet("{id}", async (int id, IToDoService todoService) =>
    //    {
    //        return await todoService.GetToDoItem(id);
    //    });

    //    todosGroup.MapPost("", async ([FromBody]ToDoItem todoItem, IToDoService todoService) =>
    //    {
    //        return await todoService.SetToDoItem(todoItem.ToDoItemName,
    //            todoItem.ToDoItemDescription,
    //            todoItem.PlannedFinishDateTime);
    //    });
    //}

    public static async Task<IResult> GetToDoItems(IToDoService todoService)
    {
        var result = await todoService.GetToDoItems();
        return Results.Ok(result);
    }

}
