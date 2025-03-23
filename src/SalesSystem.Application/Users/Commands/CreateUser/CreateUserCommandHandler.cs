using AutoMapper;
using MediatR;
using SalesSystem.Application.Users.DTOs;
using SalesSystem.Domain.Users;
using SalesSystem.Domain.Users.Enums;
using SalesSystem.Domain.Users.Interfaces;
using SalesSystem.Domain.Users.ValueObjects;

namespace SalesSystem.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(
                request.Email,
                request.Username,
                request.Password,
                new Name(request.Name.Firstname, request.Name.Lastname),
                new Address(
                    request.Address.City,
                    request.Address.Street,
                    request.Address.Number,
                    request.Address.Zipcode,
                    new Geolocation(request.Address.Geolocation.Lat, request.Address.Geolocation.Long)
                ),
                request.Phone,
                Enum.Parse<UserStatus>(request.Status),
                Enum.Parse<UserRole>(request.Role)
            );

            await _repository.AddAsync(user);

            return _mapper.Map<UserDto>(user);
        }
    }
}
