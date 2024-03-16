using AutoMapper;
using PlaceMyOrder.Infrastructure.Dto;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Domain.Entities;
using PlaceMyOrder.Infrastructure.Utils;
using System.Data;

namespace PlaceMyOrder.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, RegisterRequestDto>().ReverseMap();
            CreateMap<User, UserEntity>()
                .ForMember(destination => destination.RoleId, opt => opt.MapFrom(user => (int)user.Role))
                .ForMember(destination => destination.Role, opt => opt.Ignore());
            //.ForMember(destination => destination.Role, opt => opt.MapFrom(user => new RoleEntity { Id = (int)user.Role, Name = user.Role.ToString(), Description = EnumUtils.GetEnumDescription(user.Role) }));
            CreateMap<UserEntity, User>()
                .ForMember(destination => destination.Role, opt => opt.MapFrom(entity => (Role)entity.RoleId));
            CreateMap<LoginResponse, LoginResponseDto>().ReverseMap();
        }
    }
}
