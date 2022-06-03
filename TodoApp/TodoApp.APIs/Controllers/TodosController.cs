using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.APIs.Controllers
{
    [Route("api/[Controller]")]
    public class TodosController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            return Content("안녕하세요");
        }

        [HttpPost]
        public IActionResult Add([FromBody]TodoModel todo)
        {
            return Ok("todo");
        }
    }
}
