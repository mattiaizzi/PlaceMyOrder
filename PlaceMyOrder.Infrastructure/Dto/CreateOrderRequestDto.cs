using PlaceMyOrder.Core.Model;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public class CreateOrderRequestDto
    {
        public AddressDto Address { get; set; }
        public List<Guid> Meals { get; set; }
    }
}
