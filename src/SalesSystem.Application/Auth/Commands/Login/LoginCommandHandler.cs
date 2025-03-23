﻿using MediatR;
using SalesSystem.Application.Auth.Services;
using SalesSystem.Domain.Users.Interfaces;

namespace SalesSystem.Application.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public LoginCommandHandler(IUserRepository userRepository, IJwtTokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);

            if (user == null || user.Password != request.Password)
                return new LoginResponse(); // retorna token vazio = não autenticado

            var token = _tokenGenerator.GenerateToken(user);
            return new LoginResponse { Token = token };
        }
    }

}
