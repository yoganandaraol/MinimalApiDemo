using Microsoft.AspNetCore.Mvc;
using Northwind.Application;
using Northwind.Application.Models;

namespace Northwind.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class ToDosController : ControllerBase
    {
        public IToDoService _todoService { get; set; }

        public ToDosController(IToDoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDoItem>> GetToDoItemsAsync()
        {
            return await _todoService.GetToDoItems();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ToDoItem> GetToDoItemByIdAsync([FromRoute]int id)
        {
            return await _todoService.GetToDoItem(id);
        }

        [HttpPost]
        public async Task<ToDoItem> CreateToDoItemAsync([FromBody] ToDoItem request)
        {
            return await _todoService.SetToDoItem(request.ToDoItemName, request.ToDoItemDescription, request.PlannedFinishDateTime);
        }
    }
}
