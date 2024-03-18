using PlaceMyOrder.Core.Exceptions;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Domain.Entities;
using PlaceMyOrder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Core.Strategies.OrderListStrategy
{
    public class CustomerOrderListStrategy : IOrderListStrategy
    {
        private readonly User customer;

        public CustomerOrderListStrategy(User customer)
        {
            this.customer = customer;
        }

        public Task<(List<OrderEntity> list, int size)> GetListAsync(IOrderRepository repository, OrderListFilter filter)
        {
            if (filter.UserId != null && filter.UserId != customer.Id)
            {
                throw new UnauthorizedException();
            }
            return repository.GetListAsync(filter.DateStart, filter.DateEnd, customer.Id, filter.Size ?? int.MaxValue, filter.Page ?? 1);
        }
    }
}
