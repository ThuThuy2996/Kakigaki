using AutoMapper;
using KakigaiAPI;
using Kakigaki.Application.Interfaces.Auth;
using Kakigaki.Application.Mappings;
using Kakigaki.Application.Services;
using Kakigaki.Domain.Entities;
using Kakigaki.Domain.Interfaces.Auth;
using Kakigaki.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddAutoMapper(typeof(UserMappingProfile).Assembly);


        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();       
       
        return services;
    }
}
