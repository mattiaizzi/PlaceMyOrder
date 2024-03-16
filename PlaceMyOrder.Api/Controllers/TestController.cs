using Microsoft.AspNetCore.Mvc;
using PlaceMyOrder.Api.Helpers;

namespace PlaceMyOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Hello world");
        }
    }
}
