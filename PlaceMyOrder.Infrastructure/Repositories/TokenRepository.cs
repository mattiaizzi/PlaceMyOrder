using Microsoft.EntityFrameworkCore;
using PlaceMyOrder.Domain.Entities;
using PlaceMyOrder.Domain.Interfaces;
using PlaceMyOrder.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly PlaceMyOrderDbContext placeMyOrderDbContext;

        public TokenRepository(PlaceMyOrderDbContext placeMyOrderDbContext)
        {
            this.placeMyOrderDbContext = placeMyOrderDbContext;
        }
        public Task<List<TokenEntity>> FindAllValidTokenByUserAsync(UserEntity user)
        {
            return placeMyOrderDbContext.Tokens.Where(token => !token.IsRevoked && token.UserId == user.Email).ToListAsync();
        }

        public async Task<TokenEntity> SaveAsync(TokenEntity token)
        {
            await placeMyOrderDbContext.AddAsync(token);
            await placeMyOrderDbContext.SaveChangesAsync();
            return token;
        }

        public async Task<TokenEntity?> UpdateAsync(TokenEntity token)
        {
            var saved = await placeMyOrderDbContext.Tokens.FirstOrDefaultAsync(t => t.Id == token.Id);
            if (saved == null)
            {
                return null;
            }
            saved.IsRevoked = token.IsRevoked;
            await placeMyOrderDbContext.SaveChangesAsync();
            return saved;
        }
    }
}
