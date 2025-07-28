using AutoMapper;
using Kakigaki.Application.DTOs.Auth;
using Kakigaki.Domain.Entities;
using Kakigaki.Domain.Enums;
using Kakigaki.Infrastructure.Data.Models;
namespace Kakigaki.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterRequest, User>()
                     .ForMember(dest => dest.GoogleId, opt => opt.MapFrom(src => src.GoogleId))
                     .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                     .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                     .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                     .ForMember(dest => dest.Id, opt => opt.Ignore())
                     .ForMember(dest => dest.Role, opt => opt.MapFrom(_ => Role.Free));

            CreateMap<User, user>().ReverseMap();
            CreateMap<User, AuthResponse>();
        }
    }
}
