namespace SalesSystem.Application.Users.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public NameDto Name { get; set; } = null!;
        public AddressDto Address { get; set; } = null!;

        public string Phone { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Role { get; set; } = null!;
    }

    public class NameDto
    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
    }

    public class AddressDto
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int Number { get; set; }
        public string Zipcode { get; set; } = null!;
        public GeolocationDto Geolocation { get; set; } = null!;
    }

    public class GeolocationDto
    {
        public string Lat { get; set; } = null!;
        public string Long { get; set; } = null!;
    }

}
