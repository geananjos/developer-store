namespace SalesSystem.Application.Products.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Image { get; set; } = null!;
        public decimal RatingRate { get; set; }
        public int RatingCount { get; set; }
    }
}
