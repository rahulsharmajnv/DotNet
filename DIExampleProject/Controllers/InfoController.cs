// Controller
using DIExampleProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using  DIExampleProject.Delegates;
using DIExampleProject.Generics.EventHandlerSample.Implementation;

namespace DIExampleProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMessageServiceV2 _messageServiceV2;
        private readonly EventDispatcher _eventDispatcher;
        public InfoController(IMessageService messageService, IMessageServiceV2 messageServiceV2, EventDispatcher eventDispatcher)
        {
            _messageService = messageService;
            _messageServiceV2 = messageServiceV2;
            _eventDispatcher = eventDispatcher;
        }

        [HttpGet("message")]
        public IActionResult GetMessage()
        {
            var result1 = _messageService.GetMessage();
            System.Threading.Thread.Sleep(1000);
            var result2 = _messageServiceV2.GetMessage();
            if (result1 != result2)
            {
                return BadRequest("The messages are not consistent.");
            }
            return Ok(_messageService.GetMessage());
        }
        [HttpGet("delegate")]
        public  async Task <IActionResult> GetDelegateMessage()
        {
            var evt= new UserRegisteredEvent { UserName = "John Doe" };
            // Dispatch the event
            await _eventDispatcher.DispatchAsync(evt);

            DelegateType.GreetingDelegate greetingDelegate = (name) => $"Hello, {name}!";
            DelegateType.LoggerDelegate loggerDelegate = LogeMessage;
            loggerDelegate += LogeMessageV2;
            DelegateType.MathOperation addOperation = (x, y) => x + y;
            loggerDelegate("This is a log message.");
            var sum = addOperation(5, 10);

            // and return it in the response

            var result = greetingDelegate("World");
            return Ok(new
            {
                Greeting = result,
                Sum = sum
            });
        }
        private void LogeMessage(string message)
        {

            Console.WriteLine(message + "Test");
        }
        private void LogeMessageV2(string message)
        {
            Console.WriteLine($"{message} - Logged at {DateTime.Now}");
        }
    }
}   