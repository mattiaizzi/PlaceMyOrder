using PlaceMyOrder.Core.Model;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public class MealDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Double Price { get; set; }
        public String Course { get; set; }
    }
}