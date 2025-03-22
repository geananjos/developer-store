namespace SalesSystem.Domain.Users.ValueObjects
{
    public class Address
    {
        public string City { get; private set; } = null!;
        public string Street { get; private set; } = null!;
        public int Number { get; private set; }
        public string Zipcode { get; private set; } = null!;
        public Geolocation Geolocation { get; private set; } = null!;

        protected Address() { }

        public Address(string city, string street, int number, string zipcode, Geolocation geolocation)
        {
            City = city;
            Street = street;
            Number = number;
            Zipcode = zipcode;
            Geolocation = geolocation;
        }
    }
}
