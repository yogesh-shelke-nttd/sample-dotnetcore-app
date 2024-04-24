using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> HelloWorld()
        {
            return "Hello World!";
        }
        [HttpGet("{name}")]
        public ActionResult<string> SayHello(string name)
        {
            return $"Hello {name}!";
        }
        [HttpGet("json/{name}")]
        public ActionResult<object> SayHelloJson(string name)
        {
            var greeting = new { Message = $"Hello {name}!" };
            return Ok(greeting);
        }
        [HttpGet("serverinfo")]
        public ActionResult<object> GetServerInfo()
        {
            var hostName = Environment.MachineName;
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            var serverInfo = new
            {
                HostName = hostName,
                IpAddress = ipAddress
            };

            return Ok(serverInfo);
        }
    }
}
