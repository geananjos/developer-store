using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Application.Common;
using SalesSystem.Application.Common.Extensions;
using SalesSystem.Application.Users.DTOs;
using SalesSystem.Domain.Users.Interfaces;

namespace SalesSystem.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PaginatedResult<UserDto>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Query();

            if (!string.IsNullOrWhiteSpace(request.Order))
            {
                var orderParams = request.Order.Split(',');
                foreach (var param in orderParams.Reverse())
                {
                    var trimmed = param.Trim();
                    var descending = trimmed.EndsWith(" desc");
                    var property = trimmed.Replace(" desc", "").Replace(" asc", "").Trim();

                    query = query.OrderByDynamic(property, descending);
                }
            }

            var totalItems = await query.CountAsync(cancellationToken);
            var users = await query
                .Skip((request.Page - 1) * request.Size)
                .Take(request.Size)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PaginatedResult<UserDto>(users, totalItems, request.Page, request.Size);
        }
    }
}
