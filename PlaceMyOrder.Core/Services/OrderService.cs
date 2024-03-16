using AutoMapper;
using PlaceMyOrder.Core.Exceptions;
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
            var saved = await orderRepository.CreateAsync(mapper.Map<OrderEntity>(order));
            return await GetById(saved.Id);

        }

        public async Task<Order?> GetById(Guid id)
        {
            var order = await orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new OrderNotFoundException();
            }
            return mapper.Map<Order>(order);
        }
    }
}
