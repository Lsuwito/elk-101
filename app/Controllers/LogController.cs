using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MyApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogger _logger;

        public LogController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpPost("/Info")]
        public IActionResult PostInfo([FromBody] Log log)
        {
            _logger.Information(log.Message);
            return Ok();
        }

        [HttpPost("/Error")]
        public IActionResult PostError([FromBody] Log log)
        {
            _logger.Error(log.Message);
            return Ok();
        }
    }

    public class Log {
        public string Message { get; set; }
    }
}