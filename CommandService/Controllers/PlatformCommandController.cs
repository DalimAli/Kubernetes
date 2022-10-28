using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [ApiController]
    [Route("api/c/command")]
    public class PlatformCommandController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add([FromBody] string message)
        {
            Console.WriteLine("-------> Inbound Post from command service, {0}", message);
            return Ok("Inbound test of form Platform Command controller");
        }
    }
}