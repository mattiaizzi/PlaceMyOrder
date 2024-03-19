using AutoMapper;
using PlaceMyOrder.Core.Exceptions;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Core.Services
{
    public class MealService
    {
        private readonly IMealRepository mealRepository;
        private readonly IMapper mapper;

        public MealService(IMealRepository mealRepository, IMapper mapper)
        {
            this.mealRepository = mealRepository;
            this.mapper = mapper;
        }

        public async Task<Meal> GetByIdAsync(Guid id)
        {
            var meal = await mealRepository.GetByIdAsync(id);
            if (meal == null)
            {
                throw new MealNotFoundException();
            }
            return mapper.Map<Meal>(meal);
        }

        public async Task<List<Meal>> GetListAsync()
        {
            var meals = await mealRepository.GetAllAsync();
            return mapper.Map<List<Meal>>(meals);
        }
    }
}
