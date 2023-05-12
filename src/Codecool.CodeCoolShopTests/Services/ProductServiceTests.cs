using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models.Products;
using Codecool.CodecoolShop.Services;
using Microsoft.EntityFrameworkCore;


namespace Codecool.CodeCoolShopTests.Services
{
    public class ProductServiceTests
    {
        private DbContextOptionsBuilder<CodeCoolShopDBContext> _optionsBuilder;

        [SetUp]
        public void Setup()
        {
			_optionsBuilder = new DbContextOptionsBuilder<CodeCoolShopDBContext>();
		}

		[TestCase(12)]
        public void GetProductById_WhenIdIsCorrect_ReturnProduct(int id)
		{
			IQueryable<Product> data = GetProductQueryable(id);

			var dbSetMock = new Mock<DbSet<Product>>();
			dbSetMock.As<IQueryable<Product>>().Setup(x => x.Provider)
				.Returns(data.Provider);
			dbSetMock.As<IQueryable<Product>>().Setup(x => x.Expression)
				.Returns(data.Expression);
			dbSetMock.As<IQueryable<Product>>().Setup(x => x.ElementType)
				.Returns(data.ElementType);
			dbSetMock.As<IQueryable<Product>>().Setup(x => x.GetEnumerator())
				.Returns(() => data.GetEnumerator());

			var mockContext = new Mock<CodeCoolShopDBContext>(_optionsBuilder.Options);
			mockContext.Setup(x => x.Products)
				.Returns(dbSetMock.Object);

			var service = new ProductService(mockContext.Object);

			var result = service.GetProductById(id);

			Assert.AreEqual(id, result.Id);
		}



		[TestCase(10)]
        public void GetProducts_WhenIdsAreCorrect_ReturnListOfProducts(int id)
        {
            var products = GetProductQueryable(id);

			var dbSetMock = new Mock<DbSet<Product>>();
            dbSetMock.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            dbSetMock.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            dbSetMock.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);

            dbSetMock.As<IQueryable<Product>>().Setup(x => x.GetEnumerator())
                .Returns(() => products.GetEnumerator());

            var mockContext = new Mock<CodeCoolShopDBContext>(_optionsBuilder.Options);
            mockContext.Setup(x => x.Products)
                .Returns(dbSetMock.Object);

            var service = new ProductService(mockContext.Object);

            var result = service.GetProducts();

            Assert.AreEqual(id, result[0].Id);
            Assert.AreEqual(id+1, result[1].Id);
        }

		//DataSetup
		private static IQueryable<Product> GetProductQueryable(int id)
		{
			return new List<Product>
			{
				new() {Id = id},
				new() {Id = id + 1}
			}.AsQueryable();
		}
	}
}
