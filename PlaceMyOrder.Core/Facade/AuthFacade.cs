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
        public AuthFacade(IUserRepository userRepository, IMapper mapper)
        {
            userService = new UserService(userRepository, mapper);
        }

        public Task<User> CreateCustomerAsync(User customer)
        {
            return userService.CreateCustomerAsync(customer);
        }

        public Task<User> CreateAdminAsync(User admin)
        {
            return userService.CreateAdminAsync(admin);
        }


    }
}
