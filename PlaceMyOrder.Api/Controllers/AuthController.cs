using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaceMyOrder.Infrastructure.Dto;
using PlaceMyOrder.Core.Facade;
using AutoMapper;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Core.Exceptions;
using PlaceMyOrder.Infrastructure.Utils;
using PlaceMyOrder.Api.Services;

namespace PlaceMyOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthFacade authFacade;
        private readonly JwtService jwtService;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public AuthController(AuthFacade authFacade, JwtService jwtService, IMapper mapper, ILogger<AuthController> logger)
        {
            this.authFacade = authFacade;
            this.jwtService = jwtService;
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

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                var user = await authFacade.LoginAsync(loginRequestDto.Email, loginRequestDto.Password);
                var token = await jwtService.GenerateToken(user);
                return Ok(new LoginResponseDto { Token = token });
            }
            catch (UserNotFoundException ex)
            {
                logger.LogError(ex, $"login failed {loginRequestDto.Email}");
                return Unauthorized(new { Message = Messages.LoginFailed });
            }
        }
    }
}
