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
    public class AdminOrderListStrategy : IOrderListStrategy
    {
        public Task<(List<OrderEntity> list, int size)> GetListAsync(IOrderRepository repository, OrderListFilter filter)
        {
            return repository.GetListAsync(filter.DateStart, filter.DateEnd, filter.UserId, filter.Size ?? int.MaxValue, filter.Page ?? 1);
        }
    }
}
