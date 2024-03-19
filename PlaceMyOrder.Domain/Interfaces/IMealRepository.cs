using PlaceMyOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Domain.Interfaces
{
    public interface IMealRepository
    {
        Task<List<MealEntity>> GetAllAsync();
        Task<MealEntity?> GetByIdAsync(Guid id);
    }
}
