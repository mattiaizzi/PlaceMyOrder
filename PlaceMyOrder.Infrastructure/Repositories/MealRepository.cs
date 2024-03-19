using Microsoft.EntityFrameworkCore;
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
    public class MealRepository : IMealRepository
    {
        private readonly PlaceMyOrderDbContext placeMyOrderDbContext;

        public MealRepository(PlaceMyOrderDbContext placeMyOrderDbContext)
        {
            this.placeMyOrderDbContext = placeMyOrderDbContext;
        }
        public Task<List<MealEntity>> GetAllAsync()
        {
            return placeMyOrderDbContext.Meals.ToListAsync();
        }

        public Task<MealEntity?> GetByIdAsync(Guid id)
        {
            return placeMyOrderDbContext.Meals.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
