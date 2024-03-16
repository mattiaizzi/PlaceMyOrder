using Microsoft.AspNetCore.Mvc;
using PlaceMyOrder.Api.Helpers;
using PlaceMyOrder.Core.Model;

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
            var user = (User)HttpContext.Items["User"];
            return Ok("Hello world");
        }
    }
}
