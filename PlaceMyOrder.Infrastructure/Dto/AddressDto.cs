using System.ComponentModel.DataAnnotations;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public class AddressDto
    {
        [Required]
        public String Street { get; set; }
        [Required]
        public String Number { get; set; }
        [Required]
        public String City { get; set; }
        [Required]
        public String PostalCode { get; set; }
    }
}