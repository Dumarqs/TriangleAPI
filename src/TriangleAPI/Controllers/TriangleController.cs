using Infra.CrossCutting.Logging.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace TriangleAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        private readonly ILoggerAdapter<TriangleController> _logger;
        private readonly ITriangleService _triangleService;

        public TriangleController(ILoggerAdapter<TriangleController> logger, ITriangleService triangleService) {
            _logger = logger;
            _triangleService = triangleService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetMaximumTotalTriangle()
        {
            _logger.LogInformation("Getting the total");
            return Ok(await _triangleService.GetMaximumTotalFromTextFile());
        }
    }
}
