using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaceMyOrder.Infrastructure.Dto;
using PlaceMyOrder.Core.Facade;
using AutoMapper;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Core.Exceptions;
using PlaceMyOrder.Infrastructure.Utils;

namespace PlaceMyOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthFacade authFacade;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public AuthController(AuthFacade authFacade, IMapper mapper, ILogger<AuthController> logger)
        {
            this.authFacade = authFacade;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateCustomer([FromBody] RegisterRequestDto registerRequestDto)
        {
            try
            {
                var customer = await authFacade.CreateCustomerAsync(mapper.Map<User>(registerRequestDto));
                return Ok(new { Message = Messages.UserRegistered });
            }
            catch (UserAlreadyExistsException ex)
            {
                logger.LogError(ex, $"user with email {registerRequestDto.Email} already exists");
                return UnprocessableEntity(new { Message = Messages.UserAlreadyExists });
            }
        }
    }
}
