using PlaceMyOrder.Core.Model;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public class UserDto
    {
        public String Email { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Role { get; set; }
    }
}