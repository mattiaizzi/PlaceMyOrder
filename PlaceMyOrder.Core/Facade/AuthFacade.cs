using AutoMapper;
using Microsoft.Extensions.Options;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Core.Services;
using PlaceMyOrder.Domain.Interfaces;

namespace PlaceMyOrder.Core.Facade
{
    public class AuthFacade
    {
        private readonly UserService userService;
        private readonly JwtService jwtService;
        private readonly AppSettings appSettings;

        public AuthFacade(IOptions<AppSettings> appSettings, IUserRepository userRepository, IMapper mapper, IPasswordEncoder passwordEncoder)
        {
            this.appSettings = appSettings.Value;
            userService = new UserService(userRepository, mapper, passwordEncoder);
            jwtService = new JwtService(this.appSettings.JwtSecret, userService);
        }

        public Task<User> CreateCustomerAsync(User customer)
        {
            return userService.CreateCustomerAsync(customer);
        }

        public Task<User> CreateAdminAsync(User admin)
        {
            return userService.CreateAdminAsync(admin);
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            var user = await userService.LoginAsync(email, password);
            // TODO invalidare token precedenti utente
            var token = await jwtService.GenerateTokenAsync(user);
            return new LoginResponse() { Token = token };
        }

        public async Task<User> GetUserFromTokenAsync(string token)
        {
            var user = await jwtService.GetUserFromToken(token);
            // TODO validare token
            return user;
        }
    }
}
