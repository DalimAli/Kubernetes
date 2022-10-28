using Microsoft.AspNetCore.Mvc;
using Platform.HttpCommand;
using Platform.Models;
using Platform.Repository;

namespace Platform.Controllers
{
    [ApiController]
    [Route("api/p/platform")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IClientCommand _clientCommand;

        public PlatformController(IPlatformRepository platformRepository, IClientCommand clientCommand)
        {
            _platformRepository = platformRepository;
            _clientCommand = clientCommand;
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult Get(long id)
        {

            var platform = _platformRepository.Get(id);
            if (platform == null)
            {
                Console.WriteLine("Platform not found");
                return NotFound();
            }
            return Ok(platform);
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var platforms = _platformRepository.GetAll();
            if (platforms == null)
            {
                Console.WriteLine("Platform not found");
                Console.WriteLine("Happy path");
                return NotFound();
            }
            return Ok(platforms);
        }

        [HttpPost]
        public IActionResult Add(Platforms platform)
        {

            var platforms = _platformRepository.Add(platform);

            try
            {
                Console.WriteLine("----------> Sending request to command service");
                _clientCommand.Post(platform.Remarks);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Created("platform created", platforms);
        }

        [HttpPut]
        [Route("{id:long}")]
        public IActionResult Edit(long id, Platforms platform)
        {
            Console.WriteLine("Put works");
            var platforms = _platformRepository.Edit(id, platform);

            try
            {
                Console.WriteLine("----------> Sending request to command service");
                _clientCommand.Post(platform.Remarks);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Created("platform updated", platforms);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IActionResult Delete(long id)
        {
            try
            {

                _platformRepository.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e);
            }
            return Ok();
        }
    }
}