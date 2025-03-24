namespace SalesSystem.Tests.Users
{
    using Moq;
    using SalesSystem.Application.Auth.Commands.Login;
    using SalesSystem.Application.Auth.Services;
    using SalesSystem.Domain.Users;
    using SalesSystem.Domain.Users.Interfaces;
    using Xunit;

    public class LoginCommandHandlerTests
    {
        [Fact]
        public async Task Should_Return_Token_When_Username_And_Password_Are_Valid()
        {
            var user = new User("email", "username", BCrypt.Net.BCrypt.HashPassword("password"),
                new("First", "Last"),
                new("City", "Street", 1, "00000-000", new("-23", "-46")),
                "123", Domain.Users.Enums.UserStatus.Active, Domain.Users.Enums.UserRole.Customer);

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetByUsernameAsync("username")).ReturnsAsync(user);

            var mockJwt = new Mock<IJwtTokenGenerator>();
            mockJwt.Setup(j => j.GenerateToken(user)).Returns("fake-jwt-token");

            var handler = new LoginCommandHandler(mockRepo.Object, mockJwt.Object);

            var command = new LoginCommand { Username = "username", Password = "password" };
            
            var result = await handler.Handle(command, default);

            Assert.Equal("fake-jwt-token", result.Token);
        }
    }
}
