using Microsoft.AspNetCore.Mvc;

namespace RestASPNET.Api.Controllers
{
    [Route("TestLogs")]
    [ApiController]
    public class TestLogsController : ControllerBase
    {
        private readonly ILogger<TestLogsController> _logger;

        public TestLogsController(ILogger<TestLogsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult LogTest()
        {
            _logger.LogTrace("This is a trace log message");
            _logger.LogDebug("This is a debug log message");
            _logger.LogInformation("GET request received");
            _logger.LogWarning("This is a warning log message");
            _logger.LogError("This is an error log message");
            _logger.LogCritical("This is a critical log message");

            return Ok("Test log message");
        }
    }
}
