using NetCoreAssignment.Service.Contracts.Services;
using NetCoreAssignment.Service.Contracts.Dtos.Todos;
using Microsoft.AspNetCore.Mvc;
using NetCoreAssignment.Service.Authorization;

namespace NetCoreAssignmentAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private ITodoService _todoService;

        public TodosController(
            ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("todos")]
        public async Task<IActionResult> GetList([FromQuery] GetTodoListDto getTodoListDto)
        {
            var users = await _todoService.GetList(getTodoListDto);
            return Ok(users);
        }

        [HttpPost("todos")]
        public async Task<IActionResult> Create([FromQuery] CreateTodoDto model)
        {
            await _todoService.CreatAsync(model);
            return Ok(new { message = "Todo Created Successfuly." });
        }

        [HttpPut("todos")]
        public async Task<IActionResult> Update(int id, [FromQuery] UpdateTodoDto model)
        {
            await _todoService.UpdateAsync(id, model);
            return Ok(new { message = "Todo Updated Successfuly." });
        }

        [HttpDelete("todos")]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoService.DeleteAsync(id);
            return Ok(new { message = "Todo Deleted Successfuly." });
        }
    }
}
