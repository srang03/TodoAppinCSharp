using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository<TodoModel> _repository;

        public TodosController()
        {
            _repository = new TodoRepositoryJSON("C:\\Users\\Ian\\Desktop\\ian\\C#\\TodoAppinCSharp\\TodoApp\\Todo.ConsoleApp\\Todo.json");
        }
        

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromBody] TodoModel todo)
        {
            _repository.AddTodo(todo);
            return Ok(todo);
        }
    }

}
