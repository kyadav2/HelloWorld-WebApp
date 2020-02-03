using Microsoft.AspNetCore.Mvc;

namespace PF.PfCoreHelloWorld.v1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Hello World!");
        }
    }
}
