using SalesSystem.Domain.Users.Enums;
using SalesSystem.Domain.Users.ValueObjects;

namespace SalesSystem.Domain.Users
{
    public class User
    {
        public int Id { get; private set; }

        public string Email { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        public Name Name { get; private set; } = default!;
        public Address Address { get; private set; } = default!;
        public string Phone { get; private set; } = string.Empty;

        public UserStatus Status { get; private set; }
        public UserRole Role { get; private set; }

        protected User() { }

        public User(
            string email,
            string username,
            string passwordHash,
            Name name,
            Address address,
            string phone,
            UserStatus status,
            UserRole role)
        {
            Email = email;
            Username = username;
            Password = passwordHash;
            Name = name;
            Address = address;
            Phone = phone;
            Status = status;
            Role = role;
        }

        public void Update(
            string email,
            string username,
            string passwordHash,
            Name name,
            Address address,
            string phone,
            UserStatus status,
            UserRole role)
        {
            Email = email;
            Username = username;
            Password = passwordHash;
            Name = name;
            Address = address;
            Phone = phone;
            Status = status;
            Role = role;
        }
    }
}
