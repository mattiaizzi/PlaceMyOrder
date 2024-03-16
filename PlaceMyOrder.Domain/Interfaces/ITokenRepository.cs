using PlaceMyOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Domain.Interfaces
{
    public interface ITokenRepository
    {
        Task<List<TokenEntity>> FindAllValidTokenByUserAsync(UserEntity user);
        Task<TokenEntity?> UpdateAsync(TokenEntity token);
        Task<TokenEntity> SaveAsync(TokenEntity token);
    }
}
