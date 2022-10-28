using Microsoft.AspNetCore.Mvc;

namespace Platform.Controllers
{
    [ApiController]
    [Route("api/p/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {

            var names = new List<string> { "Dalim", "Salam", "Rasid" };

            Console.WriteLine("Getting result from test controller");

            return Ok(names);
        }
    }
}