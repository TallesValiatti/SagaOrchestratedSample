using Microsoft.AspNetCore.Mvc;
using Order.Microservice.Domain.Commands.Output;

namespace Order.Microservice.Api.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class BaseController : ControllerBase
{
    public IActionResult ApiResponse<T>(CommandResult<T> commandResult)
    {
        return commandResult.IsSuccess ? Ok(commandResult.Value) : BadRequest(commandResult.Messages);
    }
}
