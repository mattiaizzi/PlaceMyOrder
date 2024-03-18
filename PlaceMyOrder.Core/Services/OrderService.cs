using AutoMapper;
using PlaceMyOrder.Core.Exceptions;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Core.Strategies.OrderListStrategy;
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
            await validateOrder(order);
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

        public async Task<Pageable<Order>> GetListAsync(IOrderListStrategy strategy, OrderListFilter filter)
        {
            var (orders, size) = await strategy.GetListAsync(orderRepository, filter);

            var pageSize = filter.Size ?? size;
            var pageNumber = filter.Page ?? 1;
            var pageCount = size > 0 ? (int)Math.Ceiling((double)size / pageSize) : 0;

            if (size > 0 && pageNumber > pageCount)
            {
                throw new PageExceedException();
            }

            return new Pageable<Order>
            {
                ElementCount = size,
                PageCount = pageCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
                Items = mapper.Map<List<Order>>(orders)
            };
        }

        private async Task validateOrder(Order order)
        {
            foreach (var meal in order.Meals)
            {
                if ((await GetById(meal.Id)) == null) { throw new OrderNotFoundException(); }
            }
        }
    }
}
