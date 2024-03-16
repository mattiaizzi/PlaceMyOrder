using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Domain.Entities;
using PlaceMyOrder.Domain.Interfaces;
using PlaceMyOrder.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Include(o => o.Meals)
                .FirstOrDefaultAsync(order => order.Id == id);
            return result;
        }
    }
}
