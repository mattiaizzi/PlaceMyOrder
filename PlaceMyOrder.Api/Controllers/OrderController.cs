using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaceMyOrder.Api.Helpers;
using PlaceMyOrder.Core.Facade;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Infrastructure.Dto;

namespace PlaceMyOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderFacade orderFacade;
        private readonly IMapper mapper;

        public OrderController(OrderFacade orderFacade, IMapper mapper)
        {
            this.orderFacade = orderFacade;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateOrderResponseDto>> Create([FromBody] CreateOrderRequestDto request)
        {
            var user = (User)HttpContext.Items["User"];
            var order = await orderFacade.CreateOrderAsync(user, mapper.Map<Order>(request));
            return Ok(new CreateOrderResponseDto { });
        }
    }
}
