using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.BLL;
using TodoApp.BLL.DTO;
using TodoApp.DAL.Data;
using TodoApplication.Contracts.V1;

namespace TodoApplication.Controllers.V1
{
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoService _todoService;

        public TodoController(ILogger<TodoController> logger, ITodoService todoService)
        {
            _todoService = todoService;
            _logger = logger;
        }

        [HttpGet(ApiRoutes.Todo.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_todoService.GetAll());
        }

        [HttpGet(ApiRoutes.Todo.Get)]   
        public IActionResult Get(Guid id)
        {
            var todo = _todoService.Get(id);
            return Ok(todo);
        }

        [HttpPost(ApiRoutes.Todo.Create)]
        public IActionResult Post([FromBody] TodoRequest todoRequest)
        {
            var result = this._todoService.Insert(todoRequest);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + ApiRoutes.Todo.Get.Replace("{id}", result.Id.ToString());
            return Created(locationUrl, result);
        }
    }
}