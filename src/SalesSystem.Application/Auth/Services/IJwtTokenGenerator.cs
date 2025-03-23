using SalesSystem.Domain.Users;

namespace SalesSystem.Application.Auth.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
