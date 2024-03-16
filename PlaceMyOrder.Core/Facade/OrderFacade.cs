using AutoMapper;
using PlaceMyOrder.Core.Exceptions;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Core.Services;
using PlaceMyOrder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Core.Facade
{
    public class OrderFacade
    {
        private readonly OrderService orderService;

        public OrderFacade(IOrderRepository orderRepository, IMapper mapper)
        {
            orderService = new OrderService(orderRepository, mapper);
        }
        public async Task<Order> CreateOrderAsync(User? user, Order order)
        {
            if (user == null && !ImmutableList.Create(Role.Customer).Contains(user.Role))
            {
                throw new UnauthorizedException($"{user.Role.ToString()} non è abilitato alla creazione di un ordine");
            }
            return await orderService.CreateAsync(order, user);
        }

        public async Task<Order?> GetOrderById(User? user, Guid id)
        {
            var order = await orderService.GetById(id);
            if (!ImmutableList.Create(Role.Admin).Contains(user.Role) && (order != null && user.Email != order.Customer.Email)) { throw new UnauthorizedException(); }
            return order;
        }
    }
}
