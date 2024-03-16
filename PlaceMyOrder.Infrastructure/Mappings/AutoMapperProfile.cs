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
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<User, UserEntity>()
                .ForMember(destination => destination.RoleId, opt => opt.MapFrom(user => (int)user.Role))
                .ForMember(destination => destination.Role, opt => opt.Ignore());
            CreateMap<UserEntity, User>()
                .ForMember(destination => destination.Role, opt => opt.MapFrom(entity => (Role)entity.RoleId));

            CreateMap<LoginResponse, LoginResponseDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<CreateOrderRequestDto, Order>()
                .ForMember(destination => destination.Meals, opt => opt.MapFrom(request => (from mealId in request.Meals select new Meal { Id = mealId }).ToList<Meal>()));

            CreateMap<Order, OrderEntity>()
                .ForMember(destination => destination.Customer, opt => opt.Ignore())
                .ForMember(destintation => destintation.CustomerId, opt => opt.MapFrom(order => order.Customer.Email))
                .ForMember(destintation => destintation.Street, opt => opt.MapFrom(order => order.Address.Street))
                .ForMember(destintation => destintation.StreetNumber, opt => opt.MapFrom(order => order.Address.Number))
                .ForMember(destintation => destintation.City, opt => opt.MapFrom(order => order.Address.City))
                .ForMember(destintation => destintation.PostalCode, opt => opt.MapFrom(order => order.Address.PostalCode));
            CreateMap<OrderEntity, Order>()
                .ForMember(destination => destination.Address, opt => opt.MapFrom(entity => new Address { City = entity.City, Number = entity.StreetNumber, PostalCode = entity.PostalCode, Street = entity.Street }));

            CreateMap<Meal, MealEntity>()
                .ForMember(destination => destination.CourseId, opt => opt.MapFrom(meal => (int)meal.Course))
                .ForMember(destination => destination.Course, opt => opt.Ignore());

            CreateMap<MealEntity, Meal>()
                .ForMember(destination => destination.Course, opt => opt.MapFrom(meal => (Course)meal.CourseId));
            CreateMap<MealDto, Meal>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();

        }
    }
}
