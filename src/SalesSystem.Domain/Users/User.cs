using SalesSystem.Domain.Users.Enums;
using SalesSystem.Domain.Users.ValueObjects;

namespace SalesSystem.Domain.Users
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; } = null!;
        public string Username { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public Name Name { get; private set; } = null!;
        public Address Address { get; private set; } = null!;
        public string Phone { get; private set; } = null!;
        public UserStatus Status { get; private set; }
        public UserRole Role { get; private set; }

        protected User() { }

        public User(string email, string username, string password, Name name, Address address, string phone, UserStatus status, UserRole role)
        {
            Email = email;
            Username = username;
            Password = password;
            Name = name;
            Address = address;
            Phone = phone;
            Status = status;
            Role = role;
        }

        public void Update(string email, string username, string password, Name name, Address address, string phone, UserStatus status, UserRole role)
        {
            Email = email;
            Username = username;
            Password = password;
            Name = name;
            Address = address;
            Phone = phone;
            Status = status;
            Role = role;
        }
    }
}
