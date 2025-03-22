namespace SalesSystem.Domain.Users.ValueObjects
{
    public class Geolocation
    {
        public string Lat { get; private set; } = null!;
        public string Long { get; private set; } = null!;

        protected Geolocation() { }

        public Geolocation(string lat, string @long)
        {
            Lat = lat;
            Long = @long;
        }
    }
}
