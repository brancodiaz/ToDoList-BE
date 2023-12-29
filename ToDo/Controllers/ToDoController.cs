using Microsoft.AspNetCore.Mvc;
using ToDo.Application;
using ToDo.Application.Dto;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController(IToDoService toDoService) : ControllerBase
    {

        [HttpGet("all-pending")]
        [ProducesResponseType(typeof(IEnumerable<GetToDoListResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPendingToDoListAsync()
        {
            int id = 1;
            return Ok(await toDoService.GetPendingToDoListAsync(id));
        }

        [HttpGet("all-finished")]
        [ProducesResponseType(typeof(IEnumerable<GetToDoListResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFinishedToDoListAsync()
        {
            int id = 1;
            return Ok(await toDoService.GetFinishedToDoListAsync(id));
        }

        [HttpPost()]
        public async Task<IActionResult> AddNewToDoItemAsync([FromBody] AddNewToDoItemRequest addNewToDoItemRequest)
        {
            return Ok(await toDoService.AddNewToDoItemAsync(addNewToDoItemRequest));
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PatchToDoItemAsync(int id)
        {
            return Ok(await toDoService.PatchToDoItemAsync(id));
        }
    }
}