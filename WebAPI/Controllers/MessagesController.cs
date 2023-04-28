using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessagesController : Controller
{
    private IMessageService _messageService;

    public MessagesController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpPost("Add")]
    public IActionResult Add(Message message)
    {
        var result = _messageService.Add(message);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    
}