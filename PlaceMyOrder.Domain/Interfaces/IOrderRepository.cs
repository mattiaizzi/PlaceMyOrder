using PlaceMyOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderEntity> CreateAsync(OrderEntity order);
        Task<OrderEntity?> GetByIdAsync(Guid id);
        Task<(List<OrderEntity>, int totalElements)> GetListAsync(DateTime from, DateTime to, Guid? user, int pageSize = int.MaxValue, int pageIndex = 1);
    }
}
