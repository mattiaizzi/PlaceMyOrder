using AutoMapper;
using PlaceMyOrder.Core.Exceptions;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Domain.Entities;
using PlaceMyOrder.Domain.Interfaces;

namespace PlaceMyOrder.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IPasswordEncoder passwordEncoder;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordEncoder passwordEncoder)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.passwordEncoder = passwordEncoder;
        }

        internal async Task<User> CreateAdminAsync(User admin)
        {
            admin.Role = Role.Admin;
            return await AddAsync(admin);
        }

        internal async Task<User> CreateCustomerAsync(User customer)
        {
            customer.Role = Role.Customer;
            return await AddAsync(customer);
        }

        internal async Task<User> FindUserByEmailAsync(string email)
        {
            var user = await userRepository.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return mapper.Map<User>(user);
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await FindUserByEmailAsync(email);
            if (!passwordEncoder.Matches(password, user.Password))
            {
                throw new UserNotFoundException();
            }
            return mapper.Map<User>(user);
        }

        private async Task<User> AddAsync(User user)
        {
            var stored = await userRepository.FindByEmailAsync(user.Email);
            if (stored != null)
            {
                throw new UserAlreadyExistsException();
            }
            user.Password = passwordEncoder.Encode(user.Password);
            var saved = await userRepository.AddAsync(mapper.Map<UserEntity>(user));
            return mapper.Map<User>(saved);
        }
    }
}
