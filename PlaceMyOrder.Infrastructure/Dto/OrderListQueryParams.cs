using System.ComponentModel.DataAnnotations;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public class OrderListQueryParams : PageableRequestDto
    {
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        public Guid? UserId { get; set; }
    }

}
