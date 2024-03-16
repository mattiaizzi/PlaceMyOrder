using AutoMapper;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Domain.Entities;
using PlaceMyOrder.Domain.Interfaces;

namespace PlaceMyOrder.Core.Services
{
    public class OrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task<Order> CreateAsync(Order order, User customer)
        {
            order.CreationDate = DateTime.Now;
            order.Customer = customer;
            await orderRepository.CreateAsync(mapper.Map<OrderEntity>(order));
            return null;
        }
    }
}
