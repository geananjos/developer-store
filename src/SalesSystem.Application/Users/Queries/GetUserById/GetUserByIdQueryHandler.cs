using AutoMapper;
using MediatR;
using SalesSystem.Application.Users.DTOs;
using SalesSystem.Domain.Users.Interfaces;

namespace SalesSystem.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            return user is null ? null : _mapper.Map<UserDto>(user);
        }
    }
}
