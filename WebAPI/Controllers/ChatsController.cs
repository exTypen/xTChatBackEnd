using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Controller]
[Route("api/[controller]")]
public class ChatsController : Controller
{
    private readonly IChatService _chatService;

    public ChatsController(IChatService chatService)
    {
        _chatService = chatService;
    }
    
    
    [HttpGet("GetAllDtos")]
    public IActionResult GetAllDtos()
    {
        var result = _chatService.GetAllDtos();
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}