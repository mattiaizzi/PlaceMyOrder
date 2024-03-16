using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlaceMyOrder.Api.Helpers;
using PlaceMyOrder.Core.Exceptions;
using PlaceMyOrder.Core.Facade;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Infrastructure.Dto;
using PlaceMyOrder.Infrastructure.Utils;

namespace PlaceMyOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderFacade orderFacade;
        private readonly IMapper mapper;
        private readonly ILogger<OrderController> logger;

        public OrderController(OrderFacade orderFacade, IMapper mapper, ILogger<OrderController> logger)
        {
            this.orderFacade = orderFacade;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateOrderResponseDto>> Create([FromBody] CreateOrderRequestDto request)
        {
            try
            {
                var user = (User)HttpContext.Items["User"];
                var order = await orderFacade.CreateOrderAsync(user, mapper.Map<Order>(request));
                return Ok(new CreateOrderResponseDto { Order = mapper.Map<OrderDto>(order) });
            }
            catch (UnauthorizedException ex)
            {
                logger.LogError(ex, "errore durante la creazione");
                return Unauthorized(new
                {
                    Message = Messages.Unauthorized
                });
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<ActionResult<CreateOrderResponseDto>> GetById([FromRoute] Guid id)
        {
            try
            {
                var user = (User)HttpContext.Items["User"];
                var order = await orderFacade.GetOrderById(user, id);
                return Ok(mapper.Map<OrderDto>(order));
            }
            catch (UnauthorizedException ex)
            {
                logger.LogError(ex, "L'utente non è autorizzato a vedere il dettaglio");
                return Unauthorized(new
                {
                    Message = Messages.Unauthorized
                });
            }
        }
    }
}
