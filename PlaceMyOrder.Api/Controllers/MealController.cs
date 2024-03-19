using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlaceMyOrder.Core.Facade;
using PlaceMyOrder.Infrastructure.Dto;

namespace PlaceMyOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly OrderFacade orderFacade;
        private readonly IMapper mapper;
        private readonly ILogger<MealController> logger;

        public MealController(OrderFacade orderFacade, IMapper mapper, ILogger<MealController> logger)
        {
            this.orderFacade = orderFacade;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<List<MealDto>>> GetAll()
        {
            var meals = await orderFacade.GetMeals();
            return Ok(mapper.Map<List<MealDto>>(meals));
        }
    }
}
