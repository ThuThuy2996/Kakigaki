using Kakigaki.Infrastructure.Data.Models;
namespace Kakigaki.Application.Interfaces;

public interface IUserRepository
{
    User CreateUser(string email, string password);
}