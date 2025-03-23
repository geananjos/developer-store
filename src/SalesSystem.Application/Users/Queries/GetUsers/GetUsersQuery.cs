using MediatR;
using SalesSystem.Application.Common;
using SalesSystem.Application.Users.DTOs;

namespace SalesSystem.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<PaginatedResult<UserDto>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? Order { get; set; }
    }
}
