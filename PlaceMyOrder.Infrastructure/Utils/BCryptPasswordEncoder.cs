using PlaceMyOrder.Core.Services;

namespace PlaceMyOrder.Infrastructure.Utils
{
    public class BCryptPasswordEncoder : IPasswordEncoder
    {
        public string Encode(string rawPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(rawPassword);
        }

        public bool Matches(string rawPassword, string encodedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(rawPassword, encodedPassword);
        }
    }
}
