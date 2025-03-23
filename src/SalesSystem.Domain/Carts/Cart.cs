using SalesSystem.Domain.Carts.ValueObjects;

namespace SalesSystem.Domain.Carts
{
    public class Cart
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public DateTime Date { get; private set; }
        public List<CartProduct> Products { get; private set; } = new();

        protected Cart() { }

        public Cart(int userId, DateTime date, List<CartProduct> products)
        {
            UserId = userId;
            Date = date;
            Products = products;
        }

        public void Update(int userId, DateTime date, List<CartProduct> products)
        {
            UserId = userId;
            Date = date;
            Products = products;
        }
    }
}
