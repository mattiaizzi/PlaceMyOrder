using System.ComponentModel.DataAnnotations;

namespace PlaceMyOrder.Api.Dto
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
