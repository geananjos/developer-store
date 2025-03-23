using MediatR;
using SalesSystem.Application.Users.DTOs;

namespace SalesSystem.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto?>
    {
        public int Id { get; set; }
    }
}
