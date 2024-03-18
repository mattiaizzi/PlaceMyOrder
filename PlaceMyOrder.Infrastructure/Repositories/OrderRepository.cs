using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PlaceMyOrder.Domain.Entities;
using PlaceMyOrder.Domain.Interfaces;
using PlaceMyOrder.Infrastructure.Data;
namespace PlaceMyOrder.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PlaceMyOrderDbContext placeMyOrderDbContext;

        public OrderRepository(PlaceMyOrderDbContext placeMyOrderDbContext)
        {
            this.placeMyOrderDbContext = placeMyOrderDbContext;
        }
        public async Task<OrderEntity> CreateAsync(OrderEntity order)
        {
            var mealIds = from meal in order.Meals select meal.Id;
            order.Meals = null;
            await placeMyOrderDbContext.AddAsync(order);
            foreach (var mealId in mealIds)
            {
                await placeMyOrderDbContext.AddAsync(new OrderMealEntity { MealId = mealId, OrderId = order.Id });
            }
            await placeMyOrderDbContext.SaveChangesAsync();
            return order;
        }

        public async Task<OrderEntity?> GetByIdAsync(Guid id)
        {
            var result = await placeMyOrderDbContext
                .Orders
                .Include(o => o.Customer)
                .Include(o => o.Meals)
                .FirstOrDefaultAsync(order => order.Id == id);
            return result;
        }

        public async Task<(List<OrderEntity>, int totalElements)> GetListAsync(DateTime from, DateTime to, Guid? user, int pageSize = int.MaxValue, int pageIndex = 1)
        {
            var queryableList = placeMyOrderDbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Meals)
                .Where(o => from <= o.CreationDate && o.CreationDate <= to)
                .AsQueryable();

            if (user != null)
            {
                queryableList = queryableList.Where(o => o.CustomerId == user);
            }

            int skip = pageSize == int.MaxValue ? 0 : pageSize * (pageIndex - 1);
            var size = await queryableList.CountAsync();
            queryableList = queryableList.Skip(skip).Take(pageSize);
            return (await queryableList.ToListAsync(), size);

        }
    }
}
