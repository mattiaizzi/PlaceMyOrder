using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Domain.Entities
{
    public class MealEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public Double Price { get; set; }
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }

        public List<OrderEntity> Orders { get; set; }
    }
}
