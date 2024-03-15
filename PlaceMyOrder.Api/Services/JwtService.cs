using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlaceMyOrder.Core.Facade;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Infrastructure.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlaceMyOrder.Api.Services
{
    public class JwtService
    {
        private readonly AppSettings appSettings;
        private readonly AuthFacade authFacade;

        public JwtService(AuthFacade authFacade, IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
            this.authFacade = authFacade;
        }

        public async Task<User> GetUserFromToken(String token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.JwtSecret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var email = jwtToken.Claims.First(x => x.Type == "email").Value;


            return await authFacade.GetUserByEmailAsync(email);
        }

        public async Task<String> GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                var key = Encoding.ASCII.GetBytes(appSettings.JwtSecret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] {
                        new Claim("email", user.Email),
                        new Claim("name", user.Name),
                        new Claim("lastname", user.LastName),
                        new Claim("role", user.Role.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);

        }
    }
}
