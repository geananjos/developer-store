using SalesSystem.Domain.Carts;

namespace SalesSystem.Tests.Carts
{
    public class CartDomainRulesTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(3, 0)]
        [InlineData(4, 0.10)]
        [InlineData(9, 0.10)]
        [InlineData(10, 0.20)]
        [InlineData(20, 0.20)]
        public void Should_Apply_Correct_Discount_Based_On_Quantity(int quantity, decimal expectedDiscount)
        {
            var cart = new Cart(1, DateTime.UtcNow, new List<(int productId, int quantity)>());
            cart.AddProduct(101, quantity);
            
            var product = cart.Products.First(p => p.ProductId == 101);
            Assert.Equal(expectedDiscount, product.Discount);
        }

        [Fact]
        public void Should_Throw_Exception_When_Quantity_Exceeds_20()
        {
            var cart = new Cart(1, DateTime.UtcNow, new List<(int productId, int quantity)>());
            var ex = Assert.Throws<InvalidOperationException>(() => cart.AddProduct(1, 21));
            
            Assert.Contains("não é permitido vender mais de 20", ex.Message.ToLower());
        }
    }
}
