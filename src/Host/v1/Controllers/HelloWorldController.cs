using Microsoft.AspNetCore.Mvc;

namespace PF.PfCoreHelloWorld.v1.Controllers
{
    [Route("HelloWorld")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Hello World 123!");
        }
    }
}
