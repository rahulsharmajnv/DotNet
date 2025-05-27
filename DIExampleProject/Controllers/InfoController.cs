// Controller
using DIExampleProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DIExampleProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMessageServiceV2 _messageServiceV2;
        public InfoController(IMessageService messageService, IMessageServiceV2 messageServiceV2)
        {
            _messageService = messageService;
            _messageServiceV2 = messageServiceV2;
        }

        [HttpGet("message")]
        public IActionResult GetMessage()
        {
            var result1= _messageService.GetMessage();
            System.Threading.Thread.Sleep(1000);
            var result2 = _messageServiceV2.GetMessage();
            if (result1 != result2)
            {
                return BadRequest("The messages are not consistent.");
            }
            return Ok(_messageService.GetMessage());
        }
    }
}