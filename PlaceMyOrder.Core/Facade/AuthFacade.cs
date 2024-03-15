using AutoMapper;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Core.Services;
using PlaceMyOrder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Core.Facade
{
    public class AuthFacade
    {
        private UserService userService;
        public AuthFacade(IUserRepository userRepository, IMapper mapper, IPasswordEncoder passwordEncoder)
        {
            userService = new UserService(userRepository, mapper, passwordEncoder);
        }

        public Task<User> CreateCustomerAsync(User customer)
        {
            return userService.CreateCustomerAsync(customer);
        }

        public Task<User> CreateAdminAsync(User admin)
        {
            return userService.CreateAdminAsync(admin);
        }

        public Task<User> GetUserByEmailAsync(String email)
        {
            return userService.FindUserByEmailAsync(email);
        }


        public Task<User> LoginAsync(string email, string password)
        {
            return userService.LoginAsync(email, password);
        }
    }
}
