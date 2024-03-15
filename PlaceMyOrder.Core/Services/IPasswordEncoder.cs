
namespace PlaceMyOrder.Core.Services
{
    public interface IPasswordEncoder
    {
        String Encode(String rawPassword);

        bool Matches(String rawPassword, String encodedPassword);
    }
}
