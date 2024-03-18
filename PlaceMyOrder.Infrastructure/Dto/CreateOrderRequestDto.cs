using PlaceMyOrder.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public class CreateOrderRequestDto
    {
        [Required]
        public AddressDto Address { get; set; }
        [Required]
        [MinLength(1)]
        public List<Guid> Meals { get; set; }
    }
}
