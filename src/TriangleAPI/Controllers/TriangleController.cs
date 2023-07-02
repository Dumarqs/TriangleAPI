using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TriangleAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        public TriangleController() { 
        
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetMaximumTotalTriangle()
        {
            throw new Exception("Not implemented");
        }
    }
}
