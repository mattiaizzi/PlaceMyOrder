using AutoMapper;
using PlaceMyOrder.Core.Exceptions;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Domain.Entities;
using PlaceMyOrder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Core.Services
{
    public class TokenService
    {
        private readonly ITokenRepository tokenRepository;
        private readonly IMapper mapper;

        public TokenService(ITokenRepository tokenRepository, IMapper mapper)
        {
            this.tokenRepository = tokenRepository;
            this.mapper = mapper;
        }

        public async Task InvalidateAllUserTokenAsync(User user)
        {
            var tokens = await tokenRepository.FindAllValidTokenByUserAsync(mapper.Map<UserEntity>(user));
            foreach (var token in tokens)
            {
                token.IsRevoked = true;
                await tokenRepository.UpdateAsync(token);
            }
        }

        public async Task SaveUserTokenAsync(User user, String token)
        {
            await tokenRepository.SaveAsync(new TokenEntity { IsRevoked = false, Token = token, UserId = user.Id });
        }

        public async Task ValidateTokenAsync(User user, string token)
        {
            var tokens = await tokenRepository.FindAllValidTokenByUserAsync(mapper.Map<UserEntity>(user));
            if (!tokens.Any(t => t.Token == token))
            {
                throw new UnauthorizedException();
            }
        }
    }
}
