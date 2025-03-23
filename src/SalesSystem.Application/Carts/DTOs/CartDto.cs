namespace SalesSystem.Application.Carts.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public List<CartProductDto> Products { get; set; } = new();
    }

    public class CartProductDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
