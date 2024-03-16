using PlaceMyOrder.Core.Model;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public UserDto Customer { get; set; }
        public DateTime CreationDate { get; set; }
        public int OrderNumber { get; set; }
        public double Total { get; set; }
        public AddressDto Address { get; set; }
        public List<MealDto> Meals { get; set; }
    }
}