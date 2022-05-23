using Microsoft.AspNetCore.Mvc;

namespace SampleApp.API.Controllers
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Todo> _todoList = new List<Todo>();

            _todoList.Add(new Todo
            {
                Id = 1,
                Name = "Learn JavaScript",
                Done = true,
            });
            _todoList.Add(new Todo
            {
                Id = 2,
                Name = "Learn React",
                Done = false
            });

            return Ok(_todoList);
        }
    }
}