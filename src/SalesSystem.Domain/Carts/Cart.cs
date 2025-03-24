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

        public Cart(int userId, DateTime date, List<(int productId, int quantity)> items)
        {
            UserId = userId;
            Date = date;
            Products = new();

            foreach (var (productId, quantity) in items)
            {
                AddProduct(productId, quantity);
            }
        }

        public void Update(int userId, DateTime date, List<(int productId, int quantity)> items)
        {
            UserId = userId;
            Date = date;
            Products.Clear();

            foreach (var (productId, quantity) in items)
            {
                AddProduct(productId, quantity);
            }
        }

        public void AddProduct(int productId, int quantity)
        {
            if (quantity > 20)
                throw new InvalidOperationException("Não é permitido vender mais de 20 unidades do mesmo produto.");

            var discount = GetDiscountForQuantity(quantity);
            Products.Add(new CartProduct(productId, quantity, discount));
        }

        private decimal GetDiscountForQuantity(int quantity)
        {
            if (quantity < 4) return 0.0m;
            if (quantity < 10) return 0.10m;
            return 0.20m;
        }
    }

}
