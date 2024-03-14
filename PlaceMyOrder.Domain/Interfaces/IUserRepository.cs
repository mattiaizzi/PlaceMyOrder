using PlaceMyOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserEntity> AddAsync(UserEntity user);

        public Task<UserEntity?> FindByEmailAsync(String email);
    }
}
