namespace SalesSystem.Domain.Users.ValueObjects
{
    public class Name
    {
        public string Firstname { get; private set; } = null!;
        public string Lastname { get; private set; } = null!;

        protected Name() { }

        public Name(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
