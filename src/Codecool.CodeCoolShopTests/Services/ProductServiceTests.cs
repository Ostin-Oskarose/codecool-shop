using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models.Products;
using Codecool.CodecoolShop.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Codecool.CodeCoolShopTests.Services
{
    public class ProductServiceTests
    {
        [TestCase(12)]
        public void GetProductById_WhenIdIsCorrect_ReturnProduct(int id)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CodeCoolShopDBContext>();

            var data = new List<Product>
            {
                new() {Id = id},
                new() {Id = id + 1}
            }.AsQueryable();
            
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(x => x.Provider)
                .Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(x => x.Expression)
                .Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(x => x.ElementType)
                .Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator())
                .Returns(() => data.GetEnumerator());

            var mockContext = new Mock<CodeCoolShopDBContext>(optionsBuilder.Options);
            mockContext.Setup(x => x.Products)
                .Returns(mockSet.Object);

            var service = new ProductService(mockContext.Object);

            var result = service.GetProductById(id);

            Assert.AreEqual(id, result.Id);
        }

        [TestCase(10, 11)]
        public void GetProducts_WhenIdsAreCorrect_ReturnListOfProducts(int id1, int id2)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CodeCoolShopDBContext>();

            var products = new List<Product>
            {
                new() {Id = id1},
                new() {Id = id2}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);

            mockSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator())
                .Returns(() => products.GetEnumerator());

            var mockContext = new Mock<CodeCoolShopDBContext>(optionsBuilder.Options);
            mockContext.Setup(x => x.Products)
                .Returns(mockSet.Object);

            var service = new ProductService(mockContext.Object);

            var result = service.GetProducts();

            Assert.AreEqual(id1, result[0].Id);
            Assert.AreEqual(id2, result[1].Id);
        }
    }
}
