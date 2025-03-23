namespace SalesSystem.Domain.Carts.ValueObjects
{
    public class CartProduct
    {
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Discount { get; private set; }

        protected CartProduct() { }

        public CartProduct(int productId, int quantity, decimal discount)
        {
            ProductId = productId;
            Quantity = quantity;
            Discount = discount;
        }
    }
}
