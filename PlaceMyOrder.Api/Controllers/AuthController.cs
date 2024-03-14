using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaceMyOrder.Infrastructure.Dto;
using PlaceMyOrder.Core.Facade;
using AutoMapper;
using PlaceMyOrder.Core.Model;

namespace PlaceMyOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthFacade authFacade;
        private readonly IMapper mapper;

        public AuthController(AuthFacade authFacade, IMapper mapper)
        {
            this.authFacade = authFacade;
            this.mapper = mapper;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateCustomer([FromBody] RegisterRequestDto registerRequestDto)
        {
            var customer = await authFacade.CreateCustomerAsync(mapper.Map<User>(registerRequestDto));
            return Ok();

        }
    }
}
