using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public virtual MealEntity Meal { get; set; }

        public virtual OrderEntity Order { get; set; }
    }
}
