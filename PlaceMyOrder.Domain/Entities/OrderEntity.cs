using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Domain.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }

        public int OrderNumber { get; set; }

        public String Street { get; set; }
        public String StreetNumber { get; set; }
        public String City { get; set; }
        public String PostalCode { get; set; }
        public DateTime CreationDate { get; set; }
        public String CustomerId { get; set; }

        public virtual List<OrderMealEntity> OrderMeals { get; set; }
        public virtual List<MealEntity> Meals { get; set; }
        public virtual UserEntity Customer { get; set; }
    }
}
