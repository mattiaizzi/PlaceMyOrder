using Microsoft.EntityFrameworkCore;
using PlaceMyOrder.Domain.Entities;
using PlaceMyOrder.Domain.Interfaces;
using PlaceMyOrder.Infrastructure.Data;

namespace PlaceMyOrder.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PlaceMyOrderDbContext placeMyOrderDbContext;

        public UserRepository(PlaceMyOrderDbContext placeMyOrderDbContext)
        {
            this.placeMyOrderDbContext = placeMyOrderDbContext;
        }
        public async Task<UserEntity> AddAsync(UserEntity user)
        {
            await placeMyOrderDbContext.Users.AddAsync(user);
            await placeMyOrderDbContext.SaveChangesAsync();
            return user;
        }

        public Task<UserEntity?> FindByEmailAsync(string email)
        {
            return placeMyOrderDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
