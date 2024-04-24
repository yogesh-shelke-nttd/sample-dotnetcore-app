using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("/")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;
        private readonly IConfiguration _configuration;
            
        public HelloWorldController(ILogger<HelloWorldController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<string> HelloWorld()
        {
            string mySetting = _configuration?["ConnectionString"] ?? "DefaultConnectionString";
            return $"Hello World with config: {mySetting}";
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
