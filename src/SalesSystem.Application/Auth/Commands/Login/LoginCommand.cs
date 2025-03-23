using MediatR;

namespace SalesSystem.Application.Auth.Commands.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
