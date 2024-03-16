using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Domain.Entities
{
    public class OrderMealEntity
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid MealId { get; set; }

        public MealEntity Meal { get; set; }

        public OrderEntity Order { get; set; }
    }
}
