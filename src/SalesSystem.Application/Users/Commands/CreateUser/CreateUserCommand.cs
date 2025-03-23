using MediatR;
using SalesSystem.Application.Users.DTOs;

namespace SalesSystem.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Email { get; init; } = null!;
        public string Username { get; init; } = null!;
        public string Password { get; init; } = null!;

        public NameDto Name { get; init; } = null!;
        public AddressDto Address { get; init; } = null!;

        public string Phone { get; init; } = null!;
        public string Status { get; init; } = null!;
        public string Role { get; init; } = null!;
    }
}
