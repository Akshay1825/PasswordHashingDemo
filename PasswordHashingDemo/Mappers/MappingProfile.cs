using AutoMapper;
using PasswordHashingDemo.DTOs;
using PasswordHashingDemo.Models;

namespace PasswordHashingDemo.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.PasswordHash, 
                opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));
            CreateMap<User, UserDto>();
        }
    }
}
