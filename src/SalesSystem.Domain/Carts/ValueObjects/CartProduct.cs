namespace SalesSystem.Domain.Carts.ValueObjects
{
    public class CartProduct
    {
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }

        protected CartProduct() { }

        public CartProduct(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
