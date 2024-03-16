using PlaceMyOrder.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public class CreateOrderResponseDto
    {
        public Guid Id { get; set; }
        public User Customer { get; set; }
        public DateTime CreationDate { get; set; }
        public int OrderNumber { get; set; }
        public Address Address { get; set; }
        public List<Meal> Meals { get; set; }
    }
}
