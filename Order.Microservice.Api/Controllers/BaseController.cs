using Microsoft.AspNetCore.Mvc;
using Order.Microservice.Domain.Commands.Output;

namespace Order.Microservice.Api.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class BaseController : ControllerBase
{
    internal IActionResult ApiResponse<T>(CommandResult<T> commandResult)
    {
       return commandResult.IsSuccess ? Ok(commandResult.Value) : BadRequest(commandResult.Messages);
    }

    internal IActionResult ApiResponse(CommandResult commandResult)
    {
        return this.ApiResponseFormatResponse<object>(commandResult);
    }

    internal IActionResult ApiResponseFormatResponse<T>(CommandResult<T> commandResult)
    {
        return commandResult.IsSuccess ? Ok(commandResult.Value) : BadRequest(commandResult.Messages);
    }
}
