using AutoMapper;
using Moq;
using SalesSystem.Application.Products.Commands.CreateProduct;
using SalesSystem.Application.Products.DTOs;
using SalesSystem.Domain.Products;
using SalesSystem.Domain.Products.Interfaces;
using SalesSystem.Domain.Products.ValueObjects;


namespace SalesSystem.Tests.Products
{
    public class CreateProductCommandHandlerTests
    {
        [Fact]
        public async Task Should_Create_Product_And_Return_Dto()
        {
            var mockRepo = new Mock<IProductRepository>();
            var mockMapper = new Mock<IMapper>();

            var product = new Product("Book", 99.99m, "Dev book", "books", "img.jpg", new Rating(0, 0));
            var productDto = new ProductDto { Title = "Book", Price = 99.99m };

            mockMapper.Setup(m => m.Map<Product>(It.IsAny<CreateProductCommand>())).Returns(product);
            mockMapper.Setup(m => m.Map<ProductDto>(product)).Returns(productDto);

            var handler = new CreateProductCommandHandler(mockRepo.Object, mockMapper.Object);
            var command = new CreateProductCommand
            {
                Title = "Book",
                Price = 99.99m,
                Description = "Dev book",
                Category = "books",
                Image = "img.jpg",
                RatingRate = 0,
                RatingCount = 0
            };

            var result = await handler.Handle(command, default);

            Assert.Equal("Book", result.Title);
            Assert.Equal(99.99m, result.Price);
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        }
    }
}
